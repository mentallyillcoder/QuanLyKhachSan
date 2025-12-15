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
    public partial class QLDatPhong : Form
    {
        private string usernameNhanVien = "admin"; // Mặc định

        public QLDatPhong()
        {
            try
            {
                InitializeComponent();
                dgwBang.AutoGenerateColumns = false;

                // Đăng ký sự kiện
                dgwBang.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong constructor QLDatPhong:\n{ex.Message}\n\nStack trace:\n{ex.StackTrace}", 
                               "Lỗi Constructor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Re-throw để caller biết có lỗi
            }
        }

        public QLDatPhong(string username) : this()
        {
            this.usernameNhanVien = username;
        }

        private void dgwBang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy ID phiếu đang chọn (sử dụng tên cột đúng từ Designer)
            int idPhieu = Convert.ToInt32(
                dgwBang.Rows[e.RowIndex].Cells["SPT"].Value);

            string tenCot = dgwBang.Columns[e.ColumnIndex].Name;

            if (tenCot == "ChiTiet")
            {
                // Mở form chi tiết đặt phòng
                frmChiTietDatPhong fChiTiet = new frmChiTietDatPhong(idPhieu);
                fChiTiet.ShowDialog();
            }
            else if (tenCot == "Xoa")
            {
                XoaPhieuDatPhong(idPhieu);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Không tìm kiếm khi đang hiển thị placeholder
            string timKiem = txtTimKiem.Text.Trim();
            if (timKiem == "🔍 Tìm theo tên khách hàng")
                return;
            
            LoadDanhSachPhieu(timKiem, false); // false = không hiện lỗi
        }

        private void QLDatPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhieu(null, true); // true = hiện lỗi nếu có
        }

        private void LoadDanhSachPhieu(string tuKhoa, bool hienThiLoi = true)
        {
            try
            {
                string sql = @"
                    SELECT 
                        p.IDPhieuDat,
                        k.HoTen      AS TenKhachHang,
                        ISNULL(p.NgayLapPhieu, GETDATE()) AS NgayLapPhieu,
                        ISNULL(t.HoTen, p.UsernameNV) AS TenNhanVien
                    FROM PHIEUDATPHONG p
                    JOIN KHACHHANG k ON p.IDKhachHang = k.IDKhachHang
                    LEFT JOIN TAIKHOAN t ON p.UsernameNV = t.Username";

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    // tránh lỗi khi có dấu '
                    string safe = tuKhoa.Replace("'", "''");
                    sql += $" WHERE k.HoTen LIKE N'%{safe}%'";
                }

                sql += " ORDER BY p.IDPhieuDat DESC";

                DataTable dt = DataProvider.ThucThiTruyVan(sql);

                // Map DataPropertyName cho các cột (sử dụng tên cột đúng từ Designer)
                dgwBang.Columns["SPT"].DataPropertyName = "IDPhieuDat";
                dgwBang.Columns["TenKH"].DataPropertyName = "TenKhachHang";
                dgwBang.Columns["NgayLap"].DataPropertyName = "NgayLapPhieu";
                dgwBang.Columns["TenNV"].DataPropertyName = "TenNhanVien";

                dgwBang.DataSource = dt;
            }
            catch (Exception ex)
            {
                // Chỉ hiện lỗi khi được yêu cầu (không hiện khi đang gõ tìm kiếm)
                if (hienThiLoi)
                {
                    MessageBox.Show($"Lỗi khi load danh sách:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void XoaPhieuDatPhong(int idPhieu)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn xóa phiếu này không?",
                "Xóa phiếu đặt phòng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                // 1. Xóa chi tiết dịch vụ
                string sqlDelCTDV =
                    $"DELETE FROM CHITIET_DICHVU WHERE IDPhieuDat = {idPhieu}";
                DataProvider.ThucThiLenh(sqlDelCTDV);

                // 2. Xóa chi tiết phòng
                string sqlDelCTPhong =
                    $"DELETE FROM CHITIET_PHIEUDATPHONG WHERE IDPhieuDat = {idPhieu}";
                DataProvider.ThucThiLenh(sqlDelCTPhong);

                // 3. Xóa hóa đơn (nếu có)
                string sqlDelHD =
                    $"DELETE FROM HOADON WHERE IDPhieuDat = {idPhieu}";
                DataProvider.ThucThiLenh(sqlDelHD);

                // 4. Xóa phiếu đặt phòng
                string sqlDelPDP =
                    $"DELETE FROM PHIEUDATPHONG WHERE IDPhieuDat = {idPhieu}";
                DataProvider.ThucThiLenh(sqlDelPDP);

                MessageBox.Show("Đã xóa phiếu đặt phòng.");
                
                // Reload danh sách
                string timKiem = txtTimKiem.Text.Trim();
                if (timKiem == "🔍 Tìm theo tên khách hàng")
                    timKiem = "";
                LoadDanhSachPhieu(timKiem, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            // Mở form đặt phòng với username nhân viên hiện tại
            using (var f = new PhieuDatPhong(this.usernameNhanVien))
            {
                DialogResult result = f.ShowDialog();
                
                // Chỉ reload khi đặt phòng thành công
                if (result == DialogResult.OK)
                {
                    string timKiem = txtTimKiem.Text.Trim();
                    if (timKiem == "🔍 Tìm theo tên khách hàng")
                        timKiem = "";
                    LoadDanhSachPhieu(timKiem, true);
                }
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "🔍 Tìm theo tên khách hàng")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "🔍 Tìm theo tên khách hàng";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }
    }
}
