namespace SmartTMS_Project.NGHIEPVU
{
    partial class frm_BaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BaoCao));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnXuatPDF = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.btnXuatExcel = new System.Windows.Forms.ToolStripButton();
            this.btnXuatWord = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
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
            this.toolStrip1.Location = new System.Drawing.Point(2451, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(104, 1006);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "Thanh công cụ";
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
            // 
            // documentViewer1
            // 
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.IsMetric = true;
            this.documentViewer1.Location = new System.Drawing.Point(0, 0);
            this.documentViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.Size = new System.Drawing.Size(2451, 1006);
            this.documentViewer1.TabIndex = 5;
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
            // frm_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2555, 1006);
            this.Controls.Add(this.documentViewer1);
            this.Controls.Add(this.toolStrip1);
            this.IconOptions.Image = global::SmartTMS_Project.Properties.Resources.LOGO_TMS_2;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_BaoCao";
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frm_BaoCao_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnXuatPDF;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
        private System.Windows.Forms.ToolStripButton btnXuatExcel;
        private System.Windows.Forms.ToolStripButton btnXuatWord;
    }
}