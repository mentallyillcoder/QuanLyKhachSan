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
           
            string query = $"SELECT IDPhieuDat FROM PHIEUDATPHONG WHERE IDPhong = '{maPhongGoc}' AND TrangThai = N'Đã check-in'";
            DataTable dt = DataProvider.ThucThiTruyVan(query);

            if (dt.Rows.Count > 0)
            {
                // Lưu lại ID phiếu để dùng cho nút Xác nhận
                this.idPhieuDatHienTai = Convert.ToInt32(dt.Rows[0]["IDPhieuDat"]);
            }
            else
            {
                MessageBox.Show("Lỗi: Không tìm thấy phiếu đặt phòng đang hoạt động!");
                this.Close();
            }
        }

        void LoadComboBoxPhongTrong()
        {
            string query = "SELECT IDPhong, TenPhong FROM PHONG WHERE TrangThai = N'Trống'";
            DataTable dt = DataProvider.ThucThiTruyVan(query);

            cboPhongDich.DataSource = dt;
            cboPhongDich.DisplayMember = "TenPhong";
            cboPhongDich.ValueMember = "IDPhong";

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
                //chuyển phòng
                string query1 = $"UPDATE PHIEUDATPHONG SET IDPhong = '{maPhongDich}' WHERE IDPhieuDat = {this.idPhieuDatHienTai}";
                string query2 = $"UPDATE PHONG SET TrangThai = N'Đang dọn dẹp' WHERE IDPhong = '{this.maPhongGoc}'";
                string query3 = $"UPDATE PHONG SET TrangThai = N'Đang thuê' WHERE IDPhong = '{maPhongDich}'";

                DataProvider.ThucThiLenh(query1);
                DataProvider.ThucThiLenh(query2);
                DataProvider.ThucThiLenh(query3);

                MessageBox.Show("Chuyển phòng thành công!");
                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển phòng: " + ex.Message);
            }
        }

       
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
