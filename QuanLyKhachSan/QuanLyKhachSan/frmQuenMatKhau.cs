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
            // Lấy Email người dùng nhập vào
            string emailInput = txtEmail.Text.Trim();

            if (emailInput == "")
            {
                ShowMessage("Vui lòng nhập Email đã đăng ký!", Color.Red);
                return;
            }

            // 1. Truy vấn Database theo EMAIL
            // Chúng ta lấy thêm cột Username và HoTen để gửi thông tin đầy đủ cho người dùng
            string query = $"SELECT Username, Password, HoTen FROM TAIKHOAN WHERE Email = '{emailInput}'";
            DataTable result = DataProvider.ThucThiTruyVan(query);

            if (result.Rows.Count > 0)
            {
                // Lấy dữ liệu từ dòng đầu tiên tìm thấy
                DataRow row = result.Rows[0];
                string username = row["Username"].ToString();
                string matKhau = row["Password"].ToString();
                string hoTen = row["HoTen"].ToString();

                // 2. Tiến hành gửi Email
                try
                {
                    // Hiệu ứng chờ
                    Cursor.Current = Cursors.WaitCursor;
                    btnLayLaiMK.Enabled = false;
                    btnLayLaiMK.Text = "Đang gửi...";

                    // Gọi hàm gửi mail với đầy đủ thông tin
                    GuiEmail(emailInput, username, hoTen, matKhau);

                    ShowMessage($"Đã gửi thông tin tài khoản vào email: {emailInput}", Color.Green);
                }
                catch (Exception ex)
                {
                    ShowMessage("Lỗi gửi mail: " + ex.Message, Color.Red);
                }
                finally
                {
                    // Trả lại trạng thái bình thường
                    Cursor.Current = Cursors.Default;
                    btnLayLaiMK.Enabled = true;
                    btnLayLaiMK.Text = "GỬI MẬT KHẨU";
                }
            }
            else
            {
                ShowMessage("Email này chưa được đăng ký trong hệ thống!", Color.Red);
            }
        }

        private void GuiEmail(string emailNhan, string username, string hoTen, string matKhau)
        {
            // --- THÔNG TIN GMAIL CỦA BẠN ---
            string fromEmail = "24520584@gm.uit.edu.vn";
            string password = "tuty uddg ylvf gpsa"; // Mật khẩu ứng dụng bạn đã cung cấp
            // -------------------------------

            MailMessage mail = new MailMessage();

            // Trim() để xóa khoảng trắng thừa tránh lỗi Header
            mail.From = new MailAddress(fromEmail.Trim());
            mail.To.Add(emailNhan.Trim());

            // Cấu hình UTF-8 để không lỗi font tiếng Việt
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Subject = "Khôi phục thông tin tài khoản - Hệ thống Quản lý Khách sạn";

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;

            // Nội dung thư mới: Gửi cả Username và Password
            mail.Body = $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <h2 style='color: #2980b9;'>Xin chào {hoTen},</h2>
                    <p>Hệ thống nhận được yêu cầu lấy lại mật khẩu từ Email: <b>{emailNhan}</b>.</p>
                    <p>Dưới đây là thông tin đăng nhập của bạn:</p>
                    <div style='background-color: #f1f1f1; padding: 15px; border-radius: 5px; display: inline-block;'>
                        <p>👤 Tên đăng nhập: <b>{username}</b></p>
                        <p>🔒 Mật khẩu: <b style='color:red; font-size: 16px;'>{matKhau}</b></p>
                    </div>
                    <p>Vui lòng đăng nhập.</p>
                    <br>
                    <p>Trân trọng,</p>
                    <p><b>Ban Quản Trị Khách Sạn</b></p>
                </body>
                </html>";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromEmail.Trim(), password.Trim());

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