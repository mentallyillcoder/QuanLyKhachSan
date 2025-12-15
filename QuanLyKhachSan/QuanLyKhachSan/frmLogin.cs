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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.FormClosing += frmLogin_FormClosing;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Load ảnh nền cho panel left
            try
            {
                string bgImagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "Bg_Log.jpg");
                if (System.IO.File.Exists(bgImagePath))
                {
                    panelLeft.BackgroundImage = Image.FromFile(bgImagePath);
                    panelLeft.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            catch
            {
                // Không hiển thị lỗi load ảnh nền
            }

            // Load logo
            try
            {
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "Images", "logo.png");
                if (System.IO.File.Exists(logoPath))
                {
                    pbLogo.Image = Image.FromFile(logoPath);
                }
            }
            catch
            {
                // Không hiển thị lỗi load logo
            }

            // Bo góc cho các button và panel
            RoundButton(btnLogin, 20);
            RoundButton(btnThoat, 20);
            RoundPanel(panelUsername, 10);
            RoundPanel(panelPassword, 10);
        }

        private void RoundButton(Button btn, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);
        }

        private void RoundPanel(Panel panel, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(46, 204, 113);
        }

        private void btnThoat_MouseEnter(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.FromArgb(231, 76, 60);
            btnThoat.ForeColor = Color.White;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.White;
            btnThoat.ForeColor = Color.FromArgb(231, 76, 60);
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbClose_MouseEnter(object sender, EventArgs e)
        {
            lbClose.ForeColor = Color.FromArgb(231, 76, 60);
        }

        private void lbClose_MouseLeave(object sender, EventArgs e)
        {
            lbClose.ForeColor = Color.FromArgb(189, 195, 199);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Ẩn lỗi cũ nếu có
            lbError.Visible = false;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                return;
            }           
            
            string query = $"SELECT * FROM TAIKHOAN WHERE Username = N'{username}' AND Password = N'{password}'";
            DataTable result = DataProvider.ThucThiTruyVan(query);   
            if (result.Rows.Count > 0)
            {
                DataRow taiKhoan = result.Rows[0];

                // Ẩn 2 button và hiện progress bar
                btnLogin.Visible = false;
                btnThoat.Visible = false;
                panelProgress.Visible = true;
                lbStatus.Visible = true;
                lbCheckIcon.Visible = false;
                progressBar.Visible = true;
                progressBar.Value = 0;

                // Giai đoạn 1: Đang xác thực (0-50%)
                lbStatus.Text = "Đang xác thực...";
                lbStatus.ForeColor = Color.FromArgb(52, 152, 219);
                for (int i = 0; i <= 50; i += 5)
                {
                    progressBar.Value = i;
                    await Task.Delay(30);
                }

                // Giai đoạn 2: Đang tải dữ liệu (50-100%)
                lbStatus.Text = "Đang tải dữ liệu...";
                for (int i = 50; i <= 100; i += 5)
                {
                    progressBar.Value = i;
                    await Task.Delay(30);
                }

                // Ẩn progress bar và status
                progressBar.Visible = false;
                lbStatus.Visible = false;

                // Hiệu ứng tick bật ra (scale animation)
                lbCheckIcon.Visible = true;
                lbCheckIcon.Font = new Font("Segoe UI", 1, FontStyle.Bold);
                
                // Animation: Phóng to từ nhỏ đến lớn
                for (int size = 1; size <= 36; size += 3)
                {
                    lbCheckIcon.Font = new Font("Segoe UI", size, FontStyle.Bold);
                    await Task.Delay(15);
                }

                // Dừng 0.5s để người dùng thấy tick
                await Task.Delay(500);

                // Chuyển sang form Main
                frmMain f = new frmMain(taiKhoan, this);
                f.Show();
                this.Hide();

                // Reset lại form
                panelProgress.Visible = false;
                btnLogin.Visible = true;
                btnThoat.Visible = true;
                progressBar.Value = 0;
                lbStatus.ForeColor = Color.FromArgb(52, 152, 219);
                lbCheckIcon.Visible = false;
                btnLogin.Enabled = true;
                btnThoat.Enabled = true;
            }
            else
            {
                ShowError("Tên đăng nhập hoặc mật khẩu không chính xác!");
            }
        }

        private async void ShowError(string message)
        {
            lbError.Text = message;
            lbError.Visible = true;
            
            // Tự động ẩn sau 3 giây
            await Task.Delay(3000);
            lbError.Visible = false;
        }
        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
