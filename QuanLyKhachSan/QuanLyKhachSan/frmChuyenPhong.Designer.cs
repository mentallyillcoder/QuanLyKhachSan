namespace QuanLyKhachSan
{
    partial class frmChuyenPhong
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
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox gbPhongHienTai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPhongGoc;
        private System.Windows.Forms.GroupBox gbPhongMoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPhongDich;
        private System.Windows.Forms.Label lbThongTin;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.gbPhongMoi = new System.Windows.Forms.GroupBox();
            this.lbThongTin = new System.Windows.Forms.Label();
            this.cboPhongDich = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbPhongHienTai = new System.Windows.Forms.GroupBox();
            this.lbPhongGoc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.gbPhongMoi.SuspendLayout();
            this.gbPhongHienTai.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 60);
            this.panelTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHUYỂN PHÒNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.gbPhongMoi);
            this.panelMain.Controls.Add(this.gbPhongHienTai);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panelMain.Size = new System.Drawing.Size(600, 320);
            this.panelMain.TabIndex = 1;
            // 
            // gbPhongMoi
            // 
            this.gbPhongMoi.Controls.Add(this.lbThongTin);
            this.gbPhongMoi.Controls.Add(this.cboPhongDich);
            this.gbPhongMoi.Controls.Add(this.label3);
            this.gbPhongMoi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbPhongMoi.Location = new System.Drawing.Point(30, 160);
            this.gbPhongMoi.Name = "gbPhongMoi";
            this.gbPhongMoi.Size = new System.Drawing.Size(540, 140);
            this.gbPhongMoi.TabIndex = 1;
            this.gbPhongMoi.TabStop = false;
            this.gbPhongMoi.Text = "Chuyển đến phòng";
            // 
            // lbThongTin
            // 
            this.lbThongTin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lbThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lbThongTin.Location = new System.Drawing.Point(40, 90);
            this.lbThongTin.Name = "lbThongTin";
            this.lbThongTin.Size = new System.Drawing.Size(460, 40);
            this.lbThongTin.TabIndex = 2;
            this.lbThongTin.Text = "Chọn phòng trống để chuyển đến";
            this.lbThongTin.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // cboPhongDich
            // 
            this.cboPhongDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongDich.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhongDich.FormattingEnabled = true;
            this.cboPhongDich.Location = new System.Drawing.Point(200, 45);
            this.cboPhongDich.Name = "cboPhongDich";
            this.cboPhongDich.Size = new System.Drawing.Size(300, 25);
            this.cboPhongDich.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(40, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phòng mới:";
            // 
            // gbPhongHienTai
            // 
            this.gbPhongHienTai.Controls.Add(this.lbPhongGoc);
            this.gbPhongHienTai.Controls.Add(this.label2);
            this.gbPhongHienTai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbPhongHienTai.Location = new System.Drawing.Point(30, 20);
            this.gbPhongHienTai.Name = "gbPhongHienTai";
            this.gbPhongHienTai.Size = new System.Drawing.Size(540, 120);
            this.gbPhongHienTai.TabIndex = 0;
            this.gbPhongHienTai.TabStop = false;
            this.gbPhongHienTai.Text = "Phòng hiện tại";
            // 
            // lbPhongGoc
            // 
            this.lbPhongGoc.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lbPhongGoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lbPhongGoc.Location = new System.Drawing.Point(200, 45);
            this.lbPhongGoc.Name = "lbPhongGoc";
            this.lbPhongGoc.Size = new System.Drawing.Size(300, 50);
            this.lbPhongGoc.TabIndex = 1;
            this.lbPhongGoc.Text = "...";
            this.lbPhongGoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(40, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phòng:";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelButtons.Controls.Add(this.btnHuy);
            this.panelButtons.Controls.Add(this.btnXacNhan);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 380);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(600, 80);
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
            this.btnHuy.Location = new System.Drawing.Point(330, 20);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(150, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(120, 20);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(180, 40);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác nhận chuyển";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // frmChuyenPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmChuyenPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển Phòng";
            this.Load += new System.EventHandler(this.frmChuyenPhong_Load);
            this.panelTop.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.gbPhongMoi.ResumeLayout(false);
            this.gbPhongMoi.PerformLayout();
            this.gbPhongHienTai.ResumeLayout(false);
            this.gbPhongHienTai.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
