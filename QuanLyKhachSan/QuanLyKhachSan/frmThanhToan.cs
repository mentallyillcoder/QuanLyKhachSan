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
    public partial class frmThanhToan : Form
    {
        
        private string maPhong;
        private int idPhieuDatHienTai;
        private DateTime ngayCheckIn;
        private decimal donGiaPhong;
        private decimal tienPhong;
        private decimal tienDichVu;

        
        public frmThanhToan(string idPhong)
        {
            InitializeComponent();
            this.maPhong = idPhong;
        }

        
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            this.Text = "Thanh toán cho phòng " + this.maPhong;
            label1.Text = "Thanh toán phòng " + this.maPhong;
            LoadThongTinCoBan();
            dtpNgayCheckOut.Value = DateTime.Now;
        }

        
        void LoadThongTinCoBan()
        {
            try
            {

                // A. TÌM PHIẾU ĐẶT PHÒNG (Thông qua CHITIET_PHIEUDATPHONG)
                string queryPDP = $@"
                    SELECT p.IDPhieuDat, p.NgayCheckIn, p.IDKhachHang 
                    FROM PHIEUDATPHONG p
                    JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                    WHERE ct.IDPhong = '{this.maPhong}' AND p.TrangThai = N'Đã check-in'";
                DataTable dtPDP = DataProvider.ThucThiTruyVan(queryPDP);
                if (dtPDP.Rows.Count == 0) 
                { 
                    MessageBox.Show("Không tìm thấy phiếu đặt phòng đang check-in cho phòng này!", "Thông báo");
                    this.Close(); 
                    return; 
                }

                DataRow rowPDP = dtPDP.Rows[0];
                this.idPhieuDatHienTai = Convert.ToInt32(rowPDP["IDPhieuDat"]);
                this.ngayCheckIn = Convert.ToDateTime(rowPDP["NgayCheckIn"]);
                int idKhachHang = Convert.ToInt32(rowPDP["IDKhachHang"]);
                
                // B. TÌM KHÁCH HÀNG (Để lấy tên và CCCD)
                string queryKH = $"SELECT * FROM KHACHHANG WHERE IDKhachHang = {idKhachHang}";
                DataTable dtKH = DataProvider.ThucThiTruyVan(queryKH);
                if (dtKH.Rows.Count > 0)
                {
                    lbTenKhachHang.Text = dtKH.Rows[0]["HoTen"].ToString();
                    lbCCCD.Text = dtKH.Rows[0]["CCCD"] != DBNull.Value ? dtKH.Rows[0]["CCCD"].ToString() : "N/A";
                }
                
                // C. TÌM TẤT CẢ CÁC PHÒNG TRONG PHIẾU ĐẶT NÀY
                string queryAllPhong = $@"
                    SELECT p.IDPhong, p.TenPhong, lp.TenLoaiPhong, lp.DonGia
                    FROM CHITIET_PHIEUDATPHONG ct
                    JOIN PHONG p ON ct.IDPhong = p.IDPhong
                    JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong
                    WHERE ct.IDPhieuDat = {this.idPhieuDatHienTai}";
                DataTable dtAllPhong = DataProvider.ThucThiTruyVan(queryAllPhong);
                
                // Tính tổng đơn giá của tất cả các phòng
                this.donGiaPhong = 0;
                string danhSachPhong = "";
                foreach (DataRow row in dtAllPhong.Rows)
                {
                    this.donGiaPhong += Convert.ToDecimal(row["DonGia"]);
                    danhSachPhong += row["TenPhong"].ToString() + " (" + row["TenLoaiPhong"].ToString() + ")" + Environment.NewLine;
                }
                
                // Hiển thị danh sách phòng (bỏ dòng trống cuối)
                if (danhSachPhong.Length > 0)
                    danhSachPhong = danhSachPhong.TrimEnd();
                
                lbPhong.Text = danhSachPhong;
                lbNgayCheckIn.Text = this.ngayCheckIn.ToString("dd/MM/yyyy HH:mm");

                // D. TẢI DỊCH VỤ VÀ TÍNH TIỀN DỊCH VỤ (Sử dụng ThanhTien tự động tính)
                string queryDV_List = $@"
                    SELECT 
                        dv.TenDichVu, 
                        cdv.SoLuong, 
                        cdv.DonGia,
                        (cdv.SoLuong * cdv.DonGia) AS ThanhTien
                    FROM CHITIET_DICHVU cdv 
                    JOIN DICHVU dv ON cdv.IDDichVu = dv.IDDichVu 
                    WHERE cdv.IDPhieuDat = {this.idPhieuDatHienTai}";
                
                DataTable dtDichVu = DataProvider.ThucThiTruyVan(queryDV_List);
                dgvDichVuDaSuDung.DataSource = dtDichVu;

                // Tính tổng tiền dịch vụ từ kết quả query
                this.tienDichVu = 0;
                foreach (DataRow row in dtDichVu.Rows)
                {
                    this.tienDichVu += Convert.ToDecimal(row["ThanhTien"]);
                }
                
                lbTienDichVu.Text = this.tienDichVu.ToString("N0") + " VNĐ";
                
                Console.WriteLine($"Tổng tiền dịch vụ: {this.tienDichVu:N0} VNĐ từ {dtDichVu.Rows.Count} dịch vụ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nghiêm trọng khi tải dữ liệu: " + ex.Message);
                this.Close();
            }
        }
        void TinhTien()
        {
            
            DateTime ngayCheckOut = dtpNgayCheckOut.Value;

            
            if (ngayCheckOut < this.ngayCheckIn)
            {
                ngayCheckOut = this.ngayCheckIn;
                dtpNgayCheckOut.Value = ngayCheckOut; 
            }

            // -- TÍNH TIỀN PHÒNG --
            TimeSpan soNgayO = ngayCheckOut - this.ngayCheckIn;
            int soDem = (int)Math.Ceiling(soNgayO.TotalDays); // Làm tròn lên
            if (soDem == 0) soDem = 1; // Ở trong ngày vẫn tính 1

            
            this.tienPhong = soDem * this.donGiaPhong;
            lbTienPhong.Text = this.tienPhong.ToString("N0") + " VNĐ";

            // -- TÍNH TỔNG CỘNG --
            decimal tongTien = this.tienPhong + this.tienDichVu;
            lbTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        
        private void dtpNgayCheckOut_ValueChanged(object sender, EventArgs e)
        {
            
            TinhTien();
        }

       
        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thanh toán và check-out?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                // Lấy tổng tiền và ngày check-out cuối cùng
                decimal tongTien = this.tienPhong + this.tienDichVu;
                DateTime ngayCheckOut = dtpNgayCheckOut.Value; 

                // 1. TẠO HÓA ĐƠN MỚI
                string queryInsertHD = $"INSERT INTO HOADON (IDPhieuDat, NgayThanhToan, TongTien) " +
                                       $"VALUES ({this.idPhieuDatHienTai}, '{ngayCheckOut.ToString("yyyy-MM-dd HH:mm:ss")}', {tongTien})";

                // 2. CẬP NHẬT PHIẾU ĐẶT PHÒNG
                string queryUpdatePDP = $"UPDATE PHIEUDATPHONG SET NgayCheckOut = '{ngayCheckOut.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                                       $"TongTienHoaDon = {tongTien}, TrangThai = N'Đã check-out' " +
                                       $"WHERE IDPhieuDat = {this.idPhieuDatHienTai}";

                // 3. CẬP NHẬT TRẠNG THÁI TẤT CẢ CÁC PHÒNG TRONG PHIẾU ĐẶT NÀY
                string queryUpdatePhong = $@"
                    UPDATE PHONG 
                    SET TrangThai = N'Đang dọn dẹp' 
                    WHERE IDPhong IN (
                        SELECT IDPhong 
                        FROM CHITIET_PHIEUDATPHONG 
                        WHERE IDPhieuDat = {this.idPhieuDatHienTai}
                    )";

                
                DataProvider.ThucThiLenh(queryInsertHD);
                DataProvider.ThucThiLenh(queryUpdatePDP);
                DataProvider.ThucThiLenh(queryUpdatePhong);

                MessageBox.Show("Thanh toán và check-out thành công!");
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
