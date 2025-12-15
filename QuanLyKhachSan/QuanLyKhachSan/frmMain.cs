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
            string loaiTK = this.taiKhoanHienTai["LoaiTaiKhoan"].ToString().Trim();
            string tenHienThi = this.taiKhoanHienTai["HoTen"].ToString();

            lbChaoUser.Text = $"Chào {tenHienThi}";

            // Debug: Hiển thị loại tài khoản để kiểm tra
            // MessageBox.Show($"Loại TK: [{loaiTK}]");

            // Nếu là nhân viên thì vô hiệu hóa một số chức năng quản lý
            if (loaiTK == "Nhân viên" || loaiTK == "Lễ tân")
            {
                // Nhân viên được phép: QL Đặt phòng, QL Phòng, QL Dịch vụ
                // Nhân viên KHÔNG được phép: QL Tài khoản, Báo cáo
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
            cboTrangThai.Items.Add("Đã đặt");
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

            //  điều kiện lọc (không lọc theo "Đã đặt" và "Đang thuê" vì đây là trạng thái ảo)
            List<string> conditions = new List<string>();
            if (idLoaiPhong > 0)
                conditions.Add($"p.IDLoaiPhong = {idLoaiPhong}");
            if (trangThai != "Tất cả" && trangThai != "Đã đặt" && trangThai != "Đang thuê")
                conditions.Add($"p.TrangThai = N'{trangThai}'");
            if (loaiGiuong != "Tất cả")
                conditions.Add($"lp.LoaiGiuong = N'{loaiGiuong}'");
            if (conditions.Count > 0)
                query += " WHERE " + string.Join(" AND ", conditions);

            DataTable roomTable = DataProvider.ThucThiTruyVan(query);
            
            // Lấy danh sách phòng đã được đặt (chưa check-in) - chấp nhận nhiều trạng thái
            string queryDaDat = @"
                SELECT DISTINCT ct.IDPhong 
                FROM CHITIET_PHIEUDATPHONG ct
                JOIN PHIEUDATPHONG p ON ct.IDPhieuDat = p.IDPhieuDat
                WHERE (LTRIM(RTRIM(p.TrangThai)) LIKE N'%Mới đặt%' 
                       OR LTRIM(RTRIM(p.TrangThai)) LIKE N'%Đã đặt%')
                AND p.TrangThai NOT LIKE N'%check-in%'
                AND p.TrangThai NOT LIKE N'%hủy%'
                AND p.TrangThai NOT LIKE N'%check-out%'";
            DataTable dtPhongDaDat = DataProvider.ThucThiTruyVan(queryDaDat);
            List<string> danhSachPhongDaDat = new List<string>();
            foreach (DataRow row in dtPhongDaDat.Rows)
            {
                danhSachPhongDaDat.Add(row["IDPhong"].ToString());
            }
            
            // Lấy danh sách phòng đang thuê (đã check-in)
            string queryDangThue = @"
                SELECT DISTINCT ct.IDPhong 
                FROM CHITIET_PHIEUDATPHONG ct
                JOIN PHIEUDATPHONG p ON ct.IDPhieuDat = p.IDPhieuDat
                WHERE LTRIM(RTRIM(p.TrangThai)) LIKE N'%check-in%'";
            DataTable dtPhongDangThue = DataProvider.ThucThiTruyVan(queryDangThue);
            List<string> danhSachPhongDangThue = new List<string>();
            foreach (DataRow row in dtPhongDangThue.Rows)
            {
                danhSachPhongDangThue.Add(row["IDPhong"].ToString());
            }

            //nội dung của mấy cái button trong flp
            foreach (DataRow item in roomTable.Rows)
            {
                Button roomButton = new Button() { Width = 120, Height = 120 };
                roomButton.Tag = item; 

                string idPhong = item["IDPhong"].ToString();
                string trangThaiPhong = item["TrangThai"].ToString().Trim();
                
                // Kiểm tra trạng thái thực tế từ database
                bool phongDaDat = danhSachPhongDaDat.Contains(idPhong);
                bool phongDangThue = danhSachPhongDangThue.Contains(idPhong);
                
                // Xác định trạng thái hiển thị
                string trangThaiHienThi = trangThaiPhong;
                if (phongDangThue)
                    trangThaiHienThi = "Đang thuê";
                else if (phongDaDat)
                    trangThaiHienThi = "Đã đặt";
                
                // Lọc theo trạng thái nếu cần
                if (trangThai != "Tất cả" && trangThaiHienThi != trangThai)
                    continue; // Bỏ qua phòng này nếu không khớp với bộ lọc
                
                string text = $"{item["TenPhong"]}\n{item["TenLoaiPhong"]}\n{item["LoaiGiuong"]}\n";
                
                // Hiển thị trạng thái ưu tiên theo database
                if (phongDangThue)
                {
                    text += "(Đang thuê)";
                    roomButton.BackColor = Color.Tomato; // Màu đỏ cho phòng đang thuê
                }
                else if (phongDaDat)
                {
                    text += "(Đã đặt)";
                    roomButton.BackColor = Color.Gray; // Màu xám cho phòng đã đặt
                }
                else
                {
                    text += $"({trangThaiPhong})";
                    //tô màu theo trạng thái
                    switch (trangThaiPhong)
                    {
                        case "Trống": 
                            roomButton.BackColor = Color.LightGreen; 
                            break;
                        case "Đang thuê": 
                            roomButton.BackColor = Color.Tomato; 
                            break;
                        case "Đang dọn dẹp":
                            roomButton.BackColor = Color.LightYellow; 
                            break;
                        default: 
                            roomButton.BackColor = Color.LightGray; 
                            break;
                    }
                }
                
                roomButton.Text = text;
                roomButton.Font = new Font("Arial", 9, FontStyle.Bold);

                roomButton.Click += RoomButton_Click;//kick chuột trái
                roomButton.ContextMenuStrip = contextMenuPhong; //kick chuột phải

                flpRoomLayout.Controls.Add(roomButton);
            }

        }
        private void RoomButton_Click(object sender, EventArgs e)
        {
            DataRow roomData = (sender as Button).Tag as DataRow;
            string idPhong = roomData["IDPhong"].ToString();
            string trangThai = roomData["TrangThai"].ToString().Trim();

            // Kiểm tra trạng thái thực tế từ database
            string queryCheckTrangThai = $@"
                SELECT p.TrangThai 
                FROM PHIEUDATPHONG p
                JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                WHERE ct.IDPhong = '{idPhong}' 
                AND p.TrangThai NOT IN (N'Đã check-out', N'Đã hủy')
                ORDER BY p.IDPhieuDat DESC";
            DataTable dtCheck = DataProvider.ThucThiTruyVan(queryCheckTrangThai);
            
            // Nếu có phiếu đặt phòng đang hoạt động
            if (dtCheck.Rows.Count > 0)
            {
                string trangThaiPhieu = dtCheck.Rows[0]["TrangThai"].ToString().Trim();
                
                // Kiểm tra nếu đã check-in
                if (trangThaiPhieu.Contains("check-in"))
                {
                    // Phòng đang thuê - mở form thanh toán
                    frmThanhToan fThanhToan = new frmThanhToan(idPhong); 
                    fThanhToan.ShowDialog();
                    LoadRoomLayout();
                    return;
                }
                else
                {
                    // Phòng đã đặt nhưng chưa check-in - mở form check-in
                    frmCheckIn fCheckIn = new frmCheckIn(idPhong);
                    if (fCheckIn.ShowDialog() == DialogResult.OK)
                    {
                        LoadRoomLayout();
                    }
                    return;
                }
            }
            
            // Nếu không có phiếu đặt phòng nhưng trạng thái là "Đang thuê"
            // Có thể do dữ liệu không đồng bộ
            if (trangThai == "Đang thuê")
            {
                MessageBox.Show($"Phòng {idPhong} đang ở trạng thái 'Đang thuê' nhưng không tìm thấy phiếu đặt phòng!\n\n" +
                              "Vui lòng kiểm tra lại dữ liệu hoặc cập nhật trạng thái phòng về 'Trống'.",
                              "Lỗi dữ liệu",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }
            
            // Xử lý theo trạng thái phòng thông thường
            switch (trangThai)
            {
                case "Trống":
                    string username = this.taiKhoanHienTai != null ? this.taiKhoanHienTai["Username"].ToString() : "admin";
                    frmDatPhong fDatPhong = new frmDatPhong(idPhong, username); 
                    fDatPhong.ShowDialog(); 
                    LoadRoomLayout(); 
                    break;
                    
                case "Đang dọn dẹp":
                    if (MessageBox.Show($"Xác nhận phòng [{idPhong}] đã dọn xong?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DataProvider.ThucThiLenh($"UPDATE PHONG SET TrangThai = N'Trống' WHERE IDPhong = '{idPhong}'");
                        LoadRoomLayout();
                    }
                    break;
                    
                default:
                    MessageBox.Show($"Trạng thái phòng: {trangThai}", "Thông báo");
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load form vào panel:\n{ex.Message}\n\nStack trace:\n{ex.StackTrace}", 
                               "Lỗi LoadFormIntoPanel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowRoomLayout()
        {
            // Hiện lại panelTop và flpRoomLayout
            panelTop.Visible = true;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(flpRoomLayout);
            LoadRoomLayout();
        }

        private void btnQLDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                lbTieuDe.Text = "QUẢN LÝ ĐẶT PHÒNG";
                panelFilter.Visible = false;
                string username = this.taiKhoanHienTai != null ? this.taiKhoanHienTai["Username"].ToString() : "admin";
                QLDatPhong f = new QLDatPhong(username);
                LoadFormIntoPanel(f);
                HighlightButton(btnQLDatPhong);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form Quản lý đặt phòng:\n{ex.Message}\n\nStack trace:\n{ex.StackTrace}", 
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            btnQLDatPhong.BackColor = Color.FromArgb(52, 73, 94);
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
            string idPhong = roomData["IDPhong"].ToString();
            string trangThai = roomData["TrangThai"].ToString().Trim();

            
            itemCheckIn.Visible = false;
            itemThanhToan.Visible = false;
            itemThemDichVu.Visible = false;
            itemChuyenPhong.Visible = false;
            itemDaDonXong.Visible = false;

            // Kiểm tra trạng thái thực tế từ database
            string queryCheckTrangThai = $@"
                SELECT p.TrangThai 
                FROM PHIEUDATPHONG p
                JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                WHERE ct.IDPhong = '{idPhong}' 
                AND p.TrangThai NOT IN (N'Đã check-out', N'Đã hủy')
                ORDER BY p.IDPhieuDat DESC";
            DataTable dtCheck = DataProvider.ThucThiTruyVan(queryCheckTrangThai);
            
            // Nếu có phiếu đặt phòng đang hoạt động
            if (dtCheck.Rows.Count > 0)
            {
                string trangThaiPhieu = dtCheck.Rows[0]["TrangThai"].ToString().Trim();
                
                // Kiểm tra nếu đã check-in
                if (trangThaiPhieu.Contains("check-in"))
                {
                    // Phòng đang thuê
                    itemThanhToan.Visible = true; 
                    itemThemDichVu.Visible = true; 
                    itemChuyenPhong.Visible = true;
                    return;
                }
                else
                {
                    // Phòng đã đặt - cho phép check-in
                    itemCheckIn.Visible = true;
                    return;
                }
            }
            
            // Xử lý theo trạng thái phòng thông thường
            switch (trangThai)
            {
                case "Trống":
                    itemCheckIn.Visible = true; 
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
