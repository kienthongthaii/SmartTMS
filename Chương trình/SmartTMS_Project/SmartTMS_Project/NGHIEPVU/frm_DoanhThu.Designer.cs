namespace SmartTMS_Project.NGHIEPVU
{
    partial class frm_DoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DoanhThu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnXuatExcel = new System.Windows.Forms.ToolStripButton();
            this.btnXuatWord = new System.Windows.Forms.ToolStripButton();
            this.btnXuatPDF = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtNgayDen = new DevExpress.XtraEditors.DateEdit();
            this.dtNgayTu = new DevExpress.XtraEditors.DateEdit();
            this.documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayDen.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayTu.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnXuatExcel,
            this.btnXuatWord,
            this.btnXuatPDF,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(1509, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(104, 976);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Thanh công cụ";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Image")));
            this.btnXuatExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(97, 57);
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXuatExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXuatWord
            // 
            this.btnXuatWord.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatWord.Image")));
            this.btnXuatWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXuatWord.Name = "btnXuatWord";
            this.btnXuatWord.Size = new System.Drawing.Size(97, 57);
            this.btnXuatWord.Text = "Xuất Word";
            this.btnXuatWord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXuatWord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXuatWord.Click += new System.EventHandler(this.btnXuatWord_Click);
            // 
            // btnXuatPDF
            // 
            this.btnXuatPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatPDF.Image")));
            this.btnXuatPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXuatPDF.Name = "btnXuatPDF";
            this.btnXuatPDF.Size = new System.Drawing.Size(97, 57);
            this.btnXuatPDF.Text = "Xuất PDF";
            this.btnXuatPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXuatPDF.Click += new System.EventHandler(this.btnXuatPDF_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 57);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.label2);
            this.splitContainerControl1.Panel1.Controls.Add(this.label1);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtNgayDen);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtNgayTu);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.documentViewer1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1509, 976);
            this.splitContainerControl1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(478, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày đến";
            // 
            // dtNgayDen
            // 
            this.dtNgayDen.EditValue = null;
            this.dtNgayDen.Location = new System.Drawing.Point(583, 42);
            this.dtNgayDen.Name = "dtNgayDen";
            this.dtNgayDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayDen.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayDen.Size = new System.Drawing.Size(289, 42);
            this.dtNgayDen.TabIndex = 1;
            this.dtNgayDen.EditValueChanged += new System.EventHandler(this.dtNgayDen_EditValueChanged);
            // 
            // dtNgayTu
            // 
            this.dtNgayTu.EditValue = null;
            this.dtNgayTu.Location = new System.Drawing.Point(143, 42);
            this.dtNgayTu.Name = "dtNgayTu";
            this.dtNgayTu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayTu.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayTu.Size = new System.Drawing.Size(289, 42);
            this.dtNgayTu.TabIndex = 0;
            // 
            // documentViewer1
            // 
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.IsMetric = true;
            this.documentViewer1.Location = new System.Drawing.Point(0, 0);
            this.documentViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.Size = new System.Drawing.Size(1509, 852);
            this.documentViewer1.TabIndex = 0;
            // 
            // frm_DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1613, 976);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.IconOptions.Image = global::SmartTMS_Project.Properties.Resources.LOGO_TMS_2;
            this.Name = "frm_DoanhThu";
            this.Text = "Báo cáo doanh thu";
            this.Load += new System.EventHandler(this.frm_DoanhThu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayDen.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayTu.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayTu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnXuatExcel;
        private System.Windows.Forms.ToolStripButton btnXuatWord;
        private System.Windows.Forms.ToolStripButton btnXuatPDF;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtNgayDen;
        private DevExpress.XtraEditors.DateEdit dtNgayTu;
        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
    }
}