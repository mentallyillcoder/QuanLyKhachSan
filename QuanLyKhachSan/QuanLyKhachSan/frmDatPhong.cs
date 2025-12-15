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
    public partial class frmDatPhong : Form
    {
        private string maPhong;
        private string usernameNhanVien = "admin"; // Mặc định
        private int idKhachHangTimThay = -1; // Biến để lưu ID khách hàng nếu tìm thấy

        
        public frmDatPhong(string idPhong)
        {
            InitializeComponent();
            this.maPhong = idPhong;
        }

        public frmDatPhong(string idPhong, string username) : this(idPhong)
        {
            this.usernameNhanVien = username;
        }

       
        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            this.Text = "Check-in cho phòng " + this.maPhong;
            label1.Text = "Check-in phòng " + this.maPhong;
            dtpCheckIn.Value = DateTime.Now; // Đặt ngày check-in là ngày giờ hiện tại
            //dtpCheckIn.Enabled = false; 
        }

        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập CCCD để tìm kiếm!");
                return;
            }

            
            string query = $"SELECT * FROM KHACHHANG WHERE CCCD = '{cccd}'";
            DataTable dt = DataProvider.ThucThiTruyVan(query);

            if (dt.Rows.Count > 0)
            {
                
                DataRow row = dt.Rows[0];
                this.idKhachHangTimThay = Convert.ToInt32(row["IDKhachHang"]);
                txtHoTen.Text = row["HoTen"].ToString();
                txtSoDienThoai.Text = row["SoDienThoai"].ToString();
                MessageBox.Show("Đã tìm thấy thông tin khách hàng cũ.");
            }
            else
            {
                
                this.idKhachHangTimThay = -1; 
                MessageBox.Show("Không tìm thấy khách hàng. Vui lòng nhập thông tin khách mới.");
                txtHoTen.Text = "";
                txtSoDienThoai.Text = "";
                txtHoTen.Focus(); 
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            
            string hoTen = txtHoTen.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            DateTime ngayCheckIn = dtpCheckIn.Value;

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ CCCD và Họ tên!");
                return;
            }

            try
            {
                int idKhachHang = this.idKhachHangTimThay;

                
                if (idKhachHang == -1)
                {
                    // Thêm khách hàng mới vào DB
                    string queryInsertKH = $"INSERT INTO KHACHHANG (HoTen, CCCD, SoDienThoai) " +
                                          $"VALUES (N'{hoTen}', '{cccd}', '{sdt}'); " +
                                          $"SELECT SCOPE_IDENTITY();"; // trả về ID vừa tạo

                    DataTable dt = DataProvider.ThucThiTruyVan(queryInsertKH);
                    idKhachHang = Convert.ToInt32(dt.Rows[0][0]);
                }

                // Tìm ID nhỏ nhất còn trống để tái sử dụng
                string sqlFindGap = @"
                    SELECT MIN(t1.IDPhieuDat + 1) AS NextID
                    FROM PHIEUDATPHONG t1
                    LEFT JOIN PHIEUDATPHONG t2 ON t1.IDPhieuDat + 1 = t2.IDPhieuDat
                    WHERE t2.IDPhieuDat IS NULL";
                
                DataTable dtGap = DataProvider.ThucThiTruyVan(sqlFindGap);
                int idPhieuDat = 1;
                
                if (dtGap.Rows.Count > 0 && dtGap.Rows[0]["NextID"] != DBNull.Value)
                {
                    idPhieuDat = Convert.ToInt32(dtGap.Rows[0]["NextID"]);
                }
                else
                {
                    string sqlMaxID = "SELECT ISNULL(MAX(IDPhieuDat), 0) + 1 AS NextID FROM PHIEUDATPHONG";
                    DataTable dtMax = DataProvider.ThucThiTruyVan(sqlMaxID);
                    idPhieuDat = Convert.ToInt32(dtMax.Rows[0]["NextID"]);
                }
                
                // Tạo Phiếu đặt phòng với ID cụ thể
                string queryInsertPDP = $@"
                    SET IDENTITY_INSERT PHIEUDATPHONG ON;
                    INSERT INTO PHIEUDATPHONG (IDPhieuDat, IDKhachHang, NgayLapPhieu, NgayCheckIn, TrangThai, UsernameNV) 
                    VALUES ({idPhieuDat}, {idKhachHang}, GETDATE(), '{ngayCheckIn.ToString("yyyy-MM-dd HH:mm:ss")}', N'Đã check-in', '{this.usernameNhanVien}');
                    SET IDENTITY_INSERT PHIEUDATPHONG OFF;";

                DataProvider.ThucThiLenh(queryInsertPDP);

                // Lấy đơn giá phòng
                string queryDonGia = $@"
                    SELECT lp.DonGia 
                    FROM PHONG p 
                    JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong 
                    WHERE p.IDPhong = '{this.maPhong}'";
                DataTable dtDonGia = DataProvider.ThucThiTruyVan(queryDonGia);
                decimal donGia = Convert.ToDecimal(dtDonGia.Rows[0]["DonGia"]);

                // Thêm chi tiết phòng vào CHITIET_PHIEUDATPHONG với NgayBatDau = NgayCheckIn
                string queryInsertChiTiet = $@"
                    INSERT INTO CHITIET_PHIEUDATPHONG (IDPhieuDat, IDPhong, SoNguoi, NgayBatDau, NgayKetThuc, DonGia) 
                    VALUES ({idPhieuDat}, '{this.maPhong}', 1, 
                            '{ngayCheckIn.ToString("yyyy-MM-dd HH:mm:ss")}', 
                            '{ngayCheckIn.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")}', 
                            {donGia})";

                // Cập nhật trạng thái phòng
                string queryUpdatePhong = $"UPDATE PHONG SET TrangThai = N'Đang thuê' WHERE IDPhong = '{this.maPhong}'";

                // Thực thi các lệnh
                DataProvider.ThucThiLenh(queryInsertChiTiet);
                DataProvider.ThucThiLenh(queryUpdatePhong);

                MessageBox.Show("Check-in thành công!");
                this.Close(); // Đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi check-in: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Sự kiện Click nút "Hủy"
        // (Nháy đúp vào nút Hủy ở Design để tạo hàm này)
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
