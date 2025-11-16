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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        
        private void frmThongKe_Load(object sender, EventArgs e)
        {
           
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); 
            dtpDenNgay.Value = DateTime.Now; 

           
            LoadThongKe();
        }

       
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        
        void LoadThongKe()
        {
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;

            
            denNgay = denNgay.Date.AddDays(1).AddSeconds(-1);

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!");
                return;
            }

            try
            {
               
                string query = $"SELECT IDHoaDon, IDPhieuDat, NgayThanhToan, TongTien " +
                               $"FROM HOADON " +
                               $"WHERE NgayThanhToan >= '{tuNgay.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                               $"AND NgayThanhToan <= '{denNgay.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                               $"ORDER BY NgayThanhToan DESC"; 

                DataTable dt = DataProvider.ThucThiTruyVan(query);
                dgvHoaDon.DataSource = dt;

                dgvHoaDon.Columns["IDHoaDon"].HeaderText = "Mã HĐ";
                dgvHoaDon.Columns["IDPhieuDat"].HeaderText = "Mã Phiếu Đặt";
                dgvHoaDon.Columns["NgayThanhToan"].HeaderText = "Ngày Thanh Toán";
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0"; // Format tiền

                
                decimal tongDoanhThu = 0;
                int soHoaDon = dt.Rows.Count;
                foreach (DataRow row in dt.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["TongTien"]);
                }

                lbSoHoaDonValue.Text = soHoaDon.ToString();
                lbTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message);
            }
        }
    }
}
