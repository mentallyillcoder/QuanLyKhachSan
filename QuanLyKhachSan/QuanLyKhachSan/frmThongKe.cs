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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        
        private void frmThongKe_Load(object sender, EventArgs e)
        {
           
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
            dtpDenNgay.Value = DateTime.Now; 

           
            LoadThongKe();
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "btnChiTiet")
            {
                int idHoaDon = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["IDHoaDon"].Value);
                LuuHoaDon(idHoaDon);
            }
        }

        private void LuuHoaDon(int idHoaDon)
        {
            try
            {
                // Lấy thông tin hóa đơn cơ bản
                string queryHDBasic = $@"
                    SELECT h.IDHoaDon, h.IDPhieuDat, h.NgayThanhToan, h.TongTien,
                           k.HoTen, k.CCCD, k.SoDienThoai,
                           pd.NgayCheckIn, pd.NgayCheckOut
                    FROM HOADON h
                    JOIN PHIEUDATPHONG pd ON h.IDPhieuDat = pd.IDPhieuDat
                    JOIN KHACHHANG k ON pd.IDKhachHang = k.IDKhachHang
                    WHERE h.IDHoaDon = {idHoaDon}";

                DataTable dtHDBasic = DataProvider.ThucThiTruyVan(queryHDBasic);

                if (dtHDBasic.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn!", "Lỗi");
                    return;
                }

                DataRow rowBasic = dtHDBasic.Rows[0];

                // Lấy danh sách TẤT CẢ các phòng trong phiếu đặt
                string queryPhong = $@"
                    SELECT p.IDPhong, lp.TenLoaiPhong, lp.DonGia
                    FROM CHITIET_PHIEUDATPHONG ct
                    JOIN PHONG p ON ct.IDPhong = p.IDPhong
                    JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong
                    WHERE ct.IDPhieuDat = {rowBasic["IDPhieuDat"]}";

                DataTable dtPhong = DataProvider.ThucThiTruyVan(queryPhong);

                // Lấy chi tiết dịch vụ
                string queryDV = $@"
                    SELECT dv.TenDichVu, ctdv.SoLuong, dv.DonGia, (ctdv.SoLuong * dv.DonGia) AS ThanhTien
                    FROM CHITIET_DICHVU ctdv
                    JOIN DICHVU dv ON ctdv.IDDichVu = dv.IDDichVu
                    WHERE ctdv.IDPhieuDat = {rowBasic["IDPhieuDat"]}";

                DataTable dtDV = DataProvider.ThucThiTruyVan(queryDV);

                // Tính số đêm và tổng tiền phòng
                TimeSpan soNgay = Convert.ToDateTime(rowBasic["NgayCheckOut"]) - Convert.ToDateTime(rowBasic["NgayCheckIn"]);
                int soDem = (int)Math.Ceiling(soNgay.TotalDays);
                
                decimal tongTienPhong = 0;
                foreach (DataRow phongRow in dtPhong.Rows)
                {
                    tongTienPhong += soDem * Convert.ToDecimal(phongRow["DonGia"]);
                }

                // Tạo form hóa đơn đẹp
                Form frmHoaDon = new Form();
                frmHoaDon.Text = "";
                frmHoaDon.Size = new Size(800, 700);
                frmHoaDon.StartPosition = FormStartPosition.CenterParent;
                frmHoaDon.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmHoaDon.MaximizeBox = false;
                frmHoaDon.MinimizeBox = false;
                frmHoaDon.BackColor = Color.White;

                // Panel chính với scroll
                Panel mainPanel = new Panel();
                mainPanel.Dock = DockStyle.Fill;
                mainPanel.AutoScroll = true;
                mainPanel.BackColor = Color.White;

                // Panel nội dung
                Panel contentPanel = new Panel();
                contentPanel.Width = 750;
                contentPanel.AutoSize = true;
                contentPanel.Location = new Point(10, 10);
                contentPanel.BackColor = Color.White;

                int yPos = 20;

                // Header
                Panel headerPanel = new Panel();
                headerPanel.Width = 730;
                headerPanel.Height = 100;
                headerPanel.Location = new Point(10, yPos);
                headerPanel.BackColor = Color.FromArgb(52, 152, 219);

                Label lblTitle = new Label();
                lblTitle.Text = "HÓA ĐƠN THANH TOÁN";
                lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                lblTitle.ForeColor = Color.White;
                lblTitle.AutoSize = false;
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
                lblTitle.Width = 730;
                lblTitle.Height = 50;
                lblTitle.Location = new Point(0, 15);
                headerPanel.Controls.Add(lblTitle);

                Label lblSubTitle = new Label();
                lblSubTitle.Text = "KHÁCH SẠN";
                lblSubTitle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                lblSubTitle.ForeColor = Color.White;
                lblSubTitle.AutoSize = false;
                lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;
                lblSubTitle.Width = 730;
                lblSubTitle.Height = 25;
                lblSubTitle.Location = new Point(0, 65);
                headerPanel.Controls.Add(lblSubTitle);

                contentPanel.Controls.Add(headerPanel);
                yPos += 120;

                // Thông tin hóa đơn
                Panel infoPanel = new Panel();
                infoPanel.Width = 730;
                infoPanel.Height = 80;
                infoPanel.Location = new Point(10, yPos);
                infoPanel.BackColor = Color.FromArgb(236, 240, 241);
                infoPanel.Padding = new Padding(20);

                Label lblMaHD = new Label();
                lblMaHD.Text = $"Mã hóa đơn: #{rowBasic["IDHoaDon"]}";
                lblMaHD.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lblMaHD.Location = new Point(20, 15);
                lblMaHD.AutoSize = true;
                infoPanel.Controls.Add(lblMaHD);

                Label lblNgayTT = new Label();
                lblNgayTT.Text = $"Ngày thanh toán: {Convert.ToDateTime(rowBasic["NgayThanhToan"]):dd/MM/yyyy HH:mm}";
                lblNgayTT.Font = new Font("Segoe UI", 10);
                lblNgayTT.Location = new Point(20, 45);
                lblNgayTT.AutoSize = true;
                infoPanel.Controls.Add(lblNgayTT);

                contentPanel.Controls.Add(infoPanel);
                yPos += 100;

                // Thông tin khách hàng
                Label lblKHTitle = new Label();
                lblKHTitle.Text = "THÔNG TIN KHÁCH HÀNG";
                lblKHTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblKHTitle.ForeColor = Color.FromArgb(52, 152, 219);
                lblKHTitle.Location = new Point(10, yPos);
                lblKHTitle.AutoSize = true;
                contentPanel.Controls.Add(lblKHTitle);
                yPos += 35;

                Panel khPanel = new Panel();
                khPanel.Width = 730;
                khPanel.Height = 100;
                khPanel.Location = new Point(10, yPos);
                khPanel.BorderStyle = BorderStyle.FixedSingle;
                khPanel.BackColor = Color.White;

                AddInfoLabel(khPanel, "Họ tên:", rowBasic["HoTen"].ToString(), 15);
                AddInfoLabel(khPanel, "CCCD:", rowBasic["CCCD"].ToString(), 45);
                AddInfoLabel(khPanel, "Số điện thoại:", rowBasic["SoDienThoai"].ToString(), 75);

                contentPanel.Controls.Add(khPanel);
                yPos += 120;

                // Thông tin thời gian
                Label lblThoiGianTitle = new Label();
                lblThoiGianTitle.Text = "THỜI GIAN LƯU TRÚ";
                lblThoiGianTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblThoiGianTitle.ForeColor = Color.FromArgb(52, 152, 219);
                lblThoiGianTitle.Location = new Point(10, yPos);
                lblThoiGianTitle.AutoSize = true;
                contentPanel.Controls.Add(lblThoiGianTitle);
                yPos += 35;

                Panel thoiGianPanel = new Panel();
                thoiGianPanel.Width = 730;
                thoiGianPanel.Height = 100;
                thoiGianPanel.Location = new Point(10, yPos);
                thoiGianPanel.BorderStyle = BorderStyle.FixedSingle;
                thoiGianPanel.BackColor = Color.White;

                AddInfoLabel(thoiGianPanel, "Check-in:", Convert.ToDateTime(rowBasic["NgayCheckIn"]).ToString("dd/MM/yyyy HH:mm"), 15);
                AddInfoLabel(thoiGianPanel, "Check-out:", Convert.ToDateTime(rowBasic["NgayCheckOut"]).ToString("dd/MM/yyyy HH:mm"), 45);
                AddInfoLabel(thoiGianPanel, "Số đêm:", soDem.ToString() + " đêm", 75);

                contentPanel.Controls.Add(thoiGianPanel);
                yPos += 120;

                // Danh sách phòng
                Label lblPhongTitle = new Label();
                lblPhongTitle.Text = $"DANH SÁCH PHÒNG ({dtPhong.Rows.Count} phòng)";
                lblPhongTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblPhongTitle.ForeColor = Color.FromArgb(52, 152, 219);
                lblPhongTitle.Location = new Point(10, yPos);
                lblPhongTitle.AutoSize = true;
                contentPanel.Controls.Add(lblPhongTitle);
                yPos += 35;

                Panel phongPanel = new Panel();
                phongPanel.Width = 730;
                phongPanel.Height = 40 + (dtPhong.Rows.Count * 35);
                phongPanel.Location = new Point(10, yPos);
                phongPanel.BorderStyle = BorderStyle.FixedSingle;
                phongPanel.BackColor = Color.White;

                int phongYPos = 15;
                foreach (DataRow phongRow in dtPhong.Rows)
                {
                    decimal donGia = Convert.ToDecimal(phongRow["DonGia"]);
                    decimal thanhTien = soDem * donGia;

                    Label lblPhong = new Label();
                    lblPhong.Text = $"• Phòng {phongRow["IDPhong"]} - {phongRow["TenLoaiPhong"]}";
                    lblPhong.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lblPhong.Location = new Point(20, phongYPos);
                    lblPhong.Width = 300;
                    phongPanel.Controls.Add(lblPhong);

                    Label lblPhongGia = new Label();
                    lblPhongGia.Text = $"{donGia:N0} VNĐ/đêm x {soDem} đêm = {thanhTien:N0} VNĐ";
                    lblPhongGia.Font = new Font("Segoe UI", 10);
                    lblPhongGia.Location = new Point(330, phongYPos);
                    lblPhongGia.AutoSize = true;
                    phongPanel.Controls.Add(lblPhongGia);

                    phongYPos += 35;
                }

                contentPanel.Controls.Add(phongPanel);
                yPos += phongPanel.Height + 20;

                // Chi phí phòng
                Panel tienPhongPanel = new Panel();
                tienPhongPanel.Width = 730;
                tienPhongPanel.Height = 50;
                tienPhongPanel.Location = new Point(10, yPos);
                tienPhongPanel.BackColor = Color.FromArgb(241, 196, 15);

                Label lblTienPhongTitle = new Label();
                lblTienPhongTitle.Text = "Tổng tiền phòng:";
                lblTienPhongTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lblTienPhongTitle.Location = new Point(20, 15);
                lblTienPhongTitle.AutoSize = true;
                tienPhongPanel.Controls.Add(lblTienPhongTitle);

                Label lblTienPhongValue = new Label();
                lblTienPhongValue.Text = tongTienPhong.ToString("N0") + " VNĐ";
                lblTienPhongValue.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lblTienPhongValue.Location = new Point(550, 15);
                lblTienPhongValue.AutoSize = true;
                tienPhongPanel.Controls.Add(lblTienPhongValue);

                contentPanel.Controls.Add(tienPhongPanel);
                yPos += 70;

                // Dịch vụ
                decimal tongDichVu = 0;
                if (dtDV.Rows.Count > 0)
                {
                    Label lblDVTitle = new Label();
                    lblDVTitle.Text = "DỊCH VỤ SỬ DỤNG";
                    lblDVTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    lblDVTitle.ForeColor = Color.FromArgb(52, 152, 219);
                    lblDVTitle.Location = new Point(10, yPos);
                    lblDVTitle.AutoSize = true;
                    contentPanel.Controls.Add(lblDVTitle);
                    yPos += 35;

                    Panel dvPanel = new Panel();
                    dvPanel.Width = 730;
                    dvPanel.Height = 40 + (dtDV.Rows.Count * 30);
                    dvPanel.Location = new Point(10, yPos);
                    dvPanel.BorderStyle = BorderStyle.FixedSingle;
                    dvPanel.BackColor = Color.White;

                    int dvYPos = 15;
                    foreach (DataRow dvRow in dtDV.Rows)
                    {
                        Label lblDV = new Label();
                        lblDV.Text = $"• {dvRow["TenDichVu"]} x {dvRow["SoLuong"]}";
                        lblDV.Font = new Font("Segoe UI", 10);
                        lblDV.Location = new Point(20, dvYPos);
                        lblDV.Width = 500;
                        dvPanel.Controls.Add(lblDV);

                        Label lblDVGia = new Label();
                        lblDVGia.Text = Convert.ToDecimal(dvRow["ThanhTien"]).ToString("N0") + " VNĐ";
                        lblDVGia.Font = new Font("Segoe UI", 10);
                        lblDVGia.Location = new Point(550, dvYPos);
                        lblDVGia.AutoSize = true;
                        dvPanel.Controls.Add(lblDVGia);

                        tongDichVu += Convert.ToDecimal(dvRow["ThanhTien"]);
                        dvYPos += 30;
                    }

                    contentPanel.Controls.Add(dvPanel);
                    yPos += dvPanel.Height + 20;

                    // Tổng dịch vụ
                    Panel tongDVPanel = new Panel();
                    tongDVPanel.Width = 730;
                    tongDVPanel.Height = 50;
                    tongDVPanel.Location = new Point(10, yPos);
                    tongDVPanel.BackColor = Color.FromArgb(241, 196, 15);

                    Label lblTongDVTitle = new Label();
                    lblTongDVTitle.Text = "Tổng dịch vụ:";
                    lblTongDVTitle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    lblTongDVTitle.Location = new Point(20, 15);
                    lblTongDVTitle.AutoSize = true;
                    tongDVPanel.Controls.Add(lblTongDVTitle);

                    Label lblTongDVValue = new Label();
                    lblTongDVValue.Text = tongDichVu.ToString("N0") + " VNĐ";
                    lblTongDVValue.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    lblTongDVValue.Location = new Point(550, 15);
                    lblTongDVValue.AutoSize = true;
                    tongDVPanel.Controls.Add(lblTongDVValue);

                    contentPanel.Controls.Add(tongDVPanel);
                    yPos += 70;
                }

                // Tổng tiền
                Panel tongTienPanel = new Panel();
                tongTienPanel.Width = 730;
                tongTienPanel.Height = 70;
                tongTienPanel.Location = new Point(10, yPos);
                tongTienPanel.BackColor = Color.FromArgb(46, 204, 113);

                Label lblTongTienTitle = new Label();
                lblTongTienTitle.Text = "TỔNG TIỀN:";
                lblTongTienTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTongTienTitle.ForeColor = Color.White;
                lblTongTienTitle.Location = new Point(20, 20);
                lblTongTienTitle.AutoSize = true;
                tongTienPanel.Controls.Add(lblTongTienTitle);

                Label lblTongTienValue = new Label();
                lblTongTienValue.Text = Convert.ToDecimal(rowBasic["TongTien"]).ToString("N0") + " VNĐ";
                lblTongTienValue.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTongTienValue.ForeColor = Color.White;
                lblTongTienValue.Location = new Point(450, 20);
                lblTongTienValue.AutoSize = true;
                tongTienPanel.Controls.Add(lblTongTienValue);

                contentPanel.Controls.Add(tongTienPanel);
                yPos += 90;

                // Footer
                Label lblFooter = new Label();
                lblFooter.Text = "Cảm ơn quý khách! Hẹn gặp lại!";
                lblFooter.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                lblFooter.ForeColor = Color.Gray;
                lblFooter.Location = new Point(10, yPos);
                lblFooter.Width = 730;
                lblFooter.TextAlign = ContentAlignment.MiddleCenter;
                lblFooter.Height = 40;
                contentPanel.Controls.Add(lblFooter);
                yPos += 60;

                contentPanel.Height = yPos;
                mainPanel.Controls.Add(contentPanel);
                frmHoaDon.Controls.Add(mainPanel);
                frmHoaDon.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị hóa đơn: " + ex.Message, "Lỗi");
            }
        }

        private void AddInfoLabel(Panel panel, string title, string value, int yPos)
        {
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.Location = new Point(20, yPos);
            lblTitle.Width = 150;
            panel.Controls.Add(lblTitle);

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 10);
            lblValue.Location = new Point(180, yPos);
            lblValue.Width = 520;
            panel.Controls.Add(lblValue);
        }

       
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        
        void LoadThongKe()
        {
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;

            
            denNgay = denNgay.Date.AddDays(1).AddSeconds(-1);

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!");
                return;
            }

            try
            {
               
                string query = $"SELECT IDHoaDon, IDPhieuDat, NgayThanhToan, TongTien " +
                               $"FROM HOADON " +
                               $"WHERE NgayThanhToan >= '{tuNgay.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                               $"AND NgayThanhToan <= '{denNgay.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                               $"ORDER BY NgayThanhToan DESC"; 

                DataTable dt = DataProvider.ThucThiTruyVan(query);
                dgvHoaDon.DataSource = dt;

                dgvHoaDon.Columns["IDHoaDon"].HeaderText = "Mã HĐ";
                dgvHoaDon.Columns["IDHoaDon"].ReadOnly = true;
                dgvHoaDon.Columns["IDPhieuDat"].HeaderText = "Mã Phiếu Đặt";
                dgvHoaDon.Columns["IDPhieuDat"].ReadOnly = true;
                dgvHoaDon.Columns["NgayThanhToan"].HeaderText = "Ngày Thanh Toán";
                dgvHoaDon.Columns["NgayThanhToan"].ReadOnly = true;
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvHoaDon.Columns["TongTien"].ReadOnly = true;
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0"; // Format tiền

                // Thêm cột nút Chi tiết nếu chưa có
                if (!dgvHoaDon.Columns.Contains("btnChiTiet"))
                {
                    DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                    btnCol.Name = "btnChiTiet";
                    btnCol.HeaderText = "Thao tác";
                    btnCol.Text = "Chi tiết";
                    btnCol.UseColumnTextForButtonValue = true;
                    btnCol.Width = 100;
                    dgvHoaDon.Columns.Add(btnCol);
                }

                
                decimal tongDoanhThu = 0;
                int soHoaDon = dt.Rows.Count;
                foreach (DataRow row in dt.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["TongTien"]);
                }

                lbSoHoaDonValue.Text = soHoaDon.ToString();
                lbTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message);
            }
        }
    }
}
