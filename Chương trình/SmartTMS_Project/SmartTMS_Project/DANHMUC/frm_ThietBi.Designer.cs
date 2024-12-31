namespace SmartTMS_Project.DANHMUC
{
    partial class frm_ThietBi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ThietBi));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnKeThua = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnBoQua = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaTB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenThietBi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoaiPT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThoiHanKiemTra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoLuongConLai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KhongSuDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboThoiHanKiemTra = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtSoLuongTon = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLoaiPT = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tgsKhongSuDung = new DevExpress.XtraEditors.ToggleSwitch();
            this.txtDonGia = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenTB = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaTB = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboThoiHanKiemTra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongTon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiPT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgsKhongSuDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTB.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnKeThua,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnBoQua,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(1807, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(78, 856);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "Thanh công cụ";
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(73, 57);
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnKeThua
            // 
            this.btnKeThua.Image = ((System.Drawing.Image)(resources.GetObject("btnKeThua.Image")));
            this.btnKeThua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKeThua.Name = "btnKeThua";
            this.btnKeThua.Size = new System.Drawing.Size(73, 57);
            this.btnKeThua.Text = "Kế thừa";
            this.btnKeThua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKeThua.Click += new System.EventHandler(this.btnKeThua_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(73, 57);
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(73, 57);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(73, 57);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoQua.Image")));
            this.btnBoQua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(73, 57);
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(73, 57);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcDanhSach);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1807, 856);
            this.splitContainer1.SplitterDistance = 1189;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gcDanhSach.Location = new System.Drawing.Point(0, 0);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(1189, 856);
            this.gcDanhSach.TabIndex = 0;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaTB,
            this.TenThietBi,
            this.LoaiPT,
            this.ThoiHanKiemTra,
            this.DonGia,
            this.SoLuongConLai,
            this.KhongSuDung,
            this.GhiChu});
            this.gvDanhSach.DetailHeight = 433;
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvDanhSach.OptionsFind.AlwaysVisible = true;
            this.gvDanhSach.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.gvDanhSach.OptionsFind.FindNullPrompt = "Nhập từ khóa cần tìm kiếm...";
            this.gvDanhSach.Click += new System.EventHandler(this.gvDanhSach_Click);
            // 
            // MaTB
            // 
            this.MaTB.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.MaTB.AppearanceHeader.Options.UseFont = true;
            this.MaTB.Caption = "Mã thiết bị";
            this.MaTB.FieldName = "MaTB";
            this.MaTB.MaxWidth = 128;
            this.MaTB.MinWidth = 32;
            this.MaTB.Name = "MaTB";
            this.MaTB.Visible = true;
            this.MaTB.VisibleIndex = 1;
            this.MaTB.Width = 65;
            // 
            // TenThietBi
            // 
            this.TenThietBi.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.TenThietBi.AppearanceHeader.Options.UseFont = true;
            this.TenThietBi.Caption = "Tên thiết bị";
            this.TenThietBi.FieldName = "TenThietBi";
            this.TenThietBi.MaxWidth = 322;
            this.TenThietBi.MinWidth = 32;
            this.TenThietBi.Name = "TenThietBi";
            this.TenThietBi.Visible = true;
            this.TenThietBi.VisibleIndex = 2;
            this.TenThietBi.Width = 121;
            // 
            // LoaiPT
            // 
            this.LoaiPT.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.LoaiPT.AppearanceHeader.Options.UseFont = true;
            this.LoaiPT.Caption = "Loại phương tiện";
            this.LoaiPT.FieldName = "LoaiPT";
            this.LoaiPT.MinWidth = 32;
            this.LoaiPT.Name = "LoaiPT";
            this.LoaiPT.Visible = true;
            this.LoaiPT.VisibleIndex = 3;
            this.LoaiPT.Width = 121;
            // 
            // ThoiHanKiemTra
            // 
            this.ThoiHanKiemTra.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.ThoiHanKiemTra.AppearanceHeader.Options.UseFont = true;
            this.ThoiHanKiemTra.Caption = "Thời hạn kiểm tra";
            this.ThoiHanKiemTra.FieldName = "ThoiHanKiemTra";
            this.ThoiHanKiemTra.MaxWidth = 322;
            this.ThoiHanKiemTra.MinWidth = 32;
            this.ThoiHanKiemTra.Name = "ThoiHanKiemTra";
            this.ThoiHanKiemTra.Visible = true;
            this.ThoiHanKiemTra.VisibleIndex = 6;
            this.ThoiHanKiemTra.Width = 121;
            // 
            // DonGia
            // 
            this.DonGia.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.DonGia.AppearanceHeader.Options.UseFont = true;
            this.DonGia.Caption = "Đơn giá";
            this.DonGia.FieldName = "DonGia";
            this.DonGia.MaxWidth = 193;
            this.DonGia.MinWidth = 32;
            this.DonGia.Name = "DonGia";
            this.DonGia.Visible = true;
            this.DonGia.VisibleIndex = 4;
            this.DonGia.Width = 121;
            // 
            // SoLuongConLai
            // 
            this.SoLuongConLai.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.SoLuongConLai.AppearanceHeader.Options.UseFont = true;
            this.SoLuongConLai.Caption = "Số lượng";
            this.SoLuongConLai.FieldName = "SoLuongConLai";
            this.SoLuongConLai.MaxWidth = 385;
            this.SoLuongConLai.MinWidth = 32;
            this.SoLuongConLai.Name = "SoLuongConLai";
            this.SoLuongConLai.Visible = true;
            this.SoLuongConLai.VisibleIndex = 5;
            this.SoLuongConLai.Width = 121;
            // 
            // KhongSuDung
            // 
            this.KhongSuDung.FieldName = "KhongSuDung";
            this.KhongSuDung.MaxWidth = 38;
            this.KhongSuDung.MinWidth = 32;
            this.KhongSuDung.Name = "KhongSuDung";
            this.KhongSuDung.Visible = true;
            this.KhongSuDung.VisibleIndex = 0;
            this.KhongSuDung.Width = 32;
            // 
            // GhiChu
            // 
            this.GhiChu.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.GhiChu.AppearanceHeader.Options.UseFont = true;
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.MinWidth = 32;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 121;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.cboThoiHanKiemTra);
            this.groupControl1.Controls.Add(this.txtSoLuongTon);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.cboLoaiPT);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.txtGhiChu);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.tgsKhongSuDung);
            this.groupControl1.Controls.Add(this.txtDonGia);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.txtTenTB);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtMaTB);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(613, 856);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin thiết bị";
            // 
            // cboThoiHanKiemTra
            // 
            this.cboThoiHanKiemTra.Location = new System.Drawing.Point(27, 398);
            this.cboThoiHanKiemTra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboThoiHanKiemTra.Name = "cboThoiHanKiemTra";
            this.cboThoiHanKiemTra.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThoiHanKiemTra.Properties.Items.AddRange(new object[] {
            "1 tháng ",
            "3 tháng",
            "6 tháng",
            "12 tháng",
            "24 tháng",
            "36 tháng",
            "Không có thời hạn"});
            this.cboThoiHanKiemTra.Size = new System.Drawing.Size(542, 42);
            this.cboThoiHanKiemTra.TabIndex = 23;
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(27, 588);
            this.txtSoLuongTon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(542, 42);
            this.txtSoLuongTon.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 549);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Số lượng còn lại trong kho";
            // 
            // cboLoaiPT
            // 
            this.cboLoaiPT.Location = new System.Drawing.Point(27, 303);
            this.cboLoaiPT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboLoaiPT.Name = "cboLoaiPT";
            this.cboLoaiPT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiPT.Properties.Items.AddRange(new object[] {
            "Container",
            "Xe tải > 100 tấn",
            "Xe tải < 100 tấn ",
            "Xe tải >10 tấn",
            "Xe tải < 10 tấn",
            "Xe van",
            "Xe máy"});
            this.cboLoaiPT.Size = new System.Drawing.Size(542, 42);
            this.cboLoaiPT.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 264);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Loại phương tiện sử dụng";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(27, 683);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(542, 152);
            this.txtGhiChu.TabIndex = 16;
            this.txtGhiChu.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 644);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ghi chú";
            // 
            // tgsKhongSuDung
            // 
            this.tgsKhongSuDung.Location = new System.Drawing.Point(355, 117);
            this.tgsKhongSuDung.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tgsKhongSuDung.Name = "tgsKhongSuDung";
            this.tgsKhongSuDung.Properties.OffText = "Không sử dụng";
            this.tgsKhongSuDung.Properties.OnText = "Sử dụng";
            this.tgsKhongSuDung.Size = new System.Drawing.Size(214, 34);
            this.tgsKhongSuDung.TabIndex = 13;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(27, 493);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(542, 42);
            this.txtDonGia.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 454);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đơn giá thiết bị (VNĐ)";
            // 
            // txtTenTB
            // 
            this.txtTenTB.Location = new System.Drawing.Point(27, 208);
            this.txtTenTB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTenTB.Name = "txtTenTB";
            this.txtTenTB.Size = new System.Drawing.Size(542, 42);
            this.txtTenTB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 359);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Thời hạn định kỳ kiểm tra (tháng)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên thiết bị";
            // 
            // txtMaTB
            // 
            this.txtMaTB.Location = new System.Drawing.Point(27, 113);
            this.txtMaTB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMaTB.Name = "txtMaTB";
            this.txtMaTB.Size = new System.Drawing.Size(295, 42);
            this.txtMaTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã thiết bị";
            // 
            // frm_ThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1885, 856);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.IconOptions.Image = global::SmartTMS_Project.Properties.Resources.LOGO_TMS_2;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frm_ThietBi";
            this.Text = "Thiết bị";
            this.Load += new System.EventHandler(this.frm_ThietBi_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.cboThoiHanKiemTra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongTon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiPT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgsKhongSuDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTB.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn MaTB;
        private DevExpress.XtraGrid.Columns.GridColumn TenThietBi;
        private DevExpress.XtraGrid.Columns.GridColumn LoaiPT;
        private DevExpress.XtraGrid.Columns.GridColumn ThoiHanKiemTra;
        private DevExpress.XtraGrid.Columns.GridColumn DonGia;
        private DevExpress.XtraGrid.Columns.GridColumn SoLuongConLai;
        private DevExpress.XtraGrid.Columns.GridColumn KhongSuDung;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ToggleSwitch tgsKhongSuDung;
        private DevExpress.XtraEditors.TextEdit txtDonGia;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtTenTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtMaTB;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtSoLuongTon;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.ComboBoxEdit cboLoaiPT;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ComboBoxEdit cboThoiHanKiemTra;
        private System.Windows.Forms.ToolStripButton btnKeThua;
    }
}