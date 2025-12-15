namespace QuanLyKhachSan
{
    partial class PhieuDatPhong
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

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblThongTinKH;
        private System.Windows.Forms.Label lblThongTinPhong;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.DateTimePicker dtpGioBD;
        private System.Windows.Forms.DateTimePicker dtpGioKT;
        private System.Windows.Forms.Label lblNgayBD;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.Label lblGioBD;
        private System.Windows.Forms.Label lblGioKT;
        private System.Windows.Forms.Label lblPhongTrong;
        private System.Windows.Forms.Label lblPhongDaChon;
        private System.Windows.Forms.DataGridView dgwPhongTrong;
        private System.Windows.Forms.DataGridView dgwPhongDaChon;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiPhong;
        private System.Windows.Forms.DataGridViewButtonColumn Them;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhongDC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNguoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBD;
        private System.Windows.Forms.DataGridViewButtonColumn Xoa;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblThongTinKH = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.lblGioBD = new System.Windows.Forms.Label();
            this.lblGioKT = new System.Windows.Forms.Label();
            this.lblPhongDaChon = new System.Windows.Forms.Label();
            this.dgwPhongDaChon = new System.Windows.Forms.DataGridView();
            this.SoPhongDC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNguoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblPhongTrong = new System.Windows.Forms.Label();
            this.dgwPhongTrong = new System.Windows.Forms.DataGridView();
            this.SoPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Them = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtpGioKT = new System.Windows.Forms.DateTimePicker();
            this.dtpGioBD = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.lblThongTinPhong = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPhongDaChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPhongTrong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1000, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đặt Phòng";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelLeft.Controls.Add(this.btnTimKiem);
            this.panelLeft.Controls.Add(this.lblDiaChi);
            this.panelLeft.Controls.Add(this.txtDiaChi);
            this.panelLeft.Controls.Add(this.lblSDT);
            this.panelLeft.Controls.Add(this.txtSDT);
            this.panelLeft.Controls.Add(this.lblCCCD);
            this.panelLeft.Controls.Add(this.txtCCCD);
            this.panelLeft.Controls.Add(this.lblHoTen);
            this.panelLeft.Controls.Add(this.txtHoTen);
            this.panelLeft.Controls.Add(this.lblThongTinKH);
            this.panelLeft.Location = new System.Drawing.Point(20, 80);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(15);
            this.panelLeft.Size = new System.Drawing.Size(420, 420);
            this.panelLeft.TabIndex = 1;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDiaChi.Location = new System.Drawing.Point(30, 240);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(80, 15);
            this.lblDiaChi.TabIndex = 8;
            this.lblDiaChi.Text = "📍 Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Location = new System.Drawing.Point(30, 260);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(360, 25);
            this.txtDiaChi.TabIndex = 7;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSDT.Location = new System.Drawing.Point(30, 180);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(105, 15);
            this.lblSDT.TabIndex = 6;
            this.lblSDT.Text = "📞 Số điện thoại";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Location = new System.Drawing.Point(30, 200);
            this.txtSDT.MaxLength = 10;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(360, 25);
            this.txtSDT.TabIndex = 5;
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCCCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCCCD.Location = new System.Drawing.Point(30, 120);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(70, 15);
            this.lblCCCD.TabIndex = 4;
            this.lblCCCD.Text = "🪪 CCCD";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCCCD.Location = new System.Drawing.Point(30, 140);
            this.txtCCCD.MaxLength = 12;
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(260, 25);
            this.txtCCCD.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(300, 140);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 25);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblHoTen.Location = new System.Drawing.Point(30, 60);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(65, 15);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "👤 Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Location = new System.Drawing.Point(30, 80);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(360, 25);
            this.txtHoTen.TabIndex = 1;
            // 
            // lblThongTinKH
            // 
            this.lblThongTinKH.AutoSize = true;
            this.lblThongTinKH.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblThongTinKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblThongTinKH.Location = new System.Drawing.Point(15, 15);
            this.lblThongTinKH.Name = "lblThongTinKH";
            this.lblThongTinKH.Size = new System.Drawing.Size(201, 25);
            this.lblThongTinKH.TabIndex = 0;
            this.lblThongTinKH.Text = "Thông tin khách hàng";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelRight.Controls.Add(this.lblGioKT);
            this.panelRight.Controls.Add(this.lblGioBD);
            this.panelRight.Controls.Add(this.lblNgayKT);
            this.panelRight.Controls.Add(this.lblNgayBD);
            this.panelRight.Controls.Add(this.lblPhongDaChon);
            this.panelRight.Controls.Add(this.dgwPhongDaChon);
            this.panelRight.Controls.Add(this.lblPhongTrong);
            this.panelRight.Controls.Add(this.dgwPhongTrong);
            this.panelRight.Controls.Add(this.dtpGioKT);
            this.panelRight.Controls.Add(this.dtpGioBD);
            this.panelRight.Controls.Add(this.dtpNgayKT);
            this.panelRight.Controls.Add(this.dtpNgayBD);
            this.panelRight.Controls.Add(this.lblThongTinPhong);
            this.panelRight.Location = new System.Drawing.Point(460, 80);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(15);
            this.panelRight.Size = new System.Drawing.Size(520, 420);
            this.panelRight.TabIndex = 2;
            // 
            // lblPhongDaChon
            // 
            this.lblPhongDaChon.AutoSize = true;
            this.lblPhongDaChon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPhongDaChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblPhongDaChon.Location = new System.Drawing.Point(280, 220);
            this.lblPhongDaChon.Name = "lblPhongDaChon";
            this.lblPhongDaChon.Size = new System.Drawing.Size(133, 21);
            this.lblPhongDaChon.TabIndex = 8;
            this.lblPhongDaChon.Text = "Phòng đã chọn";
            // 
            // dgwPhongDaChon
            // 
            this.dgwPhongDaChon.AllowUserToAddRows = false;
            this.dgwPhongDaChon.BackgroundColor = System.Drawing.Color.White;
            this.dgwPhongDaChon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwPhongDaChon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwPhongDaChon.ColumnHeadersHeight = 35;
            this.dgwPhongDaChon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoPhongDC,
            this.SoNguoi,
            this.NgayBD,
            this.Xoa});
            this.dgwPhongDaChon.EnableHeadersVisualStyles = false;
            this.dgwPhongDaChon.Location = new System.Drawing.Point(280, 250);
            this.dgwPhongDaChon.Name = "dgwPhongDaChon";
            this.dgwPhongDaChon.RowHeadersVisible = false;
            this.dgwPhongDaChon.RowTemplate.Height = 35;
            this.dgwPhongDaChon.Size = new System.Drawing.Size(220, 150);
            this.dgwPhongDaChon.TabIndex = 7;
            this.dgwPhongDaChon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwPhongDaChon_CellContentClick);
            // 
            // SoPhongDC
            // 
            this.SoPhongDC.HeaderText = "Số phòng";
            this.SoPhongDC.Name = "SoPhongDC";
            this.SoPhongDC.ReadOnly = true;
            this.SoPhongDC.Width = 70;
            // 
            // SoNguoi
            // 
            this.SoNguoi.HeaderText = "Số người";
            this.SoNguoi.Name = "SoNguoi";
            this.SoNguoi.ReadOnly = false;
            this.SoNguoi.Width = 70;
            // 
            // NgayBD
            // 
            this.NgayBD.HeaderText = "Ngày ĐD";
            this.NgayBD.Name = "NgayBD";
            this.NgayBD.Visible = false;
            // 
            // Xoa
            // 
            this.Xoa.HeaderText = "Xóa";
            this.Xoa.Name = "Xoa";
            this.Xoa.Text = "🗑";
            this.Xoa.UseColumnTextForButtonValue = true;
            this.Xoa.Width = 50;
            // 
            // lblPhongTrong
            // 
            this.lblPhongTrong.AutoSize = true;
            this.lblPhongTrong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPhongTrong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblPhongTrong.Location = new System.Drawing.Point(20, 220);
            this.lblPhongTrong.Name = "lblPhongTrong";
            this.lblPhongTrong.Size = new System.Drawing.Size(180, 21);
            this.lblPhongTrong.TabIndex = 6;
            this.lblPhongTrong.Text = "Danh sách phòng trống";
            // 
            // dgwPhongTrong
            // 
            this.dgwPhongTrong.AllowUserToAddRows = false;
            this.dgwPhongTrong.BackgroundColor = System.Drawing.Color.White;
            this.dgwPhongTrong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwPhongTrong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgwPhongTrong.ColumnHeadersHeight = 35;
            this.dgwPhongTrong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoPhong,
            this.LoaiPhong,
            this.Them});
            this.dgwPhongTrong.EnableHeadersVisualStyles = false;
            this.dgwPhongTrong.Location = new System.Drawing.Point(20, 250);
            this.dgwPhongTrong.Name = "dgwPhongTrong";
            this.dgwPhongTrong.RowHeadersVisible = false;
            this.dgwPhongTrong.RowTemplate.Height = 35;
            this.dgwPhongTrong.Size = new System.Drawing.Size(240, 150);
            this.dgwPhongTrong.TabIndex = 5;
            this.dgwPhongTrong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwPhongTrong_CellContentClick);
            // 
            // SoPhong
            // 
            this.SoPhong.HeaderText = "Số phòng";
            this.SoPhong.Name = "SoPhong";
            this.SoPhong.Width = 70;
            // 
            // LoaiPhong
            // 
            this.LoaiPhong.HeaderText = "Loại phòng";
            this.LoaiPhong.Name = "LoaiPhong";
            this.LoaiPhong.Width = 90;
            // 
            // Them
            // 
            this.Them.HeaderText = "Thêm";
            this.Them.Name = "Them";
            this.Them.Text = "➕";
            this.Them.UseColumnTextForButtonValue = true;
            this.Them.Width = 50;
            // 
            // dtpGioKT
            // 
            this.dtpGioKT.CustomFormat = "HH:mm";
            this.dtpGioKT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpGioKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioKT.Location = new System.Drawing.Point(390, 155);
            this.dtpGioKT.Name = "dtpGioKT";
            this.dtpGioKT.ShowUpDown = true;
            this.dtpGioKT.Size = new System.Drawing.Size(110, 25);
            this.dtpGioKT.TabIndex = 4;
            // 
            // lblGioKT
            // 
            this.lblGioKT.AutoSize = true;
            this.lblGioKT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGioKT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblGioKT.Location = new System.Drawing.Point(390, 130);
            this.lblGioKT.Name = "lblGioKT";
            this.lblGioKT.Size = new System.Drawing.Size(103, 19);
            this.lblGioKT.TabIndex = 12;
            this.lblGioKT.Text = "🕐 Giờ kết thúc";
            // 
            // dtpGioBD
            // 
            this.dtpGioBD.CustomFormat = "HH:mm";
            this.dtpGioBD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpGioBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioBD.Location = new System.Drawing.Point(390, 90);
            this.dtpGioBD.Name = "dtpGioBD";
            this.dtpGioBD.ShowUpDown = true;
            this.dtpGioBD.Size = new System.Drawing.Size(110, 25);
            this.dtpGioBD.TabIndex = 3;
            // 
            // lblGioBD
            // 
            this.lblGioBD.AutoSize = true;
            this.lblGioBD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGioBD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblGioBD.Location = new System.Drawing.Point(390, 65);
            this.lblGioBD.Name = "lblGioBD";
            this.lblGioBD.Size = new System.Drawing.Size(98, 19);
            this.lblGioBD.TabIndex = 11;
            this.lblGioBD.Text = "🕐 Giờ bắt đầu";
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKT.Location = new System.Drawing.Point(20, 155);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(150, 25);
            this.dtpNgayKT.TabIndex = 2;
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.AutoSize = true;
            this.lblNgayKT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgayKT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNgayKT.Location = new System.Drawing.Point(20, 130);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(110, 19);
            this.lblNgayKT.TabIndex = 10;
            this.lblNgayKT.Text = "📅 Ngày kết thúc";
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBD.Location = new System.Drawing.Point(20, 90);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(150, 25);
            this.dtpNgayBD.TabIndex = 1;
            // 
            // lblNgayBD
            // 
            this.lblNgayBD.AutoSize = true;
            this.lblNgayBD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgayBD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNgayBD.Location = new System.Drawing.Point(20, 65);
            this.lblNgayBD.Name = "lblNgayBD";
            this.lblNgayBD.Size = new System.Drawing.Size(105, 19);
            this.lblNgayBD.TabIndex = 9;
            this.lblNgayBD.Text = "📅 Ngày bắt đầu";
            // 
            // lblThongTinPhong
            // 
            this.lblThongTinPhong.AutoSize = true;
            this.lblThongTinPhong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblThongTinPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblThongTinPhong.Location = new System.Drawing.Point(15, 15);
            this.lblThongTinPhong.Name = "lblThongTinPhong";
            this.lblThongTinPhong.Size = new System.Drawing.Size(154, 25);
            this.lblThongTinPhong.TabIndex = 0;
            this.lblThongTinPhong.Text = "Thông tin phòng";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(760, 520);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 40);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(880, 520);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // PhieuDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 580);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PhieuDatPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu Đặt Phòng";
            this.Load += new System.EventHandler(this.PhieuDatPhong_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPhongDaChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPhongTrong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
