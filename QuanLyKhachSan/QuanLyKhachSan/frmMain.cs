using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmMain : Form
    {
        private DataRow taiKhoanHienTai; //2 dòng này để nhận thông tin tài khoản từ frmLogin
        private frmLogin loginForm; 
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(DataRow taiKhoan, frmLogin loginForm) 
        {
            InitializeComponent();
            this.taiKhoanHienTai = taiKhoan; 
            this.loginForm = loginForm; 
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Load logo
            try
            {
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "Images", "logo.png");
                if (System.IO.File.Exists(logoPath))
                {
                    pbLogo.Image = Image.FromFile(logoPath);
                }
            }
            catch { }

            if (this.taiKhoanHienTai != null)
            {
                PhanQuyen(); 
            }
            LoadComboBoxBoLoc();
            ShowRoomLayout();
            // Không highlight button nào khi khởi động
            ResetAllButtons();
        }
        void PhanQuyen()
        {
            // Lấy LoaiTaiKhoan 
            string loaiTK = this.taiKhoanHienTai["LoaiTaiKhoan"].ToString();
            string tenHienThi = this.taiKhoanHienTai["HoTen"].ToString();

            lbChaoUser.Text = $"Chào {tenHienThi}";

            // Nếu KHÔNG PHẢI là "Quản lý" 
            if (loaiTK != "Quản lý")
            {
                // Vô hiệu hóa (khóa) các button
                btnQLPhong.Enabled = false;
                btnQLDichVu.Enabled = false;
                btnQLTaiKhoan.Enabled = false;
                btnBaoCao.Enabled = false;
            }
        }
        void LoadComboBoxBoLoc()
        {
            DataTable dtLoaiPhong = DataProvider.ThucThiTruyVan("SELECT IDLoaiPhong, TenLoaiPhong FROM LOAIPHONG");
            //Tạo 1 dòng để thêm cái "tất cả" vào combobox
            DataRow allRow = dtLoaiPhong.NewRow();
            allRow["IDLoaiPhong"] = 0;
            allRow["TenLoaiPhong"] = "Tất cả";
            dtLoaiPhong.Rows.InsertAt(allRow, 0);

            cboLoaiPhong.DataSource = dtLoaiPhong;
            cboLoaiPhong.DisplayMember = "TenLoaiPhong"; //hiển thị 3 cái tên loại phòng 
            cboLoaiPhong.ValueMember = "IDLoaiPhong"; //lấy id (do chỉ cần lấy id để xử lí)

            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Đang thuê");
            cboTrangThai.Items.Add("Đang dọn dẹp");
            cboTrangThai.SelectedIndex = 0;

            DataTable dtLoaiGiuong = DataProvider.ThucThiTruyVan("SELECT DISTINCT LoaiGiuong FROM LOAIPHONG");
            DataRow allGiuongRow = dtLoaiGiuong.NewRow();
            allGiuongRow["LoaiGiuong"] = "Tất cả";
            dtLoaiGiuong.Rows.InsertAt(allGiuongRow, 0);

            cboLoaiGiuong.DataSource = dtLoaiGiuong;
            cboLoaiGiuong.DisplayMember = "LoaiGiuong";
        }
        void LoadRoomLayout(int idLoaiPhong = 0, string trangThai = "Tất cả", string loaiGiuong = "Tất cả")
        {
            flpRoomLayout.Controls.Clear();

            // Câu lệnh JOIN để lấy đủ thông tin
            string query = @"SELECT p.IDPhong, p.TenPhong, p.TrangThai, lp.TenLoaiPhong, lp.LoaiGiuong
                             FROM PHONG p JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong";

            //  điều kiện lọc
            List<string> conditions = new List<string>();
            if (idLoaiPhong > 0)
                conditions.Add($"p.IDLoaiPhong = {idLoaiPhong}");
            if (trangThai != "Tất cả")
                conditions.Add($"p.TrangThai = N'{trangThai}'");
            if (loaiGiuong != "Tất cả")
                conditions.Add($"lp.LoaiGiuong = N'{loaiGiuong}'");
            if (conditions.Count > 0)
                query += " WHERE " + string.Join(" AND ", conditions);

            DataTable roomTable = DataProvider.ThucThiTruyVan(query);
            //nội dung của mấy cái button trong flp
            foreach (DataRow item in roomTable.Rows)
            {
                Button roomButton = new Button() { Width = 120, Height = 120 };
                roomButton.Tag = item; 

                string text = $"{item["TenPhong"]}\n{item["TenLoaiPhong"]}\n{item["LoaiGiuong"]}\n({item["TrangThai"]})";
                roomButton.Text = text;
                roomButton.Font = new Font("Arial", 9, FontStyle.Bold);

                //tô màu
                switch (item["TrangThai"].ToString())
                {
                    case "Trống": roomButton.BackColor = Color.LightGreen; break;
                    case "Đang thuê": roomButton.BackColor = Color.Tomato; break;
                    default: roomButton.BackColor = Color.LightYellow; break;
                }

                roomButton.Click += RoomButton_Click;//kick chuột trái
                roomButton.ContextMenuStrip = contextMenuPhong; //kick chuột phải

                flpRoomLayout.Controls.Add(roomButton);
            }

        }
        private void RoomButton_Click(object sender, EventArgs e)
        {
            DataRow roomData = (sender as Button).Tag as DataRow;
            string idPhong = roomData["IDPhong"].ToString();
            string trangThai = roomData["TrangThai"].ToString();

           
            switch (trangThai)
            {
                case "Trống":

                    frmDatPhong fDatPhong = new frmDatPhong(idPhong); // Truyền mã phòng vào
                    fDatPhong.ShowDialog(); 
                    LoadRoomLayout(); 
                    break;
                case "Đang thuê":

                    frmThanhToan fThanhToan = new frmThanhToan(idPhong); 
                    fThanhToan.ShowDialog();
                    LoadRoomLayout();
                    break;
                case "Đang dọn dẹp":
                    if (MessageBox.Show($"Xác nhận phòng [{idPhong}] đã dọn xong?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DataProvider.ThucThiLenh($"UPDATE PHONG SET TrangThai = N'Trống' WHERE IDPhong = '{idPhong}'");
                        LoadRoomLayout();
                    }
                    break;
            }
        }

        
        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiPhong.SelectedValue == null || cboTrangThai.SelectedItem == null || cboLoaiGiuong.SelectedValue == null)
                return;

            int selectedLoaiPhongID = 0;
            if (cboLoaiPhong.SelectedValue != null)
            {
                // Kiểm tra nếu là DataRowView thì lấy giá trị từ field
                if (cboLoaiPhong.SelectedValue is DataRowView)
                {
                    DataRowView row = (DataRowView)cboLoaiPhong.SelectedValue;
                    selectedLoaiPhongID = Convert.ToInt32(row["IDLoaiPhong"]);
                }
                else
                {
                    selectedLoaiPhongID = Convert.ToInt32(cboLoaiPhong.SelectedValue);
                }
            }

            string selectedTrangThai = cboTrangThai.Text;
            string selectedLoaiGiuong = cboLoaiGiuong.Text;
            LoadRoomLayout(selectedLoaiPhongID, selectedTrangThai, selectedLoaiGiuong);
        }

        private void LoadFormIntoPanel(Form form)
        {
            // Xóa các control cũ trong panelMain
            panelMain.Controls.Clear();
            
            // Ẩn panelTop khi load form khác
            panelTop.Visible = false;
            
            // Thiết lập form
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            
            // Thêm form vào panel
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void ShowRoomLayout()
        {
            // Hiện lại panelTop và flpRoomLayout
            panelTop.Visible = true;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(flpRoomLayout);
            LoadRoomLayout();
        }

        private void btnSoDo_Click(object sender, EventArgs e)
        {
            lbTieuDe.Text = "SƠ ĐỒ PHÒNG";
            panelFilter.Visible = true;
            ShowRoomLayout();
            HighlightButton(btnSoDo);
        }

        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            lbTieuDe.Text = "QUẢN LÝ PHÒNG";
            panelFilter.Visible = false;
            frmQLPhong f = new frmQLPhong();
            LoadFormIntoPanel(f);
            HighlightButton(btnQLPhong);
        }

        private void btnQLDichVu_Click(object sender, EventArgs e)
        {
            lbTieuDe.Text = "QUẢN LÝ DỊCH VỤ";
            panelFilter.Visible = false;
            frmQuanLyDichVu f = new frmQuanLyDichVu();
            LoadFormIntoPanel(f);
            HighlightButton(btnQLDichVu);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            lbTieuDe.Text = "BÁO CÁO - THỐNG KÊ";
            panelFilter.Visible = false;
            frmThongKe f = new frmThongKe();
            LoadFormIntoPanel(f);
            HighlightButton(btnBaoCao);
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            lbTieuDe.Text = "QUẢN LÝ TÀI KHOẢN";
            panelFilter.Visible = false;
            frmQuanLyTaiKhoan f = new frmQuanLyTaiKhoan();
            LoadFormIntoPanel(f);
            HighlightButton(btnQLTaiKhoan);
        }

        private void ResetAllButtons()
        {
            // Reset tất cả button về màu mặc định (không có button nào được highlight)
            btnSoDo.BackColor = Color.FromArgb(52, 73, 94);
            btnQLPhong.BackColor = Color.FromArgb(52, 73, 94);
            btnQLDichVu.BackColor = Color.FromArgb(52, 73, 94);
            btnBaoCao.BackColor = Color.FromArgb(52, 73, 94);
            btnQLTaiKhoan.BackColor = Color.FromArgb(52, 73, 94);
        }

        private void HighlightButton(Button activeButton)
        {
            // Reset tất cả button về màu mặc định
            ResetAllButtons();

            // Highlight button được chọn
            activeButton.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.loginForm.Show();
                this.loginForm = null;
                this.Close();
            }
        }

        private void contextMenuPhong_Opening(object sender, CancelEventArgs e)
        {
            
            Button roomButton = (sender as ContextMenuStrip).SourceControl as Button;

            
            DataRow roomData = roomButton.Tag as DataRow;
            string trangThai = roomData["TrangThai"].ToString();

            
            itemCheckIn.Visible = false;
            itemThanhToan.Visible = false;
            itemThemDichVu.Visible = false;
            itemChuyenPhong.Visible = false;
            itemDaDonXong.Visible = false;

            
            switch (trangThai)
            {
                case "Trống":
                    itemCheckIn.Visible = true; 
                    break;
                case "Đang thuê":
                    itemThanhToan.Visible = true; 
                    itemThemDichVu.Visible = true; 
                    itemChuyenPhong.Visible = true; 
                    break;
                case "Đang dọn dẹp":
                    itemDaDonXong.Visible = true; 
                    break;
            }
        }

        private void itemThemDichVu_Click(object sender, EventArgs e)
        {
            //Tìm ngược cái button đã kick itemThemDichVu để lấy thông tin
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;  // Tìm sender gây ra sự kiện: thêm dịch vụ) 
            ContextMenuStrip menu = menuItem.Owner as ContextMenuStrip;// truy ngược menu cha của button chứa cái menustrip 
            Button roomButton = menu.SourceControl as Button;//truy ngược button cha

            
            DataRow roomData = roomButton.Tag as DataRow;
            string idPhong = roomData["IDPhong"].ToString();

            frmThemDichVu f = new frmThemDichVu(idPhong);
            f.Show();
        }
        private Button GetButtonFromMenuItem(object sender) //Hàm tìm button cho lẹ
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            ContextMenuStrip menu = menuItem.Owner as ContextMenuStrip;
            Button roomButton = menu.SourceControl as Button;
            return roomButton;
        }

        private void itemCheckIn_Click(object sender, EventArgs e)
        {
            Button roomButton = GetButtonFromMenuItem(sender);

            
            RoomButton_Click(roomButton, e);
        }

        private void itemThanhToan_Click(object sender, EventArgs e)
        {
            Button roomButton = GetButtonFromMenuItem(sender);

            
            RoomButton_Click(roomButton, e);
        }

        private void itemDaDonXong_Click(object sender, EventArgs e)
        {
            Button roomButton = GetButtonFromMenuItem(sender);

           
            RoomButton_Click(roomButton, e);
        }

        private void itemChuyenPhong_Click(object sender, EventArgs e)
        {
            Button roomButton = GetButtonFromMenuItem(sender);
            DataRow roomData = roomButton.Tag as DataRow;
            string idPhongGoc = roomData["IDPhong"].ToString();

           
            frmChuyenPhong f = new frmChuyenPhong(idPhongGoc);
            f.ShowDialog();

            
            LoadRoomLayout();
        }



        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (this.loginForm != null && !this.loginForm.IsDisposed)
            {
                
                if (this.loginForm != null)
                {
                    this.loginForm.Close();
                }
                
            }
        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
