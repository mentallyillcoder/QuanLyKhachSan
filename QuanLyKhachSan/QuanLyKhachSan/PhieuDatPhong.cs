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
    public partial class PhieuDatPhong : Form
    {
        private string usernameNhanVien = "admin"; // Mặc định

        public PhieuDatPhong()
        {
            InitializeComponent();
            dgwPhongTrong.AutoGenerateColumns = false;
            dgwPhongDaChon.AutoGenerateColumns = false;
            
            // Thêm event handler để validate số người
            dgwPhongDaChon.CellValidating += DgwPhongDaChon_CellValidating;
            dgwPhongDaChon.CellEndEdit += DgwPhongDaChon_CellEndEdit;
            
            // Thêm event handler để reload danh sách phòng khi thay đổi ngày
            dtpNgayBD.ValueChanged += DateTimePicker_ValueChanged;
            dtpNgayKT.ValueChanged += DateTimePicker_ValueChanged;
            dtpGioBD.ValueChanged += DateTimePicker_ValueChanged;
            dtpGioKT.ValueChanged += DateTimePicker_ValueChanged;
            
            // Thêm keyboard shortcut để test database (Ctrl+T)
            this.KeyPreview = true;
            this.KeyDown += PhieuDatPhong_KeyDown;
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Reload danh sách phòng trống khi thay đổi ngày check-in/check-out
            LoadDanhSachPhongTrong();
        }

        public PhieuDatPhong(string username) : this()
        {
            this.usernameNhanVien = username;
        }

        private void PhieuDatPhong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.T)
            {
                TestDatabaseConnection();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                ResetCustomerForm();
                e.Handled = true;
            }
        }
        private void PhieuDatPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhongTrong();
            
            // Uncomment dòng dưới để test database connection
            // TestDatabaseConnection();
        }

        private void LoadDanhSachPhongTrong()
        {
            // Lấy ngày check-in và check-out từ form
            DateTime ngayBD = dtpNgayBD.Value.Date + dtpGioBD.Value.TimeOfDay;
            DateTime ngayKT = dtpNgayKT.Value.Date + dtpGioKT.Value.TimeOfDay;

            // Query lọc phòng trống và loại trừ phòng đã được đặt trong khoảng thời gian này
            string sql = $@"
                SELECT p.IDPhong, lp.TenLoaiPhong
                FROM PHONG p
                JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong
                WHERE p.TrangThai = N'Trống'
                AND p.IDPhong NOT IN (
                    SELECT ct.IDPhong 
                    FROM CHITIET_PHIEUDATPHONG ct
                    JOIN PHIEUDATPHONG pdp ON ct.IDPhieuDat = pdp.IDPhieuDat
                    WHERE pdp.TrangThai NOT IN (N'Đã check-out', N'Đã hủy')
                    AND NOT (ct.NgayKetThuc <= '{ngayBD:yyyy-MM-dd HH:mm:ss}' 
                             OR ct.NgayBatDau >= '{ngayKT:yyyy-MM-dd HH:mm:ss}')
                )";

            DataTable dtPhong = DataProvider.ThucThiTruyVan(sql);

            // map DataPropertyName cho cột
            dgwPhongTrong.Columns["SoPhong"].DataPropertyName = "IDPhong";
            dgwPhongTrong.Columns["LoaiPhong"].DataPropertyName = "TenLoaiPhong";

            dgwPhongTrong.DataSource = dtPhong;
        }
        private void dgwPhongTrong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Kiểm tra có phải cột "Thêm" không
            if (dgwPhongTrong.Columns[e.ColumnIndex].Name == "Them")
            {
                string soPhong = dgwPhongTrong.Rows[e.RowIndex].Cells["SoPhong"].Value.ToString();

                // check trùng phòng
                foreach (DataGridViewRow r in dgwPhongDaChon.Rows)
                {
                    if (r.IsNewRow) continue;
                    if (r.Cells["SoPhongDC"].Value != null &&
                        r.Cells["SoPhongDC"].Value.ToString() == soPhong)
                    {
                        MessageBox.Show("Phòng này đã được chọn rồi!");
                        return;
                    }
                }

                // Gộp ngày + giờ để hiển thị
                DateTime ngayBD = dtpNgayBD.Value.Date + dtpGioBD.Value.TimeOfDay;
                DateTime ngayKT = dtpNgayKT.Value.Date + dtpGioKT.Value.TimeOfDay;

                // Thêm dòng mới vào dgwPhongDaChon
                dgwPhongDaChon.Rows.Add(
                    soPhong,                      // SoPhongDC
                    1,                            // SoNguoi (tạm cho = 1, có thể sửa trực tiếp trên grid)
                    ngayBD.ToString("dd/MM/yyyy HH:mm")
                );
            }
        }

        private void dgwPhongDaChon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgwPhongDaChon.Columns[e.ColumnIndex].Name == "Xoa")
            {
                dgwPhongDaChon.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate thông tin khách hàng
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập CCCD!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (dgwPhongDaChon.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Thêm hoặc lấy khách hàng
                string sqlCheckKH = $"SELECT IDKhachHang FROM KHACHHANG WHERE CCCD = '{txtCCCD.Text.Trim()}'";
                DataTable dtKH = DataProvider.ThucThiTruyVan(sqlCheckKH);
                
                int idKhachHang;
                if (dtKH.Rows.Count > 0)
                {
                    idKhachHang = Convert.ToInt32(dtKH.Rows[0]["IDKhachHang"]);
                }
                else
                {
                    string sqlInsertKH = $@"
                        INSERT INTO KHACHHANG (HoTen, CCCD, SoDienThoai,DiaChi)
                        VALUES (N'{txtHoTen.Text.Trim()}', '{txtCCCD.Text.Trim()}', '{txtSDT.Text.Trim()}', '{txtDiaChi.Text.Trim()}')";
                    
                    int rowsAffected = DataProvider.ThucThiLenh(sqlInsertKH);
                    
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Không thể thêm khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    // Lấy ID vừa insert
                    string sqlGetID = $"SELECT IDKhachHang FROM KHACHHANG WHERE CCCD = '{txtCCCD.Text.Trim()}'";
                    DataTable dtNewKH = DataProvider.ThucThiTruyVan(sqlGetID);
                    
                    if (dtNewKH.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng vừa thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    idKhachHang = Convert.ToInt32(dtNewKH.Rows[0]["IDKhachHang"]);
                }

                // 2. Tạo phiếu đặt phòng
                DateTime ngayCheckIn = dtpNgayBD.Value.Date + dtpGioBD.Value.TimeOfDay;
                DateTime ngayCheckOut = dtpNgayKT.Value.Date + dtpGioKT.Value.TimeOfDay;

                // Tính tổng số người
                int tongSoNguoi = 0;
                foreach (DataGridViewRow row in dgwPhongDaChon.Rows)
                {
                    if (row.IsNewRow) continue;
                    tongSoNguoi += Convert.ToInt32(row.Cells["SoNguoi"].Value);
                }

                // Tìm ID nhỏ nhất còn trống (ID đã bị xóa) để tái sử dụng
                string sqlFindGap = @"
                    SELECT MIN(t1.IDPhieuDat + 1) AS NextID
                    FROM PHIEUDATPHONG t1
                    LEFT JOIN PHIEUDATPHONG t2 ON t1.IDPhieuDat + 1 = t2.IDPhieuDat
                    WHERE t2.IDPhieuDat IS NULL";
                
                DataTable dtGap = DataProvider.ThucThiTruyVan(sqlFindGap);
                int idPhieuDat = 1; // Mặc định là 1 nếu chưa có phiếu nào
                
                if (dtGap.Rows.Count > 0 && dtGap.Rows[0]["NextID"] != DBNull.Value)
                {
                    idPhieuDat = Convert.ToInt32(dtGap.Rows[0]["NextID"]);
                }
                else
                {
                    // Nếu không có khoảng trống, lấy MAX + 1
                    string sqlMaxID = "SELECT ISNULL(MAX(IDPhieuDat), 0) + 1 AS NextID FROM PHIEUDATPHONG";
                    DataTable dtMax = DataProvider.ThucThiTruyVan(sqlMaxID);
                    idPhieuDat = Convert.ToInt32(dtMax.Rows[0]["NextID"]);
                }
                
                // Tạo phiếu đặt phòng với ID cụ thể
                string sqlInsertPhieu = $@"
                    SET IDENTITY_INSERT PHIEUDATPHONG ON;
                    INSERT INTO PHIEUDATPHONG (IDPhieuDat, IDKhachHang, NgayCheckIn, NgayCheckOut, SoNguoi, TrangThai, UsernameNV)
                    VALUES ({idPhieuDat}, {idKhachHang}, '{ngayCheckIn:yyyy-MM-dd HH:mm:ss}', '{ngayCheckOut:yyyy-MM-dd HH:mm:ss}', 
                            {tongSoNguoi}, N'Mới đặt', '{this.usernameNhanVien}');
                    SET IDENTITY_INSERT PHIEUDATPHONG OFF;";

                DataProvider.ThucThiLenh(sqlInsertPhieu);

                // 3. Thêm chi tiết phòng vào CHITIET_PHIEUDATPHONG
                foreach (DataGridViewRow row in dgwPhongDaChon.Rows)
                {
                    if (row.IsNewRow) continue;

                    string idPhong = row.Cells["SoPhongDC"].Value.ToString();
                    int soNguoi = Convert.ToInt32(row.Cells["SoNguoi"].Value);

                    // Lấy đơn giá
                    string sqlDonGia = $@"
                        SELECT lp.DonGia 
                        FROM PHONG p 
                        JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong 
                        WHERE p.IDPhong = '{idPhong}'";
                    DataTable dtDonGia = DataProvider.ThucThiTruyVan(sqlDonGia);
                    decimal donGia = Convert.ToDecimal(dtDonGia.Rows[0]["DonGia"]);

                    // Thêm chi tiết
                    string sqlInsertCT = $@"
                        INSERT INTO CHITIET_PHIEUDATPHONG (IDPhieuDat, IDPhong, SoNguoi, NgayBatDau, NgayKetThuc, DonGia)
                        VALUES ({idPhieuDat}, '{idPhong}', {soNguoi}, 
                                '{ngayCheckIn:yyyy-MM-dd HH:mm:ss}', '{ngayCheckOut:yyyy-MM-dd HH:mm:ss}', {donGia})";
                    DataProvider.ThucThiLenh(sqlInsertCT);

                    // Bỏ qua việc UPDATE trạng thái phòng vì có vấn đề với constraint
                    // Trạng thái phòng sẽ được quản lý thông qua bảng PHIEUDATPHONG
                }

                MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(cccd))
            {
                MessageBox.Show("Vui lòng nhập CCCD để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            try
            {
                // Tìm kiếm khách hàng theo CCCD với nhiều cách khác nhau
                // Thử từng query một để tìm ra cách nào hoạt động
                DataTable dtKH = null;
                string[] queries = {
                    $"SELECT HoTen, CCCD, SoDienThoai, DiaChi FROM KHACHHANG WHERE CCCD = '{cccd}'",
                    $"SELECT HoTen, CCCD, SoDienThoai, DiaChi FROM KHACHHANG WHERE CAST(CCCD AS NVARCHAR(50)) = '{cccd}'",
                    $"SELECT HoTen, CCCD, SoDienThoai, DiaChi FROM KHACHHANG WHERE CONVERT(NVARCHAR(50), CCCD) = '{cccd}'",
                    $"SELECT HoTen, CCCD, SoDienThoai, DiaChi FROM KHACHHANG WHERE CCCD LIKE '%{cccd}%'"
                };
                
                foreach (string query in queries)
                {
                    try
                    {
                        dtKH = DataProvider.ThucThiTruyVan(query);
                        Console.WriteLine($"Query: {query} - Kết quả: {dtKH.Rows.Count}");
                        if (dtKH.Rows.Count > 0)
                        {
                            break; // Tìm thấy rồi thì dừng
                        }
                    }
                    catch (Exception queryEx)
                    {
                        Console.WriteLine($"Query failed: {query} - Error: {queryEx.Message}");
                        continue;
                    }
                }
                
                if (dtKH != null && dtKH.Rows.Count > 0)
                {
                    // Khách hàng cũ - tự động điền thông tin
                    DataRow row = dtKH.Rows[0];
                    txtHoTen.Text = row["HoTen"].ToString();
                    txtSDT.Text = row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "";
                    txtDiaChi.Text = row["DiaChi"] != DBNull.Value ? row["DiaChi"].ToString() : "";
                    
                    MessageBox.Show($"✅ Đã tìm thấy thông tin khách hàng!\nHọ tên: {row["HoTen"]}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Khóa các trường thông tin để không sửa được
                    txtHoTen.ReadOnly = true;
                    txtCCCD.ReadOnly = true;
                    txtSDT.ReadOnly = true;
                    txtDiaChi.ReadOnly = true;
                    
                    // Đổi màu nền để biết là khách cũ
                    txtHoTen.BackColor = Color.FromArgb(230, 247, 255);
                    txtCCCD.BackColor = Color.FromArgb(230, 247, 255);
                    txtSDT.BackColor = Color.FromArgb(230, 247, 255);
                    txtDiaChi.BackColor = Color.FromArgb(230, 247, 255);
                }
                else
                {
                    // Khách hàng mới - cho phép nhập thông tin
                    MessageBox.Show("❌ Không tìm thấy khách hàng. Vui lòng nhập thông tin khách hàng mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Xóa các trường và cho phép nhập (trừ CCCD đã nhập)
                    txtHoTen.Text = "";
                    txtSDT.Text = "";
                    txtDiaChi.Text = "";
                    
                    txtHoTen.ReadOnly = false;
                    txtCCCD.ReadOnly = false;
                    txtSDT.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;
                    
                    // Đổi màu nền về mặc định
                    txtHoTen.BackColor = Color.White;
                    txtCCCD.BackColor = Color.White;
                    txtSDT.BackColor = Color.White;
                    txtDiaChi.BackColor = Color.White;
                    
                    txtHoTen.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message + "\n\nVui lòng kiểm tra kết nối database.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Chi tiết lỗi: " + ex.ToString());
            }
        }

        private void DgwPhongDaChon_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Chỉ validate cột "Số người"
            if (dgwPhongDaChon.Columns[e.ColumnIndex].Name == "SoNguoi")
            {
                int soNguoi;
                if (!int.TryParse(e.FormattedValue.ToString(), out soNguoi) || soNguoi <= 0 || soNguoi > 10)
                {
                    e.Cancel = true;
                    MessageBox.Show("Số người phải là số nguyên từ 1 đến 10!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DgwPhongDaChon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Sau khi chỉnh sửa xong, đảm bảo giá trị hợp lệ
            if (dgwPhongDaChon.Columns[e.ColumnIndex].Name == "SoNguoi")
            {
                var cell = dgwPhongDaChon.Rows[e.RowIndex].Cells[e.ColumnIndex];
                int soNguoi;
                if (!int.TryParse(cell.Value?.ToString(), out soNguoi) || soNguoi <= 0)
                {
                    cell.Value = 1; // Đặt về giá trị mặc định
                }
                else if (soNguoi > 10)
                {
                    cell.Value = 10; // Giới hạn tối đa
                }
            }
        }

        private void ResetCustomerForm()
        {
            // Xóa tất cả thông tin khách hàng
            txtHoTen.Text = "";
            txtCCCD.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            
            // Mở khóa tất cả các trường
            txtHoTen.ReadOnly = false;
            txtCCCD.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            
            // Đổi màu nền về mặc định
            txtHoTen.BackColor = Color.White;
            txtCCCD.BackColor = Color.White;
            txtSDT.BackColor = Color.White;
            txtDiaChi.BackColor = Color.White;
            
            // Focus vào trường họ tên
            txtHoTen.Focus();
        }

        // Debug method để kiểm tra database
        private void TestDatabaseConnection()
        {
            try
            {
                string testQuery = "SELECT COUNT(*) FROM KHACHHANG";
                object result = DataProvider.ThucThiScalar(testQuery);
                MessageBox.Show($"Kết nối database thành công!\nSố khách hàng trong database: {result}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Hiển thị tất cả CCCD trong database
                string allCCCDQuery = "SELECT TOP 10 CCCD, HoTen FROM KHACHHANG";
                DataTable dtAll = DataProvider.ThucThiTruyVan(allCCCDQuery);
                
                string cccdList = "Danh sách CCCD trong database:\n";
                foreach (DataRow row in dtAll.Rows)
                {
                    cccdList += $"CCCD: '{row["CCCD"]}' - Họ tên: {row["HoTen"]}\n";
                }
                
                MessageBox.Show(cccdList, "Debug - Danh sách CCCD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối database: {ex.Message}", "Debug Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
