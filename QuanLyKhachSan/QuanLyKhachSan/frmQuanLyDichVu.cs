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

    public partial class frmQuanLyDichVu : Form
    {
        public frmQuanLyDichVu()
        {
            InitializeComponent();
        }

        
        private void frmQuanLyDichVu_Load(object sender, EventArgs e)
        {
            txtMaDV.ReadOnly = true; 
            txtMaDV.Text = "(Tự động)";
            LoadDanhSachDichVu();
        }

        void LoadDanhSachDichVu()
        {
            string query = "SELECT IDDichVu, TenDichVu, DonGia FROM DICHVU";
            DataTable dt = DataProvider.ThucThiTruyVan(query);
            dgvDichVu.DataSource = dt;

        
            dgvDichVu.Columns["IDDichVu"].HeaderText = "Mã Dịch Vụ";
            dgvDichVu.Columns["TenDichVu"].HeaderText = "Tên Dịch Vụ";
            dgvDichVu.Columns["DonGia"].HeaderText = "Đơn Giá";

            //format cho đơn giá
            dgvDichVu.Columns["DonGia"].DefaultCellStyle.Format = "N0";
        }

        
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];

              
                txtMaDV.Text = row.Cells["IDDichVu"].Value.ToString();
                txtTenDV.Text = row.Cells["TenDichVu"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            }
        }

        

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDV.Text = "(Tự động)";
            txtTenDV.Text = "";
            txtDonGia.Text = "";
            txtTenDV.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenDV = txtTenDV.Text.Trim();

            // Kiểm tra xem Đơn giá có phải là SỐ không
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá phải là một con số!");
                txtDonGia.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tenDV))
            {
                MessageBox.Show("Tên dịch vụ không được để trống!");
                return;
            }

            try
            {
                // Thêm dịch vụ mới 
                string query = $"INSERT INTO DICHVU (TenDichVu, DonGia) " +
                               $"VALUES (N'{tenDV}', {donGia})";
                DataProvider.ThucThiLenh(query);

                MessageBox.Show("Thêm dịch vụ mới thành công!");
                LoadDanhSachDichVu(); 
                btnLamMoi_Click(sender, e); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDV.Text == "(Tự động)")
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ từ danh sách để sửa.");
                return;
            }

            int idDV = Convert.ToInt32(txtMaDV.Text);
            string tenDV = txtTenDV.Text.Trim();

            // Kiểm tra xem Đơn giá có phải là SỐ không
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá phải là một con số!");
                txtDonGia.Focus();
                return;
            }

            try
            {
                string query = $"UPDATE DICHVU SET TenDichVu = N'{tenDV}', DonGia = {donGia} " +
                               $"WHERE IDDichVu = {idDV}";
                DataProvider.ThucThiLenh(query);

                MessageBox.Show("Cập nhật dịch vụ thành công!");
                LoadDanhSachDichVu(); 
                btnLamMoi_Click(sender, e); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDV.Text == "(Tự động)")
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ để xóa.");
                return;
            }

            int idDV = Convert.ToInt32(txtMaDV.Text);

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM DICHVU WHERE IDDichVu = {idDV}";
                    DataProvider.ThucThiLenh(query);

                    MessageBox.Show("Xóa dịch vụ thành công!");
                    LoadDanhSachDichVu(); 
                    btnLamMoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    // Lỗi xảy ra nếu dịch vụ đã được thêm vào chi tiết (khóa ngoại)
                    MessageBox.Show("Lỗi khi xóa: Dịch vụ này đã được sử dụng, không thể xóa.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
