using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace QuanLyKhachSan
{
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLayLaiMK_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (username == "")
            {
                ShowMessage("Vui lòng nhập Tên đăng nhập!", Color.Red);
                return;
            }

            // 1. Truy vấn Database theo Username để lấy Email và Password
            // Chúng ta cần lấy cả Password (để gửi) và Email (để biết gửi đi đâu)
            string query = $"SELECT Password, Email FROM TAIKHOAN WHERE Username = '{username}'";
            DataTable result = DataProvider.ThucThiTruyVan(query);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                string matKhau = row["Password"].ToString();
                string emailNhan = row["Email"].ToString();

                // Kiểm tra xem tài khoản này có Email trong database không
                if (string.IsNullOrEmpty(emailNhan))
                {
                    ShowMessage("Tài khoản này chưa đăng ký Email bảo mật!", Color.Red);
                    return;
                }

                // 2. Tiến hành gửi Email
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    btnLayLaiMK.Enabled = false;
                    btnLayLaiMK.Text = "Đang gửi...";

                    GuiEmail(emailNhan, matKhau);

                    // Che bớt email để bảo mật (Ví dụ: a*****@gmail.com)
                    string maskedEmail = MaskEmail(emailNhan);
                    ShowMessage($"Mật khẩu đã được gửi đến: {maskedEmail}", Color.Green);
                }
                catch (Exception ex)
                {
                    ShowMessage("Lỗi gửi mail: " + ex.Message, Color.Red);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    btnLayLaiMK.Enabled = true;
                    btnLayLaiMK.Text = "GỬI MẬT KHẨU";
                }
            }
            else
            {
                ShowMessage("Tên đăng nhập không tồn tại!", Color.Red);
            }
        }

        private void GuiEmail(string emailNhan, string matKhau)
        {
            string fromEmail = "24520584@gm.uit.edu.vn";
            string password = "tuty uddg ylvf gpsa";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(emailNhan);
            mail.Subject = "Cấp lại mật khẩu - Hệ thống Quản lý Khách sạn";

            mail.Body = $@"
                <html>
                <body>
                    <h2>Xin chào {txtUsername.Text},</h2>
                    <p>Hệ thống nhận được yêu cầu lấy lại mật khẩu cho tài khoản: <b>{txtUsername.Text}</b>.</p>
                    <p>Mật khẩu hiện tại của bạn là: <b style='color:red; font-size: 16px;'>{matKhau}</b></p>
                    <p>Nếu bạn không thực hiện yêu cầu này, vui lòng liên hệ quản trị viên ngay lập tức.</p>
                    <br>
                    <p>Trân trọng,</p>
                    <p>Admin Team</p>
                </body>
                </html>";

            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromEmail, password);

            smtp.Send(mail);
        }

        // Hàm che email (Ví dụ: admin@gmail.com -> a****@gmail.com)
        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return "";
            int atIndex = email.IndexOf('@');
            if (atIndex <= 1) return email;

            string mask = new string('*', atIndex - 1);
            return email[0] + mask + email.Substring(atIndex);
        }

        private void ShowMessage(string msg, Color color)
        {
            lbKetQua.ForeColor = color;
            lbKetQua.Text = msg;
        }
    }
}