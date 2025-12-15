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
    public partial class frmChuyenPhong : Form
    {
        
        private string maPhongGoc;
        private int idPhieuDatHienTai;

       
        public frmChuyenPhong(string idPhongGoc)
        {
            InitializeComponent(); 
            this.maPhongGoc = idPhongGoc;
        }

      
        private void frmChuyenPhong_Load(object sender, EventArgs e)
        {
            
            lbPhongGoc.Text = this.maPhongGoc;
            TimIDPhieuDat();
            LoadComboBoxPhongTrong();
        }

        void TimIDPhieuDat()
        {
            try
            {
                // Tìm phiếu đặt phòng đang hoạt động cho phòng này
                string query = $@"
                    SELECT DISTINCT p.IDPhieuDat, p.TrangThai, k.HoTen
                    FROM PHIEUDATPHONG p
                    JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                    JOIN KHACHHANG k ON p.IDKhachHang = k.IDKhachHang
                    WHERE ct.IDPhong = '{maPhongGoc}' 
                    AND (p.TrangThai LIKE N'%check-in%' OR p.TrangThai = N'Đã check-in')
                    ORDER BY p.IDPhieuDat DESC";

                DataTable dt = DataProvider.ThucThiTruyVan(query);

                if (dt.Rows.Count > 0)
                {
                    // Lưu lại ID phiếu để dùng cho nút Xác nhận
                    this.idPhieuDatHienTai = Convert.ToInt32(dt.Rows[0]["IDPhieuDat"]);
                    string trangThai = dt.Rows[0]["TrangThai"].ToString();
                    string hoTen = dt.Rows[0]["HoTen"].ToString();
                    
                    Console.WriteLine($"Tìm thấy phiếu {this.idPhieuDatHienTai} cho phòng {maPhongGoc} - Khách: {hoTen} - Trạng thái: {trangThai}");
                    
                    // Hiển thị thông tin khách hàng
                    this.Text = $"Chuyển phòng {maPhongGoc} - Khách: {hoTen}";
                }
                else
                {
                    // Thử tìm với các trạng thái khác
                    string queryBackup = $@"
                        SELECT DISTINCT p.IDPhieuDat, p.TrangThai, k.HoTen
                        FROM PHIEUDATPHONG p
                        JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                        JOIN KHACHHANG k ON p.IDKhachHang = k.IDKhachHang
                        WHERE ct.IDPhong = '{maPhongGoc}' 
                        AND p.TrangThai NOT IN (N'Đã check-out', N'Đã hủy')
                        ORDER BY p.IDPhieuDat DESC";
                    
                    DataTable dtBackup = DataProvider.ThucThiTruyVan(queryBackup);
                    
                    if (dtBackup.Rows.Count > 0)
                    {
                        this.idPhieuDatHienTai = Convert.ToInt32(dtBackup.Rows[0]["IDPhieuDat"]);
                        string trangThai = dtBackup.Rows[0]["TrangThai"].ToString();
                        string hoTen = dtBackup.Rows[0]["HoTen"].ToString();
                        
                        MessageBox.Show($"Phòng {maPhongGoc} có phiếu đặt với trạng thái: {trangThai}\n" +
                                       $"Khách hàng: {hoTen}\n\n" +
                                       "Vẫn có thể chuyển phòng.", 
                                       "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.Text = $"Chuyển phòng {maPhongGoc} - Khách: {hoTen}";
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi: Không tìm thấy phiếu đặt phòng đang hoạt động cho phòng {maPhongGoc}!\n\n" +
                                       "Phòng này có thể chưa được đặt hoặc đã check-out.", 
                                       "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm phiếu đặt phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Chi tiết lỗi TimIDPhieuDat: {ex}");
                this.Close();
            }
        }

        void LoadComboBoxPhongTrong()
        {
            try
            {
                // Lấy danh sách phòng trống (loại trừ phòng hiện tại)
                string query = $@"
                    SELECT p.IDPhong, 
                           CONCAT(p.IDPhong, ' - ', lp.TenLoaiPhong) AS TenPhong
                    FROM PHONG p
                    JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong
                    WHERE p.TrangThai = N'Trống' 
                    AND p.IDPhong != '{maPhongGoc}'
                    ORDER BY p.IDPhong";

                DataTable dt = DataProvider.ThucThiTruyVan(query);

                if (dt.Rows.Count > 0)
                {
                    cboPhongDich.DataSource = dt;
                    cboPhongDich.DisplayMember = "TenPhong";
                    cboPhongDich.ValueMember = "IDPhong";
                    
                    Console.WriteLine($"Tìm thấy {dt.Rows.Count} phòng trống có thể chuyển đến");
                }
                else
                {
                    MessageBox.Show("Không có phòng trống nào để chuyển đến!\n\nVui lòng thử lại sau khi có phòng trống.", 
                                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng trống: {ex.Message}", 
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Chi tiết lỗi LoadComboBoxPhongTrong: {ex}");
                this.Close();
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cboPhongDich.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng để chuyển đến!");
                return;
            }

            string maPhongDich = cboPhongDich.SelectedValue.ToString();

            try
            {
                // Kiểm tra phòng đích có trống không
                string checkQuery = $"SELECT TrangThai FROM PHONG WHERE IDPhong = '{maPhongDich}'";
                DataTable dtCheck = DataProvider.ThucThiTruyVan(checkQuery);
                
                if (dtCheck.Rows.Count == 0)
                {
                    MessageBox.Show("Phòng đích không tồn tại!");
                    return;
                }
                
                string trangThaiPhongDich = dtCheck.Rows[0]["TrangThai"].ToString();
                if (trangThaiPhongDich != "Trống")
                {
                    MessageBox.Show($"Phòng {maPhongDich} không trống (Trạng thái: {trangThaiPhongDich})!\nVui lòng chọn phòng khác.");
                    return;
                }

                // Xác nhận chuyển phòng
                DialogResult result = MessageBox.Show(
                    $"Xác nhận chuyển từ phòng {maPhongGoc} sang phòng {maPhongDich}?", 
                    "Xác nhận chuyển phòng", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                
                if (result != DialogResult.Yes)
                    return;

                // Thực hiện chuyển phòng
                // 1. Cập nhật phòng trong chi tiết phiếu đặt phòng
                string query1 = $"UPDATE CHITIET_PHIEUDATPHONG SET IDPhong = '{maPhongDich}' WHERE IDPhieuDat = {this.idPhieuDatHienTai} AND IDPhong = '{this.maPhongGoc}'";
                
                // 2. Cập nhật trạng thái phòng gốc
                string query2 = $"UPDATE PHONG SET TrangThai = N'Đang dọn dẹp' WHERE IDPhong = '{this.maPhongGoc}'";
                
                // 3. Cập nhật trạng thái phòng đích
                string query3 = $"UPDATE PHONG SET TrangThai = N'Đang thuê' WHERE IDPhong = '{maPhongDich}'";

                Console.WriteLine($"Chuyển phòng: {maPhongGoc} -> {maPhongDich} (Phiếu: {this.idPhieuDatHienTai})");

                DataProvider.ThucThiLenh(query1);
                DataProvider.ThucThiLenh(query2);
                DataProvider.ThucThiLenh(query3);

                MessageBox.Show($"✅ Chuyển phòng thành công!\n\n" +
                               $"Từ phòng: {maPhongGoc}\n" +
                               $"Sang phòng: {maPhongDich}\n\n" +
                               $"Phòng {maPhongGoc} đã chuyển sang trạng thái 'Đang dọn dẹp'\n" +
                               $"Phòng {maPhongDich} đã chuyển sang trạng thái 'Đang thuê'", 
                               "Chuyển phòng thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi chuyển phòng: {ex.Message}\n\nChi tiết: {ex.StackTrace}", 
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Lỗi chuyển phòng: {ex}");
            }
        }

       
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
