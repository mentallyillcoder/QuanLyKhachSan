namespace QuanLyKhachSan
{
    partial class frmThanhToan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelThongTin;
        private System.Windows.Forms.GroupBox gbThongTinChung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbNgayCheckIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTenKhachHang;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpNgayCheckOut;
        private System.Windows.Forms.Panel panelDichVu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvDichVuDaSuDung;
        private System.Windows.Forms.Panel panelThanhToan;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTienPhong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbTienDichVu;
        private System.Windows.Forms.Panel panelTongTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnXacNhanThanhToan;
        private System.Windows.Forms.Button btnHuy;

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelThongTin = new System.Windows.Forms.Panel();
            this.gbThongTinChung = new System.Windows.Forms.GroupBox();
            this.dtpNgayCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.lbTenKhachHang = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNgayCheckIn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPhong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDichVu = new System.Windows.Forms.Panel();
            this.dgvDichVuDaSuDung = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panelThanhToan = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhanThanhToan = new System.Windows.Forms.Button();
            this.panelTongTien = new System.Windows.Forms.Panel();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.lbTienDichVu = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbTienPhong = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelThongTin.SuspendLayout();
            this.gbThongTinChung.SuspendLayout();
            this.panelDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaSuDung)).BeginInit();
            this.panelThanhToan.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelTongTien.SuspendLayout();
            this.gbChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 60);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(900, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "THANH TOÁN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelThongTin
            // 
            this.panelThongTin.BackColor = System.Drawing.Color.White;
            this.panelThongTin.Controls.Add(this.gbThongTinChung);
            this.panelThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThongTin.Location = new System.Drawing.Point(0, 60);
            this.panelThongTin.Name = "panelThongTin";
            this.panelThongTin.Padding = new System.Windows.Forms.Padding(20);
            this.panelThongTin.Size = new System.Drawing.Size(900, 140);
            this.panelThongTin.TabIndex = 1;
            // 
            // gbThongTinChung
            // 
            this.gbThongTinChung.Controls.Add(this.dtpNgayCheckOut);
            this.gbThongTinChung.Controls.Add(this.label12);
            this.gbThongTinChung.Controls.Add(this.lbTenKhachHang);
            this.gbThongTinChung.Controls.Add(this.label5);
            this.gbThongTinChung.Controls.Add(this.lbNgayCheckIn);
            this.gbThongTinChung.Controls.Add(this.label4);
            this.gbThongTinChung.Controls.Add(this.lbPhong);
            this.gbThongTinChung.Controls.Add(this.label3);
            this.gbThongTinChung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbThongTinChung.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbThongTinChung.Location = new System.Drawing.Point(20, 20);
            this.gbThongTinChung.Name = "gbThongTinChung";
            this.gbThongTinChung.Size = new System.Drawing.Size(860, 100);
            this.gbThongTinChung.TabIndex = 0;
            this.gbThongTinChung.TabStop = false;
            this.gbThongTinChung.Text = "Thông tin chung";
            // 
            // dtpNgayCheckOut
            // 
            this.dtpNgayCheckOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayCheckOut.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayCheckOut.Location = new System.Drawing.Point(600, 60);
            this.dtpNgayCheckOut.Name = "dtpNgayCheckOut";
            this.dtpNgayCheckOut.Size = new System.Drawing.Size(200, 25);
            this.dtpNgayCheckOut.TabIndex = 7;
            this.dtpNgayCheckOut.ValueChanged += new System.EventHandler(this.dtpNgayCheckOut_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.Location = new System.Drawing.Point(460, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 19);
            this.label12.TabIndex = 6;
            this.label12.Text = "Ngày Check-Out:";
            // 
            // lbTenKhachHang
            // 
            this.lbTenKhachHang.AutoSize = true;
            this.lbTenKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbTenKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lbTenKhachHang.Location = new System.Drawing.Point(150, 63);
            this.lbTenKhachHang.Name = "lbTenKhachHang";
            this.lbTenKhachHang.Size = new System.Drawing.Size(17, 19);
            this.lbTenKhachHang.TabIndex = 5;
            this.lbTenKhachHang.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(30, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Khách hàng:";
            // 
            // lbNgayCheckIn
            // 
            this.lbNgayCheckIn.AutoSize = true;
            this.lbNgayCheckIn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbNgayCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lbNgayCheckIn.Location = new System.Drawing.Point(600, 33);
            this.lbNgayCheckIn.Name = "lbNgayCheckIn";
            this.lbNgayCheckIn.Size = new System.Drawing.Size(17, 19);
            this.lbNgayCheckIn.TabIndex = 3;
            this.lbNgayCheckIn.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(460, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày Check-In:";
            // 
            // lbPhong
            // 
            this.lbPhong.AutoSize = true;
            this.lbPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lbPhong.Location = new System.Drawing.Point(150, 33);
            this.lbPhong.Name = "lbPhong";
            this.lbPhong.Size = new System.Drawing.Size(17, 19);
            this.lbPhong.TabIndex = 1;
            this.lbPhong.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(30, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phòng:";
            // 
            // panelDichVu
            // 
            this.panelDichVu.BackColor = System.Drawing.Color.White;
            this.panelDichVu.Controls.Add(this.dgvDichVuDaSuDung);
            this.panelDichVu.Controls.Add(this.label9);
            this.panelDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDichVu.Location = new System.Drawing.Point(0, 200);
            this.panelDichVu.Name = "panelDichVu";
            this.panelDichVu.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelDichVu.Size = new System.Drawing.Size(900, 250);
            this.panelDichVu.TabIndex = 2;
            // 
            // dgvDichVuDaSuDung
            // 
            this.dgvDichVuDaSuDung.AllowUserToAddRows = false;
            this.dgvDichVuDaSuDung.AllowUserToDeleteRows = false;
            this.dgvDichVuDaSuDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVuDaSuDung.BackgroundColor = System.Drawing.Color.White;
            this.dgvDichVuDaSuDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDichVuDaSuDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuDaSuDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDichVuDaSuDung.Location = new System.Drawing.Point(20, 40);
            this.dgvDichVuDaSuDung.Name = "dgvDichVuDaSuDung";
            this.dgvDichVuDaSuDung.ReadOnly = true;
            this.dgvDichVuDaSuDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVuDaSuDung.Size = new System.Drawing.Size(860, 200);
            this.dgvDichVuDaSuDung.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(20, 10);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(860, 30);
            this.label9.TabIndex = 0;
            this.label9.Text = "DANH SÁCH DỊCH VỤ ĐÃ SỬ DỤNG";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelThanhToan
            // 
            this.panelThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelThanhToan.Controls.Add(this.panelButtons);
            this.panelThanhToan.Controls.Add(this.panelTongTien);
            this.panelThanhToan.Controls.Add(this.gbChiTiet);
            this.panelThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelThanhToan.Location = new System.Drawing.Point(0, 450);
            this.panelThanhToan.Name = "panelThanhToan";
            this.panelThanhToan.Padding = new System.Windows.Forms.Padding(20);
            this.panelThanhToan.Size = new System.Drawing.Size(900, 250);
            this.panelThanhToan.TabIndex = 3;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnHuy);
            this.panelButtons.Controls.Add(this.btnXacNhanThanhToan);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(20, 180);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(860, 50);
            this.panelButtons.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(460, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(180, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhanThanhToan
            // 
            this.btnXacNhanThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXacNhanThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanThanhToan.FlatAppearance.BorderSize = 0;
            this.btnXacNhanThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanThanhToan.Location = new System.Drawing.Point(220, 5);
            this.btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
            this.btnXacNhanThanhToan.Size = new System.Drawing.Size(220, 40);
            this.btnXacNhanThanhToan.TabIndex = 0;
            this.btnXacNhanThanhToan.Text = "Xác nhận thanh toán";
            this.btnXacNhanThanhToan.UseVisualStyleBackColor = false;
            this.btnXacNhanThanhToan.Click += new System.EventHandler(this.btnXacNhanThanhToan_Click);
            // 
            // panelTongTien
            // 
            this.panelTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelTongTien.Controls.Add(this.lbTongTien);
            this.panelTongTien.Controls.Add(this.label7);
            this.panelTongTien.Location = new System.Drawing.Point(450, 20);
            this.panelTongTien.Name = "panelTongTien";
            this.panelTongTien.Size = new System.Drawing.Size(430, 80);
            this.panelTongTien.TabIndex = 1;
            // 
            // lbTongTien
            // 
            this.lbTongTien.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lbTongTien.ForeColor = System.Drawing.Color.White;
            this.lbTongTien.Location = new System.Drawing.Point(0, 35);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(430, 40);
            this.lbTongTien.TabIndex = 1;
            this.lbTongTien.Text = "0 VNĐ";
            this.lbTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(430, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "TỔNG CỘNG";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Controls.Add(this.lbTienDichVu);
            this.gbChiTiet.Controls.Add(this.label11);
            this.gbChiTiet.Controls.Add(this.lbTienPhong);
            this.gbChiTiet.Controls.Add(this.label8);
            this.gbChiTiet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbChiTiet.Location = new System.Drawing.Point(20, 20);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Size = new System.Drawing.Size(400, 140);
            this.gbChiTiet.TabIndex = 0;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "Chi tiết thanh toán";
            // 
            // lbTienDichVu
            // 
            this.lbTienDichVu.AutoSize = true;
            this.lbTienDichVu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbTienDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lbTienDichVu.Location = new System.Drawing.Point(180, 80);
            this.lbTienDichVu.Name = "lbTienDichVu";
            this.lbTienDichVu.Size = new System.Drawing.Size(60, 20);
            this.lbTienDichVu.TabIndex = 3;
            this.lbTienDichVu.Text = "0 VNĐ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label11.Location = new System.Drawing.Point(30, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tiền dịch vụ:";
            // 
            // lbTienPhong
            // 
            this.lbTienPhong.AutoSize = true;
            this.lbTienPhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbTienPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lbTienPhong.Location = new System.Drawing.Point(180, 45);
            this.lbTienPhong.Name = "lbTienPhong";
            this.lbTienPhong.Size = new System.Drawing.Size(60, 20);
            this.lbTienPhong.TabIndex = 1;
            this.lbTienPhong.Text = "0 VNĐ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label8.Location = new System.Drawing.Point(30, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tiền phòng:";
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.panelDichVu);
            this.Controls.Add(this.panelThanhToan);
            this.Controls.Add(this.panelThongTin);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh Toán";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            this.panelTop.ResumeLayout(false);
            this.panelThongTin.ResumeLayout(false);
            this.gbThongTinChung.ResumeLayout(false);
            this.gbThongTinChung.PerformLayout();
            this.panelDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaSuDung)).EndInit();
            this.panelThanhToan.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelTongTien.ResumeLayout(false);
            this.gbChiTiet.ResumeLayout(false);
            this.gbChiTiet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
