namespace QuanLyKhachSan
{
    partial class frmMain
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

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnSoDo;
        private System.Windows.Forms.Button btnQLDatPhong;
        private System.Windows.Forms.Button btnQLPhong;
        private System.Windows.Forms.Button btnQLDichVu;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnQLTaiKhoan;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label lbChaoUser;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.ComboBox cboLoaiGiuong;
        private System.Windows.Forms.Label lbLoaiGiuong;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lbTrangThai;
        private System.Windows.Forms.ComboBox cboLoaiPhong;
        private System.Windows.Forms.Label lbLoaiPhong;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.FlowLayoutPanel flpRoomLayout;
        private System.Windows.Forms.ContextMenuStrip contextMenuPhong;
        private System.Windows.Forms.ToolStripMenuItem itemCheckIn;
        private System.Windows.Forms.ToolStripMenuItem itemThanhToan;
        private System.Windows.Forms.ToolStripMenuItem itemThemDichVu;
        private System.Windows.Forms.ToolStripMenuItem itemChuyenPhong;
        private System.Windows.Forms.ToolStripMenuItem itemDaDonXong;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lbChaoUser = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnQLTaiKhoan = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnQLDichVu = new System.Windows.Forms.Button();
            this.btnQLPhong = new System.Windows.Forms.Button();
            this.btnQLDatPhong = new System.Windows.Forms.Button();
            this.btnSoDo = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.cboLoaiGiuong = new System.Windows.Forms.ComboBox();
            this.lbLoaiGiuong = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lbTrangThai = new System.Windows.Forms.Label();
            this.cboLoaiPhong = new System.Windows.Forms.ComboBox();
            this.lbLoaiPhong = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.flpRoomLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuPhong = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.itemThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.itemThemDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemChuyenPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDaDonXong = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.contextMenuPhong.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelSidebar.Controls.Add(this.lbChaoUser);
            this.panelSidebar.Controls.Add(this.btnDangXuat);
            this.panelSidebar.Controls.Add(this.btnQLTaiKhoan);
            this.panelSidebar.Controls.Add(this.btnBaoCao);
            this.panelSidebar.Controls.Add(this.btnQLDichVu);
            this.panelSidebar.Controls.Add(this.btnQLPhong);
            this.panelSidebar.Controls.Add(this.btnQLDatPhong);
            this.panelSidebar.Controls.Add(this.btnSoDo);
            this.panelSidebar.Controls.Add(this.pbLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(333, 862);
            this.panelSidebar.TabIndex = 0;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebar_Paint);
            // 
            // lbChaoUser
            // 
            this.lbChaoUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lbChaoUser.ForeColor = System.Drawing.Color.White;
            this.lbChaoUser.Location = new System.Drawing.Point(13, 788);
            this.lbChaoUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbChaoUser.Name = "lbChaoUser";
            this.lbChaoUser.Size = new System.Drawing.Size(307, 49);
            this.lbChaoUser.TabIndex = 7;
            this.lbChaoUser.Text = "Chào user";
            this.lbChaoUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(27, 714);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(280, 62);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnQLTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnQLTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQLTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnQLTaiKhoan.Location = new System.Drawing.Point(27, 550);
            this.btnQLTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.Size = new System.Drawing.Size(280, 62);
            this.btnQLTaiKhoan.TabIndex = 5;
            this.btnQLTaiKhoan.Text = "QL Tài khoản";
            this.btnQLTaiKhoan.UseVisualStyleBackColor = false;
            this.btnQLTaiKhoan.Click += new System.EventHandler(this.btnQLTaiKhoan_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.Location = new System.Drawing.Point(27, 620);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(280, 62);
            this.btnBaoCao.TabIndex = 4;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = false;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnQLDichVu
            // 
            this.btnQLDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnQLDichVu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLDichVu.FlatAppearance.BorderSize = 0;
            this.btnQLDichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLDichVu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQLDichVu.ForeColor = System.Drawing.Color.White;
            this.btnQLDichVu.Location = new System.Drawing.Point(27, 480);
            this.btnQLDichVu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQLDichVu.Name = "btnQLDichVu";
            this.btnQLDichVu.Size = new System.Drawing.Size(280, 62);
            this.btnQLDichVu.TabIndex = 3;
            this.btnQLDichVu.Text = "QL Dịch vụ";
            this.btnQLDichVu.UseVisualStyleBackColor = false;
            this.btnQLDichVu.Click += new System.EventHandler(this.btnQLDichVu_Click);
            // 
            // btnQLPhong
            // 
            this.btnQLPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnQLPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLPhong.FlatAppearance.BorderSize = 0;
            this.btnQLPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLPhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQLPhong.ForeColor = System.Drawing.Color.White;
            this.btnQLPhong.Location = new System.Drawing.Point(27, 406);
            this.btnQLPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQLPhong.Name = "btnQLPhong";
            this.btnQLPhong.Size = new System.Drawing.Size(280, 62);
            this.btnQLPhong.TabIndex = 2;
            this.btnQLPhong.Text = "QL Phòng";
            this.btnQLPhong.UseVisualStyleBackColor = false;
            this.btnQLPhong.Click += new System.EventHandler(this.btnQLPhong_Click);
            // 
            // btnQLDatPhong
            // 
            this.btnQLDatPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnQLDatPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQLDatPhong.FlatAppearance.BorderSize = 0;
            this.btnQLDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLDatPhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQLDatPhong.ForeColor = System.Drawing.Color.White;
            this.btnQLDatPhong.Location = new System.Drawing.Point(27, 332);
            this.btnQLDatPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQLDatPhong.Name = "btnQLDatPhong";
            this.btnQLDatPhong.Size = new System.Drawing.Size(280, 62);
            this.btnQLDatPhong.TabIndex = 8;
            this.btnQLDatPhong.Text = "QL Đặt phòng";
            this.btnQLDatPhong.UseVisualStyleBackColor = false;
            this.btnQLDatPhong.Click += new System.EventHandler(this.btnQLDatPhong_Click);
            // 
            // btnSoDo
            // 
            this.btnSoDo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSoDo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoDo.FlatAppearance.BorderSize = 0;
            this.btnSoDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoDo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSoDo.ForeColor = System.Drawing.Color.White;
            this.btnSoDo.Location = new System.Drawing.Point(27, 258);
            this.btnSoDo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSoDo.Name = "btnSoDo";
            this.btnSoDo.Size = new System.Drawing.Size(280, 62);
            this.btnSoDo.TabIndex = 1;
            this.btnSoDo.Text = "Sơ đồ phòng";
            this.btnSoDo.UseVisualStyleBackColor = false;
            this.btnSoDo.Click += new System.EventHandler(this.btnSoDo_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(67, 37);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 185);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelTop.Controls.Add(this.lbTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(333, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 74);
            this.panelTop.TabIndex = 1;
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lbTieuDe.ForeColor = System.Drawing.Color.White;
            this.lbTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lbTieuDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(1400, 74);
            this.lbTieuDe.TabIndex = 0;
            this.lbTieuDe.Text = "SƠ ĐỒ PHÒNG";
            this.lbTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.cboLoaiGiuong);
            this.panelFilter.Controls.Add(this.lbLoaiGiuong);
            this.panelFilter.Controls.Add(this.cboTrangThai);
            this.panelFilter.Controls.Add(this.lbTrangThai);
            this.panelFilter.Controls.Add(this.cboLoaiPhong);
            this.panelFilter.Controls.Add(this.lbLoaiPhong);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(333, 74);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(27, 18, 27, 18);
            this.panelFilter.Size = new System.Drawing.Size(1400, 86);
            this.panelFilter.TabIndex = 3;
            // 
            // cboLoaiGiuong
            // 
            this.cboLoaiGiuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiGiuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiGiuong.FormattingEnabled = true;
            this.cboLoaiGiuong.Location = new System.Drawing.Point(1067, 31);
            this.cboLoaiGiuong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLoaiGiuong.Name = "cboLoaiGiuong";
            this.cboLoaiGiuong.Size = new System.Drawing.Size(265, 31);
            this.cboLoaiGiuong.TabIndex = 5;
            this.cboLoaiGiuong.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lbLoaiGiuong
            // 
            this.lbLoaiGiuong.AutoSize = true;
            this.lbLoaiGiuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbLoaiGiuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lbLoaiGiuong.Location = new System.Drawing.Point(920, 34);
            this.lbLoaiGiuong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLoaiGiuong.Name = "lbLoaiGiuong";
            this.lbLoaiGiuong.Size = new System.Drawing.Size(112, 23);
            this.lbLoaiGiuong.TabIndex = 4;
            this.lbLoaiGiuong.Text = "Loại giường:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(600, 31);
            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(265, 31);
            this.cboTrangThai.TabIndex = 3;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lbTrangThai
            // 
            this.lbTrangThai.AutoSize = true;
            this.lbTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lbTrangThai.Location = new System.Drawing.Point(480, 34);
            this.lbTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTrangThai.Name = "lbTrangThai";
            this.lbTrangThai.Size = new System.Drawing.Size(97, 23);
            this.lbTrangThai.TabIndex = 2;
            this.lbTrangThai.Text = "Trạng thái:";
            // 
            // cboLoaiPhong
            // 
            this.cboLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiPhong.FormattingEnabled = true;
            this.cboLoaiPhong.Location = new System.Drawing.Point(160, 31);
            this.cboLoaiPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLoaiPhong.Name = "cboLoaiPhong";
            this.cboLoaiPhong.Size = new System.Drawing.Size(265, 31);
            this.cboLoaiPhong.TabIndex = 1;
            this.cboLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // lbLoaiPhong
            // 
            this.lbLoaiPhong.AutoSize = true;
            this.lbLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbLoaiPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lbLoaiPhong.Location = new System.Drawing.Point(27, 34);
            this.lbLoaiPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLoaiPhong.Name = "lbLoaiPhong";
            this.lbLoaiPhong.Size = new System.Drawing.Size(105, 23);
            this.lbLoaiPhong.TabIndex = 0;
            this.lbLoaiPhong.Text = "Loại phòng:";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelMain.Controls.Add(this.flpRoomLayout);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(333, 160);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panelMain.Size = new System.Drawing.Size(1400, 702);
            this.panelMain.TabIndex = 2;
            // 
            // flpRoomLayout
            // 
            this.flpRoomLayout.AutoScroll = true;
            this.flpRoomLayout.BackColor = System.Drawing.Color.White;
            this.flpRoomLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRoomLayout.Location = new System.Drawing.Point(27, 25);
            this.flpRoomLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpRoomLayout.Name = "flpRoomLayout";
            this.flpRoomLayout.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.flpRoomLayout.Size = new System.Drawing.Size(1346, 652);
            this.flpRoomLayout.TabIndex = 0;
            // 
            // contextMenuPhong
            // 
            this.contextMenuPhong.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuPhong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCheckIn,
            this.itemThanhToan,
            this.itemThemDichVu,
            this.itemChuyenPhong,
            this.itemDaDonXong});
            this.contextMenuPhong.Name = "contextMenuPhong";
            this.contextMenuPhong.Size = new System.Drawing.Size(227, 124);
            this.contextMenuPhong.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuPhong_Opening);
            // 
            // itemCheckIn
            // 
            this.itemCheckIn.Name = "itemCheckIn";
            this.itemCheckIn.Size = new System.Drawing.Size(226, 24);
            this.itemCheckIn.Text = "Check-in";
            this.itemCheckIn.Click += new System.EventHandler(this.itemCheckIn_Click);
            // 
            // itemThanhToan
            // 
            this.itemThanhToan.Name = "itemThanhToan";
            this.itemThanhToan.Size = new System.Drawing.Size(226, 24);
            this.itemThanhToan.Text = "Thanh toán";
            this.itemThanhToan.Click += new System.EventHandler(this.itemThanhToan_Click);
            // 
            // itemThemDichVu
            // 
            this.itemThemDichVu.Name = "itemThemDichVu";
            this.itemThemDichVu.Size = new System.Drawing.Size(226, 24);
            this.itemThemDichVu.Text = "Thêm dịch vụ";
            this.itemThemDichVu.Click += new System.EventHandler(this.itemThemDichVu_Click);
            // 
            // itemChuyenPhong
            // 
            this.itemChuyenPhong.Name = "itemChuyenPhong";
            this.itemChuyenPhong.Size = new System.Drawing.Size(226, 24);
            this.itemChuyenPhong.Text = "Chuyển phòng";
            this.itemChuyenPhong.Click += new System.EventHandler(this.itemChuyenPhong_Click);
            // 
            // itemDaDonXong
            // 
            this.itemDaDonXong.Name = "itemDaDonXong";
            this.itemDaDonXong.Size = new System.Drawing.Size(226, 24);
            this.itemDaDonXong.Text = "Xác nhận đã dọn xong";
            this.itemDaDonXong.Click += new System.EventHandler(this.itemDaDonXong_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 862);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSidebar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Khách Sạn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.contextMenuPhong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
