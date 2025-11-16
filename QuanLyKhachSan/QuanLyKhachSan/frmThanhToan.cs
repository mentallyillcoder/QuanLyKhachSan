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

                // A. TÌM PHIẾU ĐẶT PHÒNG (Để lấy IDPhieuDat, NgayCheckIn, IDKhachHang)
                string queryPDP = $"SELECT * FROM PHIEUDATPHONG WHERE IDPhong = '{this.maPhong}' AND TrangThai = N'Đã check-in'";
                DataTable dtPDP = DataProvider.ThucThiTruyVan(queryPDP);
                if (dtPDP.Rows.Count == 0) { this.Close(); return; }

                DataRow rowPDP = dtPDP.Rows[0];
                this.idPhieuDatHienTai = Convert.ToInt32(rowPDP["IDPhieuDat"]);
                this.ngayCheckIn = Convert.ToDateTime(rowPDP["NgayCheckIn"]);
                int idKhachHang = Convert.ToInt32(rowPDP["IDKhachHang"]);
                // B. TÌM KHÁCH HÀNG (Để lấy tên)
                string queryKH = $"SELECT * FROM KHACHHANG WHERE IDKhachHang = {idKhachHang}";
                lbTenKhachHang.Text = DataProvider.ThucThiTruyVan(queryKH).Rows[0]["HoTen"].ToString();
                // C. TÌM PHÒNG & LOẠI PHÒNG (Để lấy Tên phòng và Đơn giá)
                string queryPhong = $"SELECT p.TenPhong, lp.DonGia FROM PHONG p JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong WHERE p.IDPhong = '{this.maPhong}'";
                DataTable dtPhong = DataProvider.ThucThiTruyVan(queryPhong);
                this.donGiaPhong = Convert.ToDecimal(dtPhong.Rows[0]["DonGia"]);
                lbPhong.Text = dtPhong.Rows[0]["TenPhong"].ToString();
                lbNgayCheckIn.Text = this.ngayCheckIn.ToString("dd/MM/yyyy HH:mm");

                // D. TẢI DỊCH VỤ VÀ TÍNH TIỀN DỊCH VỤ (Tiền DV là cố định)
                string queryDV_List = $"SELECT dv.TenDichVu, cdv.SoLuong, cdv.ThanhTien FROM CHITIET_DICHVU cdv JOIN DICHVU dv ON cdv.IDDichVu = dv.IDDichVu WHERE cdv.IDPhieuDat = {this.idPhieuDatHienTai}";
                dgvDichVuDaSuDung.DataSource = DataProvider.ThucThiTruyVan(queryDV_List);

                string queryDV_Sum = $"SELECT SUM(ThanhTien) FROM CHITIET_DICHVU WHERE IDPhieuDat = {this.idPhieuDatHienTai}";
                object sumDV = DataProvider.ThucThiTruyVan(queryDV_Sum).Rows[0][0];
                this.tienDichVu = (sumDV == DBNull.Value) ? 0 : Convert.ToDecimal(sumDV);
                lbTienDichVu.Text = this.tienDichVu.ToString("N0") + " VNĐ";
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

                // 3. CẬP NHẬT TRẠNG THÁI PHÒNG
                string queryUpdatePhong = $"UPDATE PHONG SET TrangThai = N'Đang dọn dẹp' WHERE IDPhong = '{this.maPhong}'";

                
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
