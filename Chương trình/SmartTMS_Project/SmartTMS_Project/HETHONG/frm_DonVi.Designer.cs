namespace SmartTMS_Project.HETHONG
{
    partial class frm_DonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DonVi));
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
            this.MaDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KhongSuDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtGhiChu = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.RichTextBox();
            this.tgsKhongSuDung = new DevExpress.XtraEditors.ToggleSwitch();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDienThoai = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenDonVi = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaDonVi = new DevExpress.XtraEditors.TextEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.tgsKhongSuDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDonVi.Properties)).BeginInit();
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
            this.toolStrip1.Location = new System.Drawing.Point(1830, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(75, 971);
            this.toolStrip1.TabIndex = 0;
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcDanhSach);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1830, 971);
            this.splitContainer1.SplitterDistance = 1181;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcDanhSach.Location = new System.Drawing.Point(0, 0);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(1181, 971);
            this.gcDanhSach.TabIndex = 0;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaDonVi,
            this.TenDonVi,
            this.SoDT,
            this.DiaChi,
            this.Email,
            this.KhongSuDung,
            this.GhiChu});
            this.gvDanhSach.DetailHeight = 432;
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvDanhSach.OptionsFind.AlwaysVisible = true;
            this.gvDanhSach.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Search;
            this.gvDanhSach.OptionsFind.FindNullPrompt = "Nhập từ khóa cần tìm kiếm...";
            this.gvDanhSach.Click += new System.EventHandler(this.gvDanhSach_Click);
            // 
            // MaDonVi
            // 
            this.MaDonVi.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.MaDonVi.AppearanceHeader.Options.UseFont = true;
            this.MaDonVi.Caption = "Mã đơn vị";
            this.MaDonVi.FieldName = "MaDonVi";
            this.MaDonVi.MaxWidth = 129;
            this.MaDonVi.MinWidth = 32;
            this.MaDonVi.Name = "MaDonVi";
            this.MaDonVi.Visible = true;
            this.MaDonVi.VisibleIndex = 1;
            this.MaDonVi.Width = 129;
            // 
            // TenDonVi
            // 
            this.TenDonVi.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.TenDonVi.AppearanceHeader.Options.UseFont = true;
            this.TenDonVi.Caption = "Tên đơn vị";
            this.TenDonVi.FieldName = "TenDonVi";
            this.TenDonVi.MaxWidth = 321;
            this.TenDonVi.MinWidth = 32;
            this.TenDonVi.Name = "TenDonVi";
            this.TenDonVi.Visible = true;
            this.TenDonVi.VisibleIndex = 2;
            this.TenDonVi.Width = 190;
            // 
            // SoDT
            // 
            this.SoDT.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.SoDT.AppearanceHeader.Options.UseFont = true;
            this.SoDT.Caption = "Điện thoại";
            this.SoDT.FieldName = "SoDT";
            this.SoDT.MaxWidth = 193;
            this.SoDT.MinWidth = 32;
            this.SoDT.Name = "SoDT";
            this.SoDT.Visible = true;
            this.SoDT.VisibleIndex = 4;
            this.SoDT.Width = 187;
            // 
            // DiaChi
            // 
            this.DiaChi.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.DiaChi.AppearanceHeader.Options.UseFont = true;
            this.DiaChi.Caption = "Địa chỉ";
            this.DiaChi.FieldName = "DiaChi";
            this.DiaChi.MaxWidth = 386;
            this.DiaChi.MinWidth = 32;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Visible = true;
            this.DiaChi.VisibleIndex = 5;
            this.DiaChi.Width = 190;
            // 
            // Email
            // 
            this.Email.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.Email.AppearanceHeader.Options.UseFont = true;
            this.Email.Caption = "Email";
            this.Email.FieldName = "Email";
            this.Email.MaxWidth = 257;
            this.Email.MinWidth = 32;
            this.Email.Name = "Email";
            this.Email.Visible = true;
            this.Email.VisibleIndex = 3;
            this.Email.Width = 190;
            // 
            // KhongSuDung
            // 
            this.KhongSuDung.FieldName = "KhongSuDung";
            this.KhongSuDung.MaxWidth = 39;
            this.KhongSuDung.MinWidth = 32;
            this.KhongSuDung.Name = "KhongSuDung";
            this.KhongSuDung.Visible = true;
            this.KhongSuDung.VisibleIndex = 0;
            this.KhongSuDung.Width = 39;
            // 
            // GhiChu
            // 
            this.GhiChu.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.GhiChu.AppearanceHeader.Options.UseFont = true;
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.MinWidth = 32;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 6;
            this.GhiChu.Width = 213;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.txtGhiChu);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.txtDiaChi);
            this.groupControl1.Controls.Add(this.tgsKhongSuDung);
            this.groupControl1.Controls.Add(this.txtEmail);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.txtDienThoai);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.txtTenDonVi);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtMaDonVi);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(644, 971);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin đơn vị";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(41, 658);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(535, 113);
            this.txtGhiChu.TabIndex = 16;
            this.txtGhiChu.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 630);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ghi chú";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(41, 509);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(535, 113);
            this.txtDiaChi.TabIndex = 14;
            this.txtDiaChi.Text = "";
            // 
            // tgsKhongSuDung
            // 
            this.tgsKhongSuDung.Location = new System.Drawing.Point(372, 107);
            this.tgsKhongSuDung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tgsKhongSuDung.Name = "tgsKhongSuDung";
            this.tgsKhongSuDung.Properties.OffText = "Không sử dụng";
            this.tgsKhongSuDung.Properties.OnText = "Sử dụng";
            this.tgsKhongSuDung.Size = new System.Drawing.Size(213, 34);
            this.tgsKhongSuDung.TabIndex = 13;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(41, 408);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(541, 42);
            this.txtEmail.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 379);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(41, 306);
            this.txtDienThoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(541, 42);
            this.txtDienThoai.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 278);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 481);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa chỉ";
            // 
            // txtTenDonVi
            // 
            this.txtTenDonVi.Location = new System.Drawing.Point(41, 205);
            this.txtTenDonVi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenDonVi.Name = "txtTenDonVi";
            this.txtTenDonVi.Size = new System.Drawing.Size(541, 42);
            this.txtTenDonVi.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 177);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đơn vị";
            // 
            // txtMaDonVi
            // 
            this.txtMaDonVi.Location = new System.Drawing.Point(41, 104);
            this.txtMaDonVi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaDonVi.Name = "txtMaDonVi";
            this.txtMaDonVi.Size = new System.Drawing.Size(296, 42);
            this.txtMaDonVi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn vị";
            // 
            // frm_DonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1905, 971);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.IconOptions.Image = global::SmartTMS_Project.Properties.Resources.LOGO_TMS_2;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_DonVi";
            this.Text = "Đơn Vị";
            this.Load += new System.EventHandler(this.frm_DonVi_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.tgsKhongSuDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienThoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDonVi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStripButton btnBoQua;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtTenDonVi;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtMaDonVi;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtDienThoai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn MaDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn TenDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn SoDT;
        private DevExpress.XtraGrid.Columns.GridColumn DiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn Email;
        private DevExpress.XtraGrid.Columns.GridColumn KhongSuDung;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtDiaChi;
        private DevExpress.XtraEditors.ToggleSwitch tgsKhongSuDung;
    }
}