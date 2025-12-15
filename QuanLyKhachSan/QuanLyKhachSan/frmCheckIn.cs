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
    public partial class frmCheckIn : Form
    {
        private string maPhong;
        private int idPhieuDat;

        public frmCheckIn(string idPhong)
        {
            InitializeComponent();
            this.maPhong = idPhong;
        }

        private void frmCheckIn_Load(object sender, EventArgs e)
        {
            LoadThongTinPhieuDat();
        }

        private void LoadThongTinPhieuDat()
        {
            try
            {
                // Bước 1: Lấy phiếu đặt phòng (chỉ lấy phiếu đang hoạt động)
                string queryPhieu = $@"
                    SELECT TOP 1 p.IDPhieuDat, p.IDKhachHang, p.NgayLapPhieu, p.NgayCheckIn, p.TrangThai
                    FROM CHITIET_PHIEUDATPHONG ct
                    JOIN PHIEUDATPHONG p ON ct.IDPhieuDat = p.IDPhieuDat
                    WHERE ct.IDPhong = '{this.maPhong}'
                    AND p.TrangThai NOT IN (N'Đã check-out', N'Đã hủy')
                    AND p.TrangThai NOT LIKE N'%check-in%'
                    ORDER BY p.IDPhieuDat DESC";

                DataTable dtPhieu = DataProvider.ThucThiTruyVan(queryPhieu);

                if (dtPhieu.Rows.Count == 0)
                {
                    // Debug: Kiểm tra chi tiết lỗi
                    string msg = $"Không tìm thấy phiếu đặt phòng cho phòng [{this.maPhong}]!\n\n";
                    
                    // Kiểm tra có phiếu nào không
                    string queryDebug1 = $@"SELECT IDPhieuDat, TrangThai FROM PHIEUDATPHONG";
                    DataTable dtDebug1 = DataProvider.ThucThiTruyVan(queryDebug1);
                    msg += $"Tổng số phiếu trong PHIEUDATPHONG: {dtDebug1.Rows.Count}\n\n";
                    
                    // Kiểm tra chi tiết phòng
                    string queryDebug2 = $@"SELECT IDPhieuDat, IDPhong FROM CHITIET_PHIEUDATPHONG WHERE IDPhong = '{this.maPhong}'";
                    DataTable dtDebug2 = DataProvider.ThucThiTruyVan(queryDebug2);
                    msg += $"Số chi tiết cho phòng {this.maPhong}: {dtDebug2.Rows.Count}\n";
                    if (dtDebug2.Rows.Count > 0)
                    {
                        foreach (DataRow r in dtDebug2.Rows)
                        {
                            msg += $"- Chi tiết: Phiếu {r["IDPhieuDat"]}, Phòng {r["IDPhong"]}\n";
                        }
                    }
                    
                    // Kiểm tra JOIN
                    string queryDebug3 = $@"
                        SELECT p.IDPhieuDat, p.TrangThai, ct.IDPhong, k.HoTen
                        FROM PHIEUDATPHONG p
                        LEFT JOIN CHITIET_PHIEUDATPHONG ct ON p.IDPhieuDat = ct.IDPhieuDat
                        LEFT JOIN KHACHHANG k ON p.IDKhachHang = k.IDKhachHang
                        WHERE ct.IDPhong = '{this.maPhong}'";
                    DataTable dtDebug3 = DataProvider.ThucThiTruyVan(queryDebug3);
                    msg += $"\nKết quả JOIN: {dtDebug3.Rows.Count} dòng\n";
                    
                    MessageBox.Show("Không tìm thấy phiếu đặt phòng cho phòng này!", "Thông báo");
                    this.Close();
                    return;
                }

                DataRow rowPhieu = dtPhieu.Rows[0];
                this.idPhieuDat = Convert.ToInt32(rowPhieu["IDPhieuDat"]);
                int idKhachHang = Convert.ToInt32(rowPhieu["IDKhachHang"]);
                
                // Kiểm tra trạng thái phiếu
                string trangThaiPhieu = rowPhieu["TrangThai"].ToString().Trim();
                if (trangThaiPhieu.Contains("check-in"))
                {
                    MessageBox.Show("Phiếu này đã check-in rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                if (trangThaiPhieu.Contains("check-out") || trangThaiPhieu.Contains("hủy"))
                {
                    MessageBox.Show("Phiếu này đã hoàn tất hoặc bị hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                // Lấy thông tin phòng và đơn giá
                string queryPhong = $@"
                    SELECT ph.TenPhong, lp.TenLoaiPhong, lp.DonGia
                    FROM PHONG ph
                    JOIN LOAIPHONG lp ON ph.IDLoaiPhong = lp.IDLoaiPhong
                    WHERE ph.IDPhong = '{this.maPhong}'";
                DataTable dtPhong = DataProvider.ThucThiTruyVan(queryPhong);
                
                // Hiển thị thông tin
                if (dtPhong.Rows.Count > 0)
                {
                    lblPhong.Text = dtPhong.Rows[0]["TenPhong"].ToString();
                    lblLoaiPhong.Text = dtPhong.Rows[0]["TenLoaiPhong"].ToString();
                    lblDonGia.Text = Convert.ToDecimal(dtPhong.Rows[0]["DonGia"]).ToString("N0") + " VNĐ/đêm";
                }
                else
                {
                    lblPhong.Text = this.maPhong;
                    lblLoaiPhong.Text = "N/A";
                    lblDonGia.Text = "0 VNĐ/đêm";
                }
                
                // Bước 3: Lấy thông tin khách hàng
                string queryKH = $"SELECT HoTen, CCCD, SoDienThoai FROM KHACHHANG WHERE IDKhachHang = {idKhachHang}";
                DataTable dtKH = DataProvider.ThucThiTruyVan(queryKH);
                
                if (dtKH.Rows.Count > 0)
                {
                    DataRow rowKH = dtKH.Rows[0];
                    lblTenKhach.Text = rowKH["HoTen"].ToString();
                    
                    // Hiển thị CCCD
                    string cccd = rowKH["CCCD"] != DBNull.Value ? rowKH["CCCD"].ToString().Trim() : "";
                    
                    // Nếu rỗng thì hiển thị N/A (sẽ được cập nhật khi check-in)
                    if (string.IsNullOrEmpty(cccd))
                    {
                        lblCCCD.Text = "N/A";
                    }
                    else
                    {
                        lblCCCD.Text = cccd;
                    }
                    
                    lblSoDienThoai.Text = rowKH["SoDienThoai"] != DBNull.Value ? rowKH["SoDienThoai"].ToString() : "";
                }
                else
                {
                    lblTenKhach.Text = "N/A";
                    lblCCCD.Text = "N/A";
                    lblSoDienThoai.Text = "N/A";
                }
                
                lblNgayDat.Text = Convert.ToDateTime(rowPhieu["NgayLapPhieu"]).ToString("dd/MM/yyyy HH:mm");
                
                // Ngày check-in dự kiến
                if (rowPhieu["NgayCheckIn"] != DBNull.Value)
                {
                    dtpNgayCheckIn.Value = Convert.ToDateTime(rowPhieu["NgayCheckIn"]);
                }
                else
                {
                    dtpNgayCheckIn.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message, "Lỗi");
                this.Close();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy CCCD đã lưu khi đặt phòng
                string cccdDaDat = lblCCCD.Text.Trim();
                bool chuaCoCCCD = (cccdDaDat == "N/A" || string.IsNullOrEmpty(cccdDaDat));
                
                // Nếu chưa có CCCD - Cho phép nhập nhưng cảnh báo
                if (chuaCoCCCD)
                {
                    DialogResult result = MessageBox.Show(
                        "⚠️ CẢNH BÁO: THIẾU THÔNG TIN CCCD\n\n" +
                        "Khách hàng chưa có CCCD trong hệ thống.\n" +
                        "Điều này vi phạm quy trình đặt phòng chuẩn.\n\n" +
                        "Bạn có muốn NHẬP CCCD NGAY BÂY GIỜ để tiếp tục check-in không?\n\n" +
                        "⚠️ Lưu ý: Nên yêu cầu khách hàng cung cấp CCCD thật!", 
                        "Thiếu thông tin CCCD", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Warning);
                    
                    if (result == DialogResult.No)
                    {
                        return; // Hủy check-in
                    }
                    
                    // Cho phép nhập CCCD lần đầu
                    string cccdMoi = Microsoft.VisualBasic.Interaction.InputBox(
                        "📝 NHẬP CCCD LẦN ĐẦU\n\n" +
                        "Vui lòng nhập số CCCD của khách hàng:\n\n" +
                        "⚠️ Lưu ý: Phải là CCCD thật của khách hàng!", 
                        "Nhập CCCD", 
                        "", 
                        -1, -1);
                    
                    if (string.IsNullOrWhiteSpace(cccdMoi))
                    {
                        MessageBox.Show("❌ Bạn chưa nhập CCCD!\n\nKhông thể check-in.", 
                                       "Thông báo", 
                                       MessageBoxButtons.OK, 
                                       MessageBoxIcon.Warning);
                        return;
                    }
                    
                    cccdMoi = cccdMoi.Trim();
                    
                    // Cập nhật CCCD vào database
                    string queryGetKH = $@"
                        SELECT IDKhachHang 
                        FROM PHIEUDATPHONG 
                        WHERE IDPhieuDat = {this.idPhieuDat}";
                    DataTable dtKH = DataProvider.ThucThiTruyVan(queryGetKH);
                    
                    if (dtKH.Rows.Count > 0)
                    {
                        int idKhachHang = Convert.ToInt32(dtKH.Rows[0]["IDKhachHang"]);
                        
                        string sqlUpdateKH = $@"
                            UPDATE KHACHHANG 
                            SET CCCD = '{cccdMoi}' 
                            WHERE IDKhachHang = {idKhachHang}";
                        
                        DataProvider.ThucThiLenh(sqlUpdateKH);
                        lblCCCD.Text = cccdMoi;
                        cccdDaDat = cccdMoi; // Cập nhật biến để dùng cho check-in
                    }
                    
                    MessageBox.Show("✅ Đã cập nhật CCCD!\n\n" +
                                   $"CCCD: {cccdMoi}\n" +
                                   $"Khách hàng: {lblTenKhach.Text}\n\n" +
                                   "Đang tiến hành check-in...", 
                                   "Cập nhật thành công", 
                                   MessageBoxButtons.OK, 
                                   MessageBoxIcon.Information);
                    
                    // Tiếp tục check-in mà không cần xác minh lại
                    goto SkipVerification;
                }
                
                // Hiển thị hộp thoại nhập CCCD để xác minh
                string cccdNhap = Microsoft.VisualBasic.Interaction.InputBox(
                    "🔐 XÁC MINH DANH TÍNH\n\n" +
                    $"Vui lòng nhập số CCCD để xác minh:\n\n" +
                    $"CCCD đã đăng ký: {cccdDaDat}", 
                    "Xác minh CCCD", 
                    "", 
                    -1, -1);
                
                // Kiểm tra nếu người dùng hủy hoặc không nhập
                if (string.IsNullOrWhiteSpace(cccdNhap))
                {
                    MessageBox.Show("❌ Bạn chưa nhập CCCD!\n\nVui lòng nhập CCCD để xác minh danh tính.", 
                                   "Thông báo", 
                                   MessageBoxButtons.OK, 
                                   MessageBoxIcon.Warning);
                    return;
                }
                
                cccdNhap = cccdNhap.Trim();
                
                // SO SÁNH CCCD - Phải khớp mới cho check-in
                if (cccdNhap != cccdDaDat)
                {
                    MessageBox.Show("❌ XÁC MINH THẤT BẠI!\n\n" +
                                   $"CCCD bạn nhập: {cccdNhap}\n" +
                                   $"CCCD đã đăng ký: {cccdDaDat}\n\n" +
                                   "Hai số CCCD không khớp. Không thể check-in!", 
                                   "Xác minh thất bại", 
                                   MessageBoxButtons.OK, 
                                   MessageBoxIcon.Error);
                    return;
                }
                
                // Xác minh thành công - Cho phép check-in
                MessageBox.Show("✅ Xác minh thành công!\n\n" +
                               $"CCCD: {cccdNhap}\n" +
                               $"Khách hàng: {lblTenKhach.Text}\n\n" +
                               "Đang tiến hành check-in...", 
                               "Xác minh thành công", 
                               MessageBoxButtons.OK, 
                               MessageBoxIcon.Information);
                
            SkipVerification: // Label để bỏ qua xác minh khi đã nhập CCCD mới
                DateTime ngayCheckIn = dtpNgayCheckIn.Value;

                // Cập nhật trạng thái phiếu đặt phòng
                string sqlUpdatePhieu = $@"
                    UPDATE PHIEUDATPHONG 
                    SET TrangThai = N'Đã check-in', 
                        NgayCheckIn = '{ngayCheckIn.ToString("yyyy-MM-dd HH:mm:ss")}'
                    WHERE IDPhieuDat = {this.idPhieuDat}";

                DataProvider.ThucThiLenh(sqlUpdatePhieu);

                // Cập nhật trạng thái phòng
                string sqlUpdatePhong = $@"
                    UPDATE PHONG 
                    SET TrangThai = N'Đang thuê' 
                    WHERE IDPhong = '{this.maPhong}'";

                DataProvider.ThucThiLenh(sqlUpdatePhong);

                MessageBox.Show("Check-in thành công!", "Thông báo");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi check-in: " + ex.Message, "Lỗi");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xác nhận hủy đặt phòng
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn HỦY đặt phòng này không?\n\n" +
                "Phiếu đặt phòng sẽ bị hủy và phòng sẽ trở về trạng thái trống.",
                "Xác nhận hủy đặt phòng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Cập nhật trạng thái phiếu đặt phòng thành "Đã hủy"
                    string sqlUpdatePhieu = $@"
                        UPDATE PHIEUDATPHONG 
                        SET TrangThai = N'Đã hủy' 
                        WHERE IDPhieuDat = {this.idPhieuDat}";

                    DataProvider.ThucThiLenh(sqlUpdatePhieu);

                    // Cập nhật trạng thái phòng về "Trống"
                    string sqlUpdatePhong = $@"
                        UPDATE PHONG 
                        SET TrangThai = N'Trống' 
                        WHERE IDPhong = '{this.maPhong}'";

                    DataProvider.ThucThiLenh(sqlUpdatePhong);

                    MessageBox.Show("Đã hủy đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
