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
    public partial class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }        
        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadComboBoxLoaiTK();
            LoadDanhSachTaiKhoan();
        }        
        void LoadComboBoxLoaiTK()
        {
            
            cboLoaiTK.Items.Add("Nhân viên"); 
            cboLoaiTK.Items.Add("Quản lý"); 
            cboLoaiTK.SelectedIndex = 0; 
        }

        void LoadDanhSachTaiKhoan()
        {

            string query = "SELECT Username, HoTen, LoaiTaiKhoan FROM TAIKHOAN";
            DataTable dt = DataProvider.ThucThiTruyVan(query);

            dgvTaiKhoan.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                dgvTaiKhoan.Columns["Username"].HeaderText = "Tên Đăng Nhập";
                dgvTaiKhoan.Columns["HoTen"].HeaderText = "Tên Hiển Thị";
                dgvTaiKhoan.Columns["LoaiTaiKhoan"].HeaderText = "Loại Tài Khoản";
            }
        }
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtTenDangNhap.Text = row.Cells["Username"].Value.ToString();
                txtTenHienThi.Text = row.Cells["HoTen"].Value.ToString();
                cboLoaiTK.Text = row.Cells["LoaiTaiKhoan"].Value.ToString();

                txtMatKhau.Text = "";
                txtTenDangNhap.ReadOnly = true;
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = "";
            txtTenHienThi.Text = "";
            txtMatKhau.Text = "";
            cboLoaiTK.SelectedIndex = 0;
            txtTenDangNhap.ReadOnly = false; 
            txtTenDangNhap.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text.Trim();
            string tenHT = txtTenHienThi.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
           
            string loaiTK = cboLoaiTK.Text; 

            if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(tenHT) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            try
            {
               
                string queryCheck = $"SELECT * FROM TAIKHOAN WHERE Username = N'{tenDN}'";
                if (DataProvider.ThucThiTruyVan(queryCheck).Rows.Count > 0)
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại!");
                    return;
                }                
                string query = $"INSERT INTO TAIKHOAN (Username, HoTen, Password, LoaiTaiKhoan) " +
                               $"VALUES (N'{tenDN}', N'{tenHT}', N'{matKhau}', N'{loaiTK}')";
                DataProvider.ThucThiLenh(query);
                MessageBox.Show("Thêm tài khoản mới thành công!");
                LoadDanhSachTaiKhoan();
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text;
            string tenHT = txtTenHienThi.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
           
            string loaiTK = cboLoaiTK.Text;

            if (string.IsNullOrEmpty(tenDN))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách để sửa.");
                return;
            }
            try
            {
                string query = "";
                if (string.IsNullOrEmpty(matKhau))
                {
                    
                    query = $"UPDATE TAIKHOAN SET HoTen = N'{tenHT}', LoaiTaiKhoan = N'{loaiTK}' " +
                            $"WHERE Username = N'{tenDN}'";
                }
                else
                {
                   
                    query = $"UPDATE TAIKHOAN SET HoTen = N'{tenHT}', Password = N'{matKhau}', LoaiTaiKhoan = N'{loaiTK}' " +
                            $"WHERE Username = N'{tenDN}'";
                }
                DataProvider.ThucThiLenh(query);
                MessageBox.Show("Cập nhật tài khoản thành công!");
                LoadDanhSachTaiKhoan();
                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text;

            if (string.IsNullOrEmpty(tenDN))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa.");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {                    
                    string query = $"DELETE FROM TAIKHOAN WHERE Username = N'{tenDN}'";
                    DataProvider.ThucThiLenh(query);

                    MessageBox.Show("Xóa tài khoản thành công!");
                    LoadDanhSachTaiKhoan();
                    btnLamMoi_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }
    }
}
