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
            TimIDPhieuDat();
            LoadComboBoxDichVu();
        }
        void TimIDPhieuDat()
        {
            try
            {
                string query = $"SELECT IDPhieuDat FROM PHIEUDATPHONG WHERE IDPhong = '{maPhong}' AND TrangThai = N'Đã check-in'";
                DataTable dt = DataProvider.ThucThiTruyVan(query);
                if (dt.Rows.Count > 0)
                {
                    this.idPhieuDatHienTai = Convert.ToInt32(dt.Rows[0]["IDPhieuDat"]);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tìm thấy phiếu đặt phòng đang hoạt động cho phòng này!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm phiếu đặt phòng: " + ex.Message);
                this.Close();
            }
        }

        // Hàm tải dịch vụ vào ComboBox
        void LoadComboBoxDichVu()
        {
            string query = "SELECT IDDichVu, TenDichVu, DonGia FROM DICHVU";
            DataTable dt = DataProvider.ThucThiTruyVan(query);

            cboDichVu.DataSource = dt;
            cboDichVu.DisplayMember = "TenDichVu"; 
            cboDichVu.ValueMember = "IDDichVu";
            
            if (cboDichVu.Items.Count > 0)
            {
                TinhTien();
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
                }
            }
            catch { }
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
                // 1. Lấy thông tin từ form
                int idDichVu = Convert.ToInt32(cboDichVu.SelectedValue);
                int soLuong = (int)nudSoLuong.Value;

                // 2. Lấy đơn giá từ ComboBox
                DataRowView drv = (DataRowView)cboDichVu.SelectedItem;
                decimal donGia = Convert.ToDecimal(drv["DonGia"]);

                // 3. Tính toán
                decimal thanhTien = soLuong * donGia;

                // 4. INSERT vào database
                string query = $"INSERT INTO CHITIET_DICHVU (IDPhieuDat, IDDichVu, SoLuong, ThanhTien) " +
                               $"VALUES ({this.idPhieuDatHienTai}, {idDichVu}, {soLuong}, {thanhTien})";

                DataProvider.ThucThiLenh(query);

                MessageBox.Show("Thêm dịch vụ thành công!");
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
