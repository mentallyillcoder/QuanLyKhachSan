namespace QuanLyKhachSan
{
    partial class frmChiTietDatPhong
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
        private System.Windows.Forms.Panel panelThongTinPhieu;
        private System.Windows.Forms.Panel panelThongTinKhach;
        private System.Windows.Forms.Panel panelThongTinPhong;
        private System.Windows.Forms.Panel panelDichVu;
        private System.Windows.Forms.Panel panelTongKet;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnIn;

        // Thông tin phiếu
        private System.Windows.Forms.Label lblThongTinPhieu;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.TextBox txtNgayLap;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.TextBox txtNhanVien;

        // Thông tin khách hàng
        private System.Windows.Forms.Label lblThongTinKhach;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;

        // Thông tin phòng
        private System.Windows.Forms.Label lblThongTinPhong;
        private System.Windows.Forms.Label lblNgayNhanPhong;
        private System.Windows.Forms.Label lblNgayTraPhong;
        private System.Windows.Forms.Label lblSoGioO;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.TextBox txtNgayNhanPhong;
        private System.Windows.Forms.TextBox txtNgayTraPhong;
        private System.Windows.Forms.TextBox txtSoGioO;
        private System.Windows.Forms.TextBox txtSoNguoi;
        private System.Windows.Forms.DataGridView dgvPhong;

        // Dịch vụ
        private System.Windows.Forms.Label lblDichVu;
        private System.Windows.Forms.DataGridView dgvDichVu;

        // Tổng kết
        private System.Windows.Forms.Label lblTongKet;
        private System.Windows.Forms.Label lblTienPhong;
        private System.Windows.Forms.Label lblTienDichVu;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTienPhong;
        private System.Windows.Forms.TextBox txtTienDichVu;
        private System.Windows.Forms.TextBox txtTongTien;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelThongTinPhieu = new System.Windows.Forms.Panel();
            this.lblThongTinPhieu = new System.Windows.Forms.Label();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.txtNgayLap = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.panelThongTinKhach = new System.Windows.Forms.Panel();
            this.lblThongTinKhach = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.panelThongTinPhong = new System.Windows.Forms.Panel();
            this.lblThongTinPhong = new System.Windows.Forms.Label();
            this.lblNgayNhanPhong = new System.Windows.Forms.Label();
            this.txtNgayNhanPhong = new System.Windows.Forms.TextBox();
            this.lblNgayTraPhong = new System.Windows.Forms.Label();
            this.txtNgayTraPhong = new System.Windows.Forms.TextBox();
            this.lblSoGioO = new System.Windows.Forms.Label();
            this.txtSoGioO = new System.Windows.Forms.TextBox();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.txtSoNguoi = new System.Windows.Forms.TextBox();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.panelDichVu = new System.Windows.Forms.Panel();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.panelTongKet = new System.Windows.Forms.Panel();
            this.lblTongKet = new System.Windows.Forms.Label();
            this.lblTienPhong = new System.Windows.Forms.Label();
            this.txtTienPhong = new System.Windows.Forms.TextBox();
            this.lblTienDichVu = new System.Windows.Forms.Label();
            this.txtTienDichVu = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.panelThongTinPhieu.SuspendLayout();
            this.panelThongTinKhach.SuspendLayout();
            this.panelThongTinPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.panelDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.panelTongKet.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1150, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHI TIẾT PHIẾU ĐẶT PHÒNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelThongTinPhieu
            // 
            this.panelThongTinPhieu.BackColor = System.Drawing.Color.White;
            this.panelThongTinPhieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTinPhieu.Controls.Add(this.lblThongTinPhieu);
            this.panelThongTinPhieu.Controls.Add(this.lblSoPhieu);
            this.panelThongTinPhieu.Controls.Add(this.txtSoPhieu);
            this.panelThongTinPhieu.Controls.Add(this.lblNgayLap);
            this.panelThongTinPhieu.Controls.Add(this.txtNgayLap);
            this.panelThongTinPhieu.Controls.Add(this.lblTrangThai);
            this.panelThongTinPhieu.Controls.Add(this.txtTrangThai);
            this.panelThongTinPhieu.Controls.Add(this.lblNhanVien);
            this.panelThongTinPhieu.Controls.Add(this.txtNhanVien);
            this.panelThongTinPhieu.Location = new System.Drawing.Point(25, 90);
            this.panelThongTinPhieu.Name = "panelThongTinPhieu";
            this.panelThongTinPhieu.Size = new System.Drawing.Size(540, 180);
            this.panelThongTinPhieu.TabIndex = 1;
            // 
            // lblThongTinPhieu
            // 
            this.lblThongTinPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblThongTinPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThongTinPhieu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblThongTinPhieu.ForeColor = System.Drawing.Color.White;
            this.lblThongTinPhieu.Location = new System.Drawing.Point(0, 0);
            this.lblThongTinPhieu.Name = "lblThongTinPhieu";
            this.lblThongTinPhieu.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblThongTinPhieu.Size = new System.Drawing.Size(538, 40);
            this.lblThongTinPhieu.TabIndex = 0;
            this.lblThongTinPhieu.Text = "📋 THÔNG TIN PHIẾU";
            this.lblThongTinPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSoPhieu.Location = new System.Drawing.Point(20, 60);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(66, 17);
            this.lblSoPhieu.TabIndex = 1;
            this.lblSoPhieu.Text = "Số phiếu:";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtSoPhieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtSoPhieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.txtSoPhieu.Location = new System.Drawing.Point(130, 57);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(120, 25);
            this.txtSoPhieu.TabIndex = 2;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayLap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNgayLap.Location = new System.Drawing.Point(20, 100);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(67, 17);
            this.lblNgayLap.TabIndex = 3;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // txtNgayLap
            // 
            this.txtNgayLap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtNgayLap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNgayLap.Location = new System.Drawing.Point(130, 97);
            this.txtNgayLap.Name = "txtNgayLap";
            this.txtNgayLap.ReadOnly = true;
            this.txtNgayLap.Size = new System.Drawing.Size(120, 25);
            this.txtNgayLap.TabIndex = 4;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTrangThai.Location = new System.Drawing.Point(280, 60);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(75, 17);
            this.lblTrangThai.TabIndex = 5;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtTrangThai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.txtTrangThai.Location = new System.Drawing.Point(370, 57);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(150, 25);
            this.txtTrangThai.TabIndex = 6;
            this.txtTrangThai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNhanVien.Location = new System.Drawing.Point(280, 105);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(75, 17);
            this.lblNhanVien.TabIndex = 7;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNhanVien.Location = new System.Drawing.Point(370, 103);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.ReadOnly = true;
            this.txtNhanVien.Size = new System.Drawing.Size(150, 25);
            this.txtNhanVien.TabIndex = 8;
            // 
            // panelThongTinKhach
            // 
            this.panelThongTinKhach.BackColor = System.Drawing.Color.White;
            this.panelThongTinKhach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTinKhach.Controls.Add(this.lblThongTinKhach);
            this.panelThongTinKhach.Controls.Add(this.lblHoTen);
            this.panelThongTinKhach.Controls.Add(this.txtHoTen);
            this.panelThongTinKhach.Controls.Add(this.lblCCCD);
            this.panelThongTinKhach.Controls.Add(this.txtCCCD);
            this.panelThongTinKhach.Controls.Add(this.lblSDT);
            this.panelThongTinKhach.Controls.Add(this.txtSDT);
            this.panelThongTinKhach.Controls.Add(this.lblDiaChi);
            this.panelThongTinKhach.Controls.Add(this.txtDiaChi);
            this.panelThongTinKhach.Location = new System.Drawing.Point(585, 90);
            this.panelThongTinKhach.Name = "panelThongTinKhach";
            this.panelThongTinKhach.Size = new System.Drawing.Size(540, 180);
            this.panelThongTinKhach.TabIndex = 2;
            // 
            // lblThongTinKhach
            // 
            this.lblThongTinKhach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblThongTinKhach.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThongTinKhach.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblThongTinKhach.ForeColor = System.Drawing.Color.White;
            this.lblThongTinKhach.Location = new System.Drawing.Point(0, 0);
            this.lblThongTinKhach.Name = "lblThongTinKhach";
            this.lblThongTinKhach.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblThongTinKhach.Size = new System.Drawing.Size(538, 40);
            this.lblThongTinKhach.TabIndex = 0;
            this.lblThongTinKhach.Text = "👤 THÔNG TIN KHÁCH HÀNG";
            this.lblThongTinKhach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblHoTen.Location = new System.Drawing.Point(20, 60);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(54, 17);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Location = new System.Drawing.Point(80, 58);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(214, 25);
            this.txtHoTen.TabIndex = 2;
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCCCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblCCCD.Location = new System.Drawing.Point(19, 101);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(46, 17);
            this.lblCCCD.TabIndex = 3;
            this.lblCCCD.Text = "CCCD:";
            // 
            // txtCCCD
            // 
            this.txtCCCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtCCCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCCD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCCCD.Location = new System.Drawing.Point(80, 98);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.ReadOnly = true;
            this.txtCCCD.Size = new System.Drawing.Size(445, 25);
            this.txtCCCD.TabIndex = 4;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSDT.Location = new System.Drawing.Point(309, 60);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(37, 17);
            this.lblSDT.TabIndex = 5;
            this.lblSDT.Text = "SDT:";
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Location = new System.Drawing.Point(349, 58);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.ReadOnly = true;
            this.txtSDT.Size = new System.Drawing.Size(176, 25);
            this.txtSDT.TabIndex = 6;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDiaChi.Location = new System.Drawing.Point(20, 140);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(55, 17);
            this.lblDiaChi.TabIndex = 7;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Location = new System.Drawing.Point(80, 132);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(445, 25);
            this.txtDiaChi.TabIndex = 8;
            // 
            // panelThongTinPhong
            // 
            this.panelThongTinPhong.BackColor = System.Drawing.Color.White;
            this.panelThongTinPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTinPhong.Controls.Add(this.lblThongTinPhong);
            this.panelThongTinPhong.Controls.Add(this.lblNgayNhanPhong);
            this.panelThongTinPhong.Controls.Add(this.txtNgayNhanPhong);
            this.panelThongTinPhong.Controls.Add(this.lblNgayTraPhong);
            this.panelThongTinPhong.Controls.Add(this.txtNgayTraPhong);
            this.panelThongTinPhong.Controls.Add(this.lblSoGioO);
            this.panelThongTinPhong.Controls.Add(this.txtSoGioO);
            this.panelThongTinPhong.Controls.Add(this.lblSoNguoi);
            this.panelThongTinPhong.Controls.Add(this.txtSoNguoi);
            this.panelThongTinPhong.Controls.Add(this.dgvPhong);
            this.panelThongTinPhong.Location = new System.Drawing.Point(30, 290);
            this.panelThongTinPhong.Name = "panelThongTinPhong";
            this.panelThongTinPhong.Size = new System.Drawing.Size(535, 340);
            this.panelThongTinPhong.TabIndex = 3;
            // 
            // lblThongTinPhong
            // 
            this.lblThongTinPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblThongTinPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThongTinPhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblThongTinPhong.ForeColor = System.Drawing.Color.White;
            this.lblThongTinPhong.Location = new System.Drawing.Point(0, 0);
            this.lblThongTinPhong.Name = "lblThongTinPhong";
            this.lblThongTinPhong.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblThongTinPhong.Size = new System.Drawing.Size(533, 40);
            this.lblThongTinPhong.TabIndex = 0;
            this.lblThongTinPhong.Text = "🏨 THÔNG TIN PHÒNG";
            this.lblThongTinPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgayNhanPhong
            // 
            this.lblNgayNhanPhong.AutoSize = true;
            this.lblNgayNhanPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayNhanPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNgayNhanPhong.Location = new System.Drawing.Point(20, 60);
            this.lblNgayNhanPhong.Name = "lblNgayNhanPhong";
            this.lblNgayNhanPhong.Size = new System.Drawing.Size(123, 17);
            this.lblNgayNhanPhong.TabIndex = 1;
            this.lblNgayNhanPhong.Text = "Ngày nhận phòng:";
            // 
            // txtNgayNhanPhong
            // 
            this.txtNgayNhanPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtNgayNhanPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayNhanPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNgayNhanPhong.Location = new System.Drawing.Point(150, 57);
            this.txtNgayNhanPhong.Name = "txtNgayNhanPhong";
            this.txtNgayNhanPhong.ReadOnly = true;
            this.txtNgayNhanPhong.Size = new System.Drawing.Size(160, 25);
            this.txtNgayNhanPhong.TabIndex = 2;
            // 
            // lblNgayTraPhong
            // 
            this.lblNgayTraPhong.AutoSize = true;
            this.lblNgayTraPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayTraPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNgayTraPhong.Location = new System.Drawing.Point(20, 112);
            this.lblNgayTraPhong.Name = "lblNgayTraPhong";
            this.lblNgayTraPhong.Size = new System.Drawing.Size(109, 17);
            this.lblNgayTraPhong.TabIndex = 3;
            this.lblNgayTraPhong.Text = "Ngày trả phòng:";
            // 
            // txtNgayTraPhong
            // 
            this.txtNgayTraPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtNgayTraPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNgayTraPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNgayTraPhong.Location = new System.Drawing.Point(148, 110);
            this.txtNgayTraPhong.Name = "txtNgayTraPhong";
            this.txtNgayTraPhong.ReadOnly = true;
            this.txtNgayTraPhong.Size = new System.Drawing.Size(162, 25);
            this.txtNgayTraPhong.TabIndex = 4;
            // 
            // lblSoGioO
            // 
            this.lblSoGioO.AutoSize = true;
            this.lblSoGioO.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoGioO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSoGioO.Location = new System.Drawing.Point(339, 114);
            this.lblSoGioO.Name = "lblSoGioO";
            this.lblSoGioO.Size = new System.Drawing.Size(63, 17);
            this.lblSoGioO.TabIndex = 5;
            this.lblSoGioO.Text = "Số giờ ở:";
            // 
            // txtSoGioO
            // 
            this.txtSoGioO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtSoGioO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoGioO.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoGioO.Location = new System.Drawing.Point(422, 110);
            this.txtSoGioO.Name = "txtSoGioO";
            this.txtSoGioO.ReadOnly = true;
            this.txtSoGioO.Size = new System.Drawing.Size(93, 25);
            this.txtSoGioO.TabIndex = 6;
            // 
            // lblSoNguoi
            // 
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoNguoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSoNguoi.Location = new System.Drawing.Point(339, 60);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Size = new System.Drawing.Size(68, 17);
            this.lblSoNguoi.TabIndex = 7;
            this.lblSoNguoi.Text = "Số người:";
            // 
            // txtSoNguoi
            // 
            this.txtSoNguoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtSoNguoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoNguoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoNguoi.Location = new System.Drawing.Point(422, 58);
            this.txtSoNguoi.Name = "txtSoNguoi";
            this.txtSoNguoi.ReadOnly = true;
            this.txtSoNguoi.Size = new System.Drawing.Size(93, 25);
            this.txtSoNguoi.TabIndex = 8;
            // 
            // dgvPhong
            // 
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.AllowUserToResizeColumns = false;
            this.dgvPhong.AllowUserToResizeRows = false;
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhong.ColumnHeadersHeight = 35;
            this.dgvPhong.EnableHeadersVisualStyles = false;
            this.dgvPhong.Location = new System.Drawing.Point(15, 156);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.RowTemplate.Height = 30;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPhong.Size = new System.Drawing.Size(500, 151);
            this.dgvPhong.TabIndex = 9;
            // 
            // panelDichVu
            // 
            this.panelDichVu.BackColor = System.Drawing.Color.White;
            this.panelDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDichVu.Controls.Add(this.lblDichVu);
            this.panelDichVu.Controls.Add(this.dgvDichVu);
            this.panelDichVu.Location = new System.Drawing.Point(585, 290);
            this.panelDichVu.Name = "panelDichVu";
            this.panelDichVu.Size = new System.Drawing.Size(540, 240);
            this.panelDichVu.TabIndex = 4;
            // 
            // lblDichVu
            // 
            this.lblDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblDichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDichVu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDichVu.ForeColor = System.Drawing.Color.White;
            this.lblDichVu.Location = new System.Drawing.Point(0, 0);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblDichVu.Size = new System.Drawing.Size(538, 40);
            this.lblDichVu.TabIndex = 0;
            this.lblDichVu.Text = "🛎️ DỊCH VỤ";
            this.lblDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AllowUserToDeleteRows = false;
            this.dgvDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDichVu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDichVu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDichVu.ColumnHeadersHeight = 35;
            this.dgvDichVu.EnableHeadersVisualStyles = false;
            this.dgvDichVu.Location = new System.Drawing.Point(19, 43);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.ReadOnly = true;
            this.dgvDichVu.RowHeadersVisible = false;
            this.dgvDichVu.RowTemplate.Height = 30;
            this.dgvDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDichVu.Size = new System.Drawing.Size(500, 170);
            this.dgvDichVu.TabIndex = 1;
            // 
            // panelTongKet
            // 
            this.panelTongKet.BackColor = System.Drawing.Color.White;
            this.panelTongKet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTongKet.Controls.Add(this.lblTongKet);
            this.panelTongKet.Controls.Add(this.lblTienPhong);
            this.panelTongKet.Controls.Add(this.lblTongTien);
            this.panelTongKet.Controls.Add(this.txtTienPhong);
            this.panelTongKet.Controls.Add(this.lblTienDichVu);
            this.panelTongKet.Controls.Add(this.txtTienDichVu);
            this.panelTongKet.Controls.Add(this.txtTongTien);
            this.panelTongKet.Location = new System.Drawing.Point(584, 548);
            this.panelTongKet.Name = "panelTongKet";
            this.panelTongKet.Size = new System.Drawing.Size(540, 130);
            this.panelTongKet.TabIndex = 5;
            // 
            // lblTongKet
            // 
            this.lblTongKet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTongKet.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTongKet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongKet.ForeColor = System.Drawing.Color.White;
            this.lblTongKet.Location = new System.Drawing.Point(0, 0);
            this.lblTongKet.Name = "lblTongKet";
            this.lblTongKet.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.lblTongKet.Size = new System.Drawing.Size(538, 40);
            this.lblTongKet.TabIndex = 0;
            this.lblTongKet.Text = "💰 TỔNG KẾT";
            this.lblTongKet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTienPhong
            // 
            this.lblTienPhong.AutoSize = true;
            this.lblTienPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTienPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTienPhong.Location = new System.Drawing.Point(20, 50);
            this.lblTienPhong.Name = "lblTienPhong";
            this.lblTienPhong.Size = new System.Drawing.Size(83, 17);
            this.lblTienPhong.TabIndex = 1;
            this.lblTienPhong.Text = "Tiền phòng:";
            // 
            // txtTienPhong
            // 
            this.txtTienPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtTienPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTienPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.txtTienPhong.Location = new System.Drawing.Point(110, 47);
            this.txtTienPhong.Name = "txtTienPhong";
            this.txtTienPhong.ReadOnly = true;
            this.txtTienPhong.Size = new System.Drawing.Size(130, 25);
            this.txtTienPhong.TabIndex = 2;
            this.txtTienPhong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTienDichVu
            // 
            this.lblTienDichVu.AutoSize = true;
            this.lblTienDichVu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTienDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTienDichVu.Location = new System.Drawing.Point(250, 50);
            this.lblTienDichVu.Name = "lblTienDichVu";
            this.lblTienDichVu.Size = new System.Drawing.Size(88, 17);
            this.lblTienDichVu.TabIndex = 3;
            this.lblTienDichVu.Text = "Tiền dịch vụ:";
            // 
            // txtTienDichVu
            // 
            this.txtTienDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtTienDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienDichVu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTienDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.txtTienDichVu.Location = new System.Drawing.Point(350, 47);
            this.txtTienDichVu.Name = "txtTienDichVu";
            this.txtTienDichVu.ReadOnly = true;
            this.txtTienDichVu.Size = new System.Drawing.Size(170, 25);
            this.txtTienDichVu.TabIndex = 4;
            this.txtTienDichVu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTongTien
            // 
            this.lblTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongTien.Location = new System.Drawing.Point(-123, -1);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(500, 35);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "TỔNG TIỀN: ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(224)))));
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.txtTongTien.Location = new System.Drawing.Point(20, 85);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(500, 35);
            this.txtTongTien.TabIndex = 6;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(338, 650);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 40);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIn.FlatAppearance.BorderSize = 0;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Location = new System.Drawing.Point(222, 650);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(100, 40);
            this.btnIn.TabIndex = 7;
            this.btnIn.Text = "🖨️ In";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmChiTietDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1150, 710);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.panelTongKet);
            this.Controls.Add(this.panelDichVu);
            this.Controls.Add(this.panelThongTinPhong);
            this.Controls.Add(this.panelThongTinKhach);
            this.Controls.Add(this.panelThongTinPhieu);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmChiTietDatPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Phiếu Đặt Phòng";
            this.Load += new System.EventHandler(this.frmChiTietDatPhong_Load);
            this.panelThongTinPhieu.ResumeLayout(false);
            this.panelThongTinPhieu.PerformLayout();
            this.panelThongTinKhach.ResumeLayout(false);
            this.panelThongTinKhach.PerformLayout();
            this.panelThongTinPhong.ResumeLayout(false);
            this.panelThongTinPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.panelDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.panelTongKet.ResumeLayout(false);
            this.panelTongKet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
