namespace SmartTMS_Project.HETHONG
{
    partial class frm_TaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TaiKhoan));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnBoQua = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDangNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MatKhau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDayDu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoaiTaiKhoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KhoaTaiKhoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboDonVi = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDangNhapLanCuoi = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.cboLoaiTaiKhoan = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.tgsKhongSuDung = new DevExpress.XtraEditors.ToggleSwitch();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaTK = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.DangNhapLanCuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDangNhapLanCuoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiTaiKhoan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgsKhongSuDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnBoQua,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(1863, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(75, 805);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "Thanh công cụ";
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(68, 57);
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(68, 57);
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(68, 57);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(68, 57);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoQua.Image")));
            this.btnBoQua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(68, 57);
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(68, 57);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcDanhSach);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1863, 805);
            this.splitContainer1.SplitterDistance = 1224;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcDanhSach.Location = new System.Drawing.Point(0, 0);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(1224, 805);
            this.gcDanhSach.TabIndex = 0;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaTK,
            this.TenDangNhap,
            this.MatKhau,
            this.MaNV,
            this.TenDayDu,
            this.LoaiTaiKhoan,
            this.MaDonVi,
            this.KhoaTaiKhoan,
            this.DangNhapLanCuoi});
            this.gvDanhSach.DetailHeight = 432;
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvDanhSach.OptionsFind.AlwaysVisible = true;
            this.gvDanhSach.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.gvDanhSach.OptionsFind.FindNullPrompt = "Nhập từ khóa cần tìm kiếm...";
            this.gvDanhSach.Click += new System.EventHandler(this.gvDanhSach_Click);
            // 
            // MaTK
            // 
            this.MaTK.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.MaTK.AppearanceHeader.Options.UseFont = true;
            this.MaTK.Caption = "Mã tài khoản";
            this.MaTK.FieldName = "MaTK";
            this.MaTK.MaxWidth = 150;
            this.MaTK.MinWidth = 150;
            this.MaTK.Name = "MaTK";
            this.MaTK.Visible = true;
            this.MaTK.VisibleIndex = 1;
            this.MaTK.Width = 150;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.TenDangNhap.AppearanceHeader.Options.UseFont = true;
            this.TenDangNhap.Caption = "Tên đăng nhập";
            this.TenDangNhap.FieldName = "TenDangNhap";
            this.TenDangNhap.MaxWidth = 150;
            this.TenDangNhap.MinWidth = 150;
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.Visible = true;
            this.TenDangNhap.VisibleIndex = 2;
            this.TenDangNhap.Width = 150;
            // 
            // MatKhau
            // 
            this.MatKhau.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.MatKhau.AppearanceHeader.Options.UseFont = true;
            this.MatKhau.Caption = "Mật khẩu";
            this.MatKhau.FieldName = "MatKhau";
            this.MatKhau.MaxWidth = 150;
            this.MatKhau.MinWidth = 150;
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Width = 150;
            // 
            // MaNV
            // 
            this.MaNV.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.MaNV.AppearanceHeader.Options.UseFont = true;
            this.MaNV.Caption = "Mã Nhân Viên";
            this.MaNV.FieldName = "MaNV";
            this.MaNV.MaxWidth = 321;
            this.MaNV.MinWidth = 32;
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 121;
            // 
            // TenDayDu
            // 
            this.TenDayDu.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.TenDayDu.AppearanceHeader.Options.UseFont = true;
            this.TenDayDu.Caption = "Nhân viên";
            this.TenDayDu.FieldName = "TenDayDu";
            this.TenDayDu.MaxWidth = 150;
            this.TenDayDu.MinWidth = 150;
            this.TenDayDu.Name = "TenDayDu";
            this.TenDayDu.Visible = true;
            this.TenDayDu.VisibleIndex = 5;
            this.TenDayDu.Width = 150;
            // 
            // LoaiTaiKhoan
            // 
            this.LoaiTaiKhoan.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.LoaiTaiKhoan.AppearanceHeader.Options.UseFont = true;
            this.LoaiTaiKhoan.Caption = "Loại tài khoản";
            this.LoaiTaiKhoan.FieldName = "LoaiTaiKhoan";
            this.LoaiTaiKhoan.MaxWidth = 150;
            this.LoaiTaiKhoan.MinWidth = 150;
            this.LoaiTaiKhoan.Name = "LoaiTaiKhoan";
            this.LoaiTaiKhoan.Visible = true;
            this.LoaiTaiKhoan.VisibleIndex = 3;
            this.LoaiTaiKhoan.Width = 150;
            // 
            // MaDonVi
            // 
            this.MaDonVi.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.MaDonVi.AppearanceHeader.Options.UseFont = true;
            this.MaDonVi.Caption = "Đơn vị";
            this.MaDonVi.FieldName = "MaDonVi";
            this.MaDonVi.MaxWidth = 150;
            this.MaDonVi.MinWidth = 150;
            this.MaDonVi.Name = "MaDonVi";
            this.MaDonVi.Visible = true;
            this.MaDonVi.VisibleIndex = 4;
            this.MaDonVi.Width = 150;
            // 
            // KhoaTaiKhoan
            // 
            this.KhoaTaiKhoan.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.KhoaTaiKhoan.AppearanceHeader.Options.UseFont = true;
            this.KhoaTaiKhoan.Caption = "Khóa tài khoản";
            this.KhoaTaiKhoan.FieldName = "KhoaTaiKhoan";
            this.KhoaTaiKhoan.MaxWidth = 150;
            this.KhoaTaiKhoan.MinWidth = 150;
            this.KhoaTaiKhoan.Name = "KhoaTaiKhoan";
            this.KhoaTaiKhoan.Visible = true;
            this.KhoaTaiKhoan.VisibleIndex = 0;
            this.KhoaTaiKhoan.Width = 150;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.cboDonVi);
            this.groupControl1.Controls.Add(this.txtDangNhapLanCuoi);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.cboLoaiTaiKhoan);
            this.groupControl1.Controls.Add(this.txtMatKhau);
            this.groupControl1.Controls.Add(this.tgsKhongSuDung);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.txtHoTen);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.txtTenDangNhap);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtMaTK);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(634, 805);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin tài khoản";
            // 
            // cboDonVi
            // 
            this.cboDonVi.Location = new System.Drawing.Point(41, 601);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDonVi.Properties.NullText = "Chọn đơn vị";
            this.cboDonVi.Size = new System.Drawing.Size(536, 42);
            this.cboDonVi.TabIndex = 19;
            // 
            // txtDangNhapLanCuoi
            // 
            this.txtDangNhapLanCuoi.Location = new System.Drawing.Point(41, 702);
            this.txtDangNhapLanCuoi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDangNhapLanCuoi.Name = "txtDangNhapLanCuoi";
            this.txtDangNhapLanCuoi.Properties.ReadOnly = true;
            this.txtDangNhapLanCuoi.Size = new System.Drawing.Size(541, 42);
            this.txtDangNhapLanCuoi.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 660);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Đăng nhập lần cuối";
            // 
            // cboLoaiTaiKhoan
            // 
            this.cboLoaiTaiKhoan.Location = new System.Drawing.Point(41, 502);
            this.cboLoaiTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.cboLoaiTaiKhoan.Name = "cboLoaiTaiKhoan";
            this.cboLoaiTaiKhoan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiTaiKhoan.Properties.Items.AddRange(new object[] {
            "NhanVien",
            "TaiXe",
            "KhachHang"});
            this.cboLoaiTaiKhoan.Size = new System.Drawing.Size(541, 42);
            this.cboLoaiTaiKhoan.TabIndex = 16;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(41, 308);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(541, 42);
            this.txtMatKhau.TabIndex = 15;
            // 
            // tgsKhongSuDung
            // 
            this.tgsKhongSuDung.Location = new System.Drawing.Point(372, 107);
            this.tgsKhongSuDung.Margin = new System.Windows.Forms.Padding(4);
            this.tgsKhongSuDung.Name = "tgsKhongSuDung";
            this.tgsKhongSuDung.Properties.OffText = "Không khóa";
            this.tgsKhongSuDung.Properties.OnText = "Khóa";
            this.tgsKhongSuDung.Size = new System.Drawing.Size(213, 34);
            this.tgsKhongSuDung.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 462);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Loại tài khoản";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(41, 405);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(541, 42);
            this.txtHoTen.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 365);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Họ và tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 559);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đơn vị trực thuộc";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(41, 211);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(541, 42);
            this.txtTenDangNhap.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 268);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đăng nhập";
            // 
            // txtMaTK
            // 
            this.txtMaTK.Location = new System.Drawing.Point(41, 114);
            this.txtMaTK.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTK.Name = "txtMaTK";
            this.txtMaTK.Size = new System.Drawing.Size(296, 42);
            this.txtMaTK.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID tài khoản";
            // 
            // DangNhapLanCuoi
            // 
            this.DangNhapLanCuoi.Caption = "Đăng nhập lần cuối";
            this.DangNhapLanCuoi.FieldName = "DangNhapLanCuoi";
            this.DangNhapLanCuoi.MinWidth = 30;
            this.DangNhapLanCuoi.Name = "DangNhapLanCuoi";
            this.DangNhapLanCuoi.Width = 112;
            // 
            // frm_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1938, 805);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.IconOptions.Image = global::SmartTMS_Project.Properties.Resources.LOGO_TMS_2;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_TaiKhoan";
            this.Text = "Tài khoản và Quyền";
            this.Load += new System.EventHandler(this.frm_TaiKhoan_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDangNhapLanCuoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiTaiKhoan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgsKhongSuDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTK.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnBoQua;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn MaTK;
        private DevExpress.XtraGrid.Columns.GridColumn TenDangNhap;
        private DevExpress.XtraGrid.Columns.GridColumn MatKhau;
        private DevExpress.XtraGrid.Columns.GridColumn MaNV;
        private DevExpress.XtraGrid.Columns.GridColumn LoaiTaiKhoan;
        private DevExpress.XtraGrid.Columns.GridColumn MaDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn KhoaTaiKhoan;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ToggleSwitch tgsKhongSuDung;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtTenDangNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtMaTK;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cboLoaiTaiKhoan;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraGrid.Columns.GridColumn TenDayDu;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtDangNhapLanCuoi;
        private DevExpress.XtraEditors.LookUpEdit cboDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn DangNhapLanCuoi;
    }
}