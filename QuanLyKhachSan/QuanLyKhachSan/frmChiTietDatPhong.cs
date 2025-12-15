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
    public partial class frmChiTietDatPhong : Form
    {
        private int idPhieuDat;

        public frmChiTietDatPhong(int idPhieuDat)
        {
            InitializeComponent();
            this.idPhieuDat = idPhieuDat;
            
            // Thiết lập DataGridView
            SetupDataGridViews();
        }

        private void SetupDataGridViews()
        {
            // Thiết lập DataGridView Phòng
            dgvPhong.AutoGenerateColumns = false;
            dgvPhong.Columns.Clear();
            
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IDPhong",
                HeaderText = "Số phòng",
                DataPropertyName = "IDPhong",
              
            });
            
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenLoaiPhong",
                HeaderText = "Loại phòng",
                DataPropertyName = "TenLoaiPhong",
            
            });
            
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoNguoi",
                HeaderText = "Số người",
                DataPropertyName = "SoNguoi",
               
            });
            
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DonGia",
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
             
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dgvPhong.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvPhong.MultiSelect = false;
            dgvPhong.ClearSelection();
            // Thiết lập DataGridView Dịch vụ
            dgvDichVu.AutoGenerateColumns = false;
            dgvDichVu.Columns.Clear();
            
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenDichVu",
                HeaderText = "Tên dịch vụ",
                DataPropertyName = "TenDichVu",
                Width = 150
            });
            
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số lượng",
                DataPropertyName = "SoLuong",
                Width = 80
            });
            
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DonGia",
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ThanhTien",
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            dgvDichVu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDichVu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dgvDichVu.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvDichVu.MultiSelect = false;
        }

        private void frmChiTietDatPhong_Load(object sender, EventArgs e)
        {
            try
            {
                LoadThongTinPhieu();
                LoadThongTinKhachHang();
                LoadThongTinPhong();
                LoadDichVu();
                TinhTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load chi tiết phiếu đặt phòng: {ex.Message}", 
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThongTinPhieu()
        {
            try
            {
                // Sửa lại query - bỏ JOIN với bảng NHANVIEN không tồn tại
                string sql = $@"
                    SELECT 
                        p.IDPhieuDat,
                        p.NgayLapPhieu,
                        p.TrangThai,
                        p.UsernameNV
                    FROM PHIEUDATPHONG p
                    WHERE p.IDPhieuDat = {idPhieuDat}";

                DataTable dt = DataProvider.ThucThiTruyVan(sql);
                
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtSoPhieu.Text = row["IDPhieuDat"].ToString();
                    txtNgayLap.Text = Convert.ToDateTime(row["NgayLapPhieu"]).ToString("dd/MM/yyyy HH:mm");
                    txtTrangThai.Text = row["TrangThai"].ToString();
                    
                    // Hiển thị username nhân viên (không có bảng NHANVIEN)
                    string usernameNV = row["UsernameNV"] != DBNull.Value ? row["UsernameNV"].ToString() : "N/A";
                    txtNhanVien.Text = usernameNV;
                    
                    Console.WriteLine($"Loaded phiếu {idPhieuDat}: {row["TrangThai"]} - NV: {usernameNV}");
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy phiếu đặt phòng ID: {idPhieuDat}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin phiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Chi tiết lỗi LoadThongTinPhieu: {ex}");
            }
        }

        private void LoadThongTinKhachHang()
        {
            string sql = $@"
                SELECT 
                    k.HoTen,
                    k.CCCD,
                    k.SoDienThoai,
                    k.DiaChi
                FROM PHIEUDATPHONG p
                JOIN KHACHHANG k ON p.IDKhachHang = k.IDKhachHang
                WHERE p.IDPhieuDat = {idPhieuDat}";

            DataTable dt = DataProvider.ThucThiTruyVan(sql);
            
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtHoTen.Text = row["HoTen"].ToString();
                txtCCCD.Text = row["CCCD"].ToString();
                txtSDT.Text = row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "";
                txtDiaChi.Text = row["DiaChi"] != DBNull.Value ? row["DiaChi"].ToString() : "";
            }
        }

        private void LoadThongTinPhong()
        {
            string sql = $@"
                SELECT 
                    p.NgayCheckIn,
                    p.NgayCheckOut,
                    p.SoNguoi,
                    ct.IDPhong,
                    lp.TenLoaiPhong,
                    ct.SoNguoi AS SoNguoiPhong,
                    ct.DonGia
                FROM PHIEUDATPHONG p
                JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                JOIN PHONG ph ON ct.IDPhong = ph.IDPhong
                JOIN LOAIPHONG lp ON ph.IDLoaiPhong = lp.IDLoaiPhong
                WHERE p.IDPhieuDat = {idPhieuDat}";

            DataTable dt = DataProvider.ThucThiTruyVan(sql);
            
            if (dt.Rows.Count > 0)
            {
                DataRow firstRow = dt.Rows[0];
                
                // Thông tin chung
                DateTime ngayCheckIn = Convert.ToDateTime(firstRow["NgayCheckIn"]);
                DateTime ngayCheckOut = Convert.ToDateTime(firstRow["NgayCheckOut"]);
                
                txtNgayNhanPhong.Text = ngayCheckIn.ToString("dd/MM/yyyy HH:mm");
                txtNgayTraPhong.Text = ngayCheckOut.ToString("dd/MM/yyyy HH:mm");
                
                // Tính số giờ ở
                TimeSpan soGioO = ngayCheckOut - ngayCheckIn;
                txtSoGioO.Text = $"{soGioO.TotalHours:F1} giờ";
                
                // Tổng số người
                int tongSoNguoi = Convert.ToInt32(firstRow["SoNguoi"]);
                txtSoNguoi.Text = tongSoNguoi.ToString();
                
                // Load danh sách phòng
                dgvPhong.DataSource = dt;
            }
        }

        private void LoadDichVu()
        {
            try
            {
                Console.WriteLine($"=== LoadDichVu cho phiếu {idPhieuDat} ===");
                
                // Query đơn giản và an toàn - lấy dữ liệu từ CHITIET_DICHVU và JOIN với DICHVU
                string sql = $@"
                    SELECT 
                        ISNULL(dv.TenDichVu, 'Dịch vụ ' + CAST(ct.IDDichVu AS VARCHAR)) AS TenDichVu,
                        ct.SoLuong,
                        ISNULL(ct.DonGia, 0) AS DonGia,
                        (ct.SoLuong * ISNULL(ct.DonGia, 0)) AS ThanhTien
                    FROM CHITIET_DICHVU ct
                    LEFT JOIN DICHVU dv ON ct.IDDichVu = dv.IDDichVu
                    WHERE ct.IDPhieuDat = {idPhieuDat}
                    ORDER BY dv.TenDichVu";
                
                DataTable dt = DataProvider.ThucThiTruyVan(sql);
                
                if (dt.Rows.Count > 0)
                {
                    dgvDichVu.DataSource = dt;
                    
                    // Debug: Hiển thị dữ liệu
                    Console.WriteLine($"Hiển thị {dt.Rows.Count} dịch vụ:");
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"- {row["TenDichVu"]}: {row["SoLuong"]} x {Convert.ToDecimal(row["DonGia"]):N0} = {Convert.ToDecimal(row["ThanhTien"]):N0} VNĐ");
                    }
                }
                else
                {
                    Console.WriteLine("Không có dịch vụ nào cho phiếu này");
                    dgvDichVu.DataSource = CreateEmptyDichVuTable();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi LoadDichVu: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi khi tải dịch vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvDichVu.DataSource = CreateEmptyDichVuTable();
            }
        }
        
        private DataTable CreateEmptyDichVuTable()
        {
            DataTable emptyDt = new DataTable();
            emptyDt.Columns.Add("TenDichVu", typeof(string));
            emptyDt.Columns.Add("SoLuong", typeof(int));
            emptyDt.Columns.Add("DonGia", typeof(decimal));
            emptyDt.Columns.Add("ThanhTien", typeof(decimal));
            return emptyDt;
        }

        private void TinhTongTien()
        {
            try
            {
                Console.WriteLine($"=== TinhTongTien cho phiếu {idPhieuDat} ===");
                
                // Tính tiền phòng
                string sqlTienPhong = $@"
                    SELECT ISNULL(SUM(ct.DonGia), 0) AS TienPhong
                    FROM CHITIET_PHIEUDATPHONG ct
                    WHERE ct.IDPhieuDat = {idPhieuDat}";
                
                DataTable dtTienPhong = DataProvider.ThucThiTruyVan(sqlTienPhong);
                decimal tienPhong = 0;
                if (dtTienPhong.Rows.Count > 0 && dtTienPhong.Rows[0]["TienPhong"] != DBNull.Value)
                {
                    tienPhong = Convert.ToDecimal(dtTienPhong.Rows[0]["TienPhong"]);
                }
                Console.WriteLine($"Tiền phòng: {tienPhong:N0} VNĐ");

                // Tính tiền dịch vụ - dùng DonGia từ CHITIET_DICHVU
                string sqlTienDichVu = $@"
                    SELECT ISNULL(SUM(ct.SoLuong * ct.DonGia), 0) AS TienDichVu
                    FROM CHITIET_DICHVU ct
                    WHERE ct.IDPhieuDat = {idPhieuDat}";
                
                DataTable dtTienDichVu = DataProvider.ThucThiTruyVan(sqlTienDichVu);
                decimal tienDichVu = 0;
                if (dtTienDichVu.Rows.Count > 0 && dtTienDichVu.Rows[0]["TienDichVu"] != DBNull.Value)
                {
                    tienDichVu = Convert.ToDecimal(dtTienDichVu.Rows[0]["TienDichVu"]);
                }
                Console.WriteLine($"Tiền dịch vụ: {tienDichVu:N0} VNĐ");

                // Debug: Hiển thị thông tin chi tiết
                Console.WriteLine($"=== KẾT QUẢ TÍNH TIỀN ===");
                Console.WriteLine($"- Tiền phòng: {tienPhong:N0} VNĐ");
                Console.WriteLine($"- Tiền dịch vụ: {tienDichVu:N0} VNĐ");
                Console.WriteLine($"- Tổng cộng: {(tienPhong + tienDichVu):N0} VNĐ");

                // Hiển thị
                txtTienPhong.Text = tienPhong.ToString("N0") + " VNĐ";
                txtTienDichVu.Text = tienDichVu.ToString("N0") + " VNĐ";
                txtTongTien.Text = "Tổng Tiền: "+(tienPhong + tienDichVu).ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi TinhTongTien: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi khi tính tổng tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Hiển thị giá trị mặc định khi có lỗi
                txtTienPhong.Text = "0 VNĐ";
                txtTienDichVu.Text = "0 VNĐ";
                txtTongTien.Text = "0 VNĐ";
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement print functionality
                MessageBox.Show("Chức năng in sẽ được phát triển trong phiên bản tiếp theo.", 
                               "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm method để refresh dữ liệu
        public void RefreshData()
        {
            try
            {
                LoadDichVu();
                TinhTongTien();
                Console.WriteLine($"Đã refresh dữ liệu cho phiếu {idPhieuDat}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi refresh: {ex.Message}");
            }
        }

        // Override để xử lý khi form được focus lại
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            RefreshData(); // Tự động refresh khi form được focus
        }
    }
}