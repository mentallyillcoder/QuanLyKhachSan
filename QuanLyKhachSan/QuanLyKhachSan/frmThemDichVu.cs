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
    public partial class frmThemDichVu : Form
    {
        private string maPhong;
        private int idPhieuDatHienTai; 

        public frmThemDichVu(string idPhong)
        {
            InitializeComponent();
            this.maPhong = idPhong;
            this.Text = "Thêm dịch vụ cho phòng " + maPhong;
            label1.Text = "Thêm dịch vụ cho phòng " + this.maPhong;
        }

        
        private void frmThemDichVu_Load(object sender, EventArgs e)
        {
            // Debug: Hiển thị thông tin phòng
            DebugPhongInfo();
            TimIDPhieuDat();
            LoadComboBoxDichVu();
        }

        private void DebugPhongInfo()
        {
            try
            {
                // Kiểm tra tất cả phiếu đặt phòng liên quan đến phòng này
                string debugQuery = $@"
                    SELECT 
                        p.IDPhieuDat,
                        p.TrangThai,
                        p.NgayCheckIn,
                        p.NgayCheckOut,
                        k.HoTen
                    FROM PHIEUDATPHONG p
                    JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                    JOIN KHACHHANG k ON p.IDKhachHang = k.IDKhachHang
                    WHERE ct.IDPhong = '{maPhong}'
                    ORDER BY p.IDPhieuDat DESC";
                
                DataTable dtDebug = DataProvider.ThucThiTruyVan(debugQuery);
                
                Console.WriteLine($"=== DEBUG: Thông tin phòng {maPhong} ===");
                Console.WriteLine($"Số phiếu đặt phòng tìm thấy: {dtDebug.Rows.Count}");
                
                foreach (DataRow row in dtDebug.Rows)
                {
                    Console.WriteLine($"- Phiếu {row["IDPhieuDat"]}: {row["TrangThai"]} - Khách: {row["HoTen"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi debug: {ex.Message}");
            }
        }
        void TimIDPhieuDat()
        {
            try
            {
                // Tìm phiếu đặt phòng đang hoạt động cho phòng này
                string query = $@"
                    SELECT DISTINCT p.IDPhieuDat 
                    FROM PHIEUDATPHONG p
                    JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                    WHERE ct.IDPhong = '{maPhong}' 
                    AND (p.TrangThai LIKE N'%check-in%' OR p.TrangThai = N'Đã check-in')
                    ORDER BY p.IDPhieuDat DESC";
                
                DataTable dt = DataProvider.ThucThiTruyVan(query);
                
                if (dt.Rows.Count > 0)
                {
                    this.idPhieuDatHienTai = Convert.ToInt32(dt.Rows[0]["IDPhieuDat"]);
                    Console.WriteLine($"Tìm thấy phiếu đặt phòng ID: {this.idPhieuDatHienTai} cho phòng {maPhong}");
                }
                else
                {
                    // Thử tìm với các trạng thái khác
                    string queryBackup = $@"
                        SELECT DISTINCT p.IDPhieuDat, p.TrangThai
                        FROM PHIEUDATPHONG p
                        JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                        WHERE ct.IDPhong = '{maPhong}' 
                        AND p.TrangThai NOT IN (N'Đã check-out', N'Đã hủy')
                        ORDER BY p.IDPhieuDat DESC";
                    
                    DataTable dtBackup = DataProvider.ThucThiTruyVan(queryBackup);
                    
                    if (dtBackup.Rows.Count > 0)
                    {
                        this.idPhieuDatHienTai = Convert.ToInt32(dtBackup.Rows[0]["IDPhieuDat"]);
                        string trangThai = dtBackup.Rows[0]["TrangThai"].ToString();
                        Console.WriteLine($"Tìm thấy phiếu đặt phòng ID: {this.idPhieuDatHienTai} với trạng thái: {trangThai}");
                        
                        MessageBox.Show($"Phòng {maPhong} có phiếu đặt với trạng thái: {trangThai}\nVẫn có thể thêm dịch vụ.", 
                                       "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi: Không tìm thấy phiếu đặt phòng đang hoạt động cho phòng {maPhong}!\n\n" +
                                       "Phòng này có thể chưa được đặt hoặc đã check-out.", 
                                       "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm phiếu đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Hàm tải dịch vụ vào ComboBox
        void LoadComboBoxDichVu()
        {
            try
            {
                // Thử các tên cột khác nhau để tương thích với database
                string[] possibleQueries = {
                    "SELECT IDDichVu, TenDichVu, DonGia FROM DICHVU",
                    "SELECT IDDichVu, TenDichVu, Gia AS DonGia FROM DICHVU",
                    "SELECT IDDichVu, TenDichVu, GiaTien AS DonGia FROM DICHVU"
                };

                DataTable dt = null;
                foreach (string query in possibleQueries)
                {
                    try
                    {
                        dt = DataProvider.ThucThiTruyVan(query);
                        if (dt.Rows.Count >= 0) // Thành công
                        {
                            Console.WriteLine($"Query thành công: {query}");
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Query thất bại: {query} - {ex.Message}");
                        continue;
                    }
                }

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không thể tải danh sách dịch vụ!\n\nVui lòng kiểm tra:\n1. Database đã được tạo chưa\n2. Bảng DICHVU có dữ liệu chưa\n3. Cột giá có tên đúng không", 
                                   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                cboDichVu.DataSource = dt;
                cboDichVu.DisplayMember = "TenDichVu"; 
                cboDichVu.ValueMember = "IDDichVu";
                
                if (cboDichVu.Items.Count > 0)
                {
                    TinhTien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dịch vụ: {ex.Message}\n\nVui lòng chạy script create_database.sql để tạo database đúng cấu trúc.", 
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        void TinhTien()
        {
            try
            {
                if (cboDichVu.SelectedItem != null)
                {
                    DataRowView drv = (DataRowView)cboDichVu.SelectedItem;
                    decimal donGia = Convert.ToDecimal(drv["DonGia"]);
                    int soLuong = (int)nudSoLuong.Value;
                    decimal thanhTien = donGia * soLuong;

                    lbDonGiaValue.Text = donGia.ToString("N0") + " VNĐ";
                    lbThanhTienValue.Text = thanhTien.ToString("N0") + " VNĐ";
                    
                    // Hiển thị thông tin chi tiết
                    Console.WriteLine($"Tính tiền: {soLuong} x {donGia:N0} = {thanhTien:N0} VNĐ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tính tiền: {ex.Message}");
                lbDonGiaValue.Text = "0 VNĐ";
                lbThanhTienValue.Text = "0 VNĐ";
            }
        }

        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            TinhTien();
        }

       
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã tìm thấy phiếu đặt phòng chưa
                if (this.idPhieuDatHienTai <= 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu đặt phòng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 1. Lấy thông tin từ form
                int idDichVu = Convert.ToInt32(cboDichVu.SelectedValue);
                int soLuong = (int)nudSoLuong.Value;

                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Lấy đơn giá từ ComboBox
                DataRowView drv = (DataRowView)cboDichVu.SelectedItem;
                decimal donGia = Convert.ToDecimal(drv["DonGia"]);
                decimal thanhTien = donGia * soLuong; // Tính thành tiền

                string tenDichVu = drv["TenDichVu"].ToString();

                // 3. Kiểm tra xem dịch vụ này đã được thêm cho phiếu này chưa
                string sqlCheck = $@"
                    SELECT SoLuong, DonGia 
                    FROM CHITIET_DICHVU 
                    WHERE IDPhieuDat = {this.idPhieuDatHienTai} AND IDDichVu = {idDichVu}";
                
                DataTable dtCheck = DataProvider.ThucThiTruyVan(sqlCheck);
                
                if (dtCheck.Rows.Count > 0)
                {
                    // Đã có dịch vụ này, cập nhật số lượng và thành tiền
                    int soLuongCu = Convert.ToInt32(dtCheck.Rows[0]["SoLuong"]);
                    int soLuongMoi = soLuongCu + soLuong;
                    decimal thanhTienMoi = donGia * soLuongMoi;
                    
                    string sqlUpdate = $@"
                        UPDATE CHITIET_DICHVU 
                        SET SoLuong = {soLuongMoi}, 
                            DonGia = {donGia},
                            ThanhTien = {thanhTienMoi}
                        WHERE IDPhieuDat = {this.idPhieuDatHienTai} AND IDDichVu = {idDichVu}";
                    
                    DataProvider.ThucThiLenh(sqlUpdate);
                    
                    MessageBox.Show($"✅ Đã cập nhật dịch vụ: {tenDichVu}\n\n" +
                                   $"Số lượng cũ: {soLuongCu}\n" +
                                   $"Số lượng thêm: +{soLuong}\n" +
                                   $"Số lượng mới: {soLuongMoi}\n\n" +
                                   $"Thành tiền: {thanhTienMoi:N0} VNĐ", 
                                   "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Chưa có dịch vụ này, thêm mới với thành tiền
                    string sqlInsert = $@"
                        INSERT INTO CHITIET_DICHVU (IDPhieuDat, IDDichVu, SoLuong, DonGia, ThanhTien) 
                        VALUES ({this.idPhieuDatHienTai}, {idDichVu}, {soLuong}, {donGia}, {thanhTien})";

                    DataProvider.ThucThiLenh(sqlInsert);
                    
                    MessageBox.Show($"✅ Thêm dịch vụ thành công: {tenDichVu}\n\n" +
                                   $"Số lượng: {soLuong}\n" +
                                   $"Đơn giá: {donGia:N0} VNĐ\n" +
                                   $"Thành tiền: {thanhTien:N0} VNĐ\n\n" +
                                   $"💡 Thành tiền đã được tự động tính và lưu vào hóa đơn!", 
                                   "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 4. Hiển thị tổng tiền dịch vụ hiện tại của phiếu
                string sqlTongTien = $@"
                    SELECT SUM(SoLuong * DonGia) AS TongTienDichVu
                    FROM CHITIET_DICHVU 
                    WHERE IDPhieuDat = {this.idPhieuDatHienTai}";
                
                DataTable dtTongTien = DataProvider.ThucThiTruyVan(sqlTongTien);
                if (dtTongTien.Rows.Count > 0 && dtTongTien.Rows[0]["TongTienDichVu"] != DBNull.Value)
                {
                    decimal tongTienDichVu = Convert.ToDecimal(dtTongTien.Rows[0]["TongTienDichVu"]);
                    Console.WriteLine($"Tổng tiền dịch vụ hiện tại: {tongTienDichVu:N0} VNĐ");
                }

                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi thêm dịch vụ: {ex.Message}\n\n" +
                               "Vui lòng kiểm tra:\n" +
                               "1. Database đã được tạo đúng cấu trúc\n" +
                               "2. Phiếu đặt phòng tồn tại\n" +
                               "3. Dịch vụ được chọn hợp lệ", 
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Chi tiết lỗi: " + ex.ToString());
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
