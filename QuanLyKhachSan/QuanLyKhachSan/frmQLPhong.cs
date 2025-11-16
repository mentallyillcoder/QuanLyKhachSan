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
    public partial class frmQLPhong : Form
    {
        public frmQLPhong()
        {
            InitializeComponent();
        } 
        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            LoadComboBoxLoaiPhong();
            LoadComboBoxTrangThai();
            LoadDanhSachPhong();
        }
        void LoadComboBoxLoaiPhong()
        {
            
            string query = "SELECT IDLoaiPhong, TenLoaiPhong FROM LOAIPHONG";
            DataTable dt = DataProvider.ThucThiTruyVan(query);
            cboLoaiPhong.DataSource = dt;
            cboLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboLoaiPhong.ValueMember = "IDLoaiPhong";
        }
        void LoadComboBoxTrangThai()
        {
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Đang thuê");
            cboTrangThai.Items.Add("Đang dọn dẹp");
            cboTrangThai.SelectedIndex = 0; 
        }

        void LoadDanhSachPhong()
        {
           
            string query = "SELECT p.IDPhong, p.TenPhong, lp.TenLoaiPhong, p.TrangThai " +
                           "FROM PHONG p JOIN LOAIPHONG lp ON p.IDLoaiPhong = lp.IDLoaiPhong";
            DataTable dt = DataProvider.ThucThiTruyVan(query);

            dgvPhong.DataSource = dt;

           
            dgvPhong.Columns["IDPhong"].HeaderText = "Mã Phòng";
            dgvPhong.Columns["TenPhong"].HeaderText = "Tên Phòng";
            dgvPhong.Columns["TenLoaiPhong"].HeaderText = "Loại Phòng";
            dgvPhong.Columns["TrangThai"].HeaderText = "Trạng Thái";
        }
        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];


                txtMaPhong.Text = row.Cells["IDPhong"].Value.ToString();
                txtTenPhong.Text = row.Cells["TenPhong"].Value.ToString();


                cboLoaiPhong.Text = row.Cells["TenLoaiPhong"].Value.ToString();
                cboTrangThai.Text = row.Cells["TrangThai"].Value.ToString();


                txtMaPhong.ReadOnly = true;
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            cboLoaiPhong.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;

            txtMaPhong.ReadOnly = false; 
            txtMaPhong.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string idPhong = txtMaPhong.Text.Trim();
            string tenPhong = txtTenPhong.Text.Trim();
            int idLoaiPhong = Convert.ToInt32(cboLoaiPhong.SelectedValue);
            string trangThai = cboTrangThai.Text;

            if (string.IsNullOrEmpty(idPhong) || string.IsNullOrEmpty(tenPhong))
            {
                MessageBox.Show("Mã phòng và Tên phòng không được để trống!");
                return;
            }

            try
            {
                // Kiểm tra xem Mã phòng đã tồn tại chưa
                string queryCheck = $"SELECT * FROM PHONG WHERE IDPhong = '{idPhong}'";
                if (DataProvider.ThucThiTruyVan(queryCheck).Rows.Count > 0)
                {
                    MessageBox.Show("Mã phòng này đã tồn tại!");
                    return;
                }

                // Thêm phòng mới
                string query = $"INSERT INTO PHONG (IDPhong, TenPhong, IDLoaiPhong, TrangThai) " +
                               $"VALUES (N'{idPhong}', N'{tenPhong}', {idLoaiPhong}, N'{trangThai}')";
                DataProvider.ThucThiLenh(query);

                MessageBox.Show("Thêm phòng mới thành công!");
                LoadDanhSachPhong(); 
                btnLamMoi_Click(sender, e); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string idPhong = txtMaPhong.Text;
            string tenPhong = txtTenPhong.Text.Trim();
            int idLoaiPhong = Convert.ToInt32(cboLoaiPhong.SelectedValue);
            string trangThai = cboTrangThai.Text;

            if (string.IsNullOrEmpty(idPhong))
            {
                MessageBox.Show("Vui lòng chọn một phòng từ danh sách để sửa.");
                return;
            }
            if (trangThai == "Đang thuê")
            {
                MessageBox.Show("Không thể sửa trạng thái 'Đang thuê' tại đây.\nVui lòng dùng chức năng Check-in/Check-out.");
                LoadDanhSachPhong();
                return;
            }

            try
            {
                string query = $"UPDATE PHONG SET TenPhong = N'{tenPhong}', IDLoaiPhong = {idLoaiPhong}, TrangThai = N'{trangThai}' " +
                               $"WHERE IDPhong = N'{idPhong}'";
                DataProvider.ThucThiLenh(query);

                MessageBox.Show("Cập nhật phòng thành công!");
                LoadDanhSachPhong(); 
                btnLamMoi_Click(sender, e); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string idPhong = txtMaPhong.Text;

            if (string.IsNullOrEmpty(idPhong))
            {
                MessageBox.Show("Vui lòng chọn một phòng để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Chỉ cho phép xóa khi phòng "Trống" hoặc "Đang dọn dẹp"
                    // (Lỗi khóa ngoại sẽ ngăn xóa nếu phòng đang "Đã check-in")
                    string query = $"DELETE FROM PHONG WHERE IDPhong = N'{idPhong}'";
                    DataProvider.ThucThiLenh(query);

                    MessageBox.Show("Xóa phòng thành công!");
                    LoadDanhSachPhong(); 
                    btnLamMoi_Click(sender, e); 
                }
                catch (Exception ex)
                {
                    // Lỗi này xảy ra nếu có Phiếu Đặt Phòng đang tham chiếu (khóa ngoại)
                    MessageBox.Show("Lỗi khi xóa: Phòng này đã từng có khách đặt, không thể xóa.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

