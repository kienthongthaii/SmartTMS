namespace SmartTMS_Project.NGHIEPVU
{
    partial class frm_ChuyenXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChuyenXe));
            this.cboBaiXeDen = new DevExpress.XtraEditors.LookUpEdit();
            this.txtBaiXeTu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboBaiXeDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaiXeTu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBaiXeDen
            // 
            this.cboBaiXeDen.Location = new System.Drawing.Point(39, 167);
            this.cboBaiXeDen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboBaiXeDen.Name = "cboBaiXeDen";
            this.cboBaiXeDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBaiXeDen.Properties.NullText = "Chọn bãi cần chuyển đến";
            this.cboBaiXeDen.Size = new System.Drawing.Size(593, 42);
            this.cboBaiXeDen.TabIndex = 0;
            // 
            // txtBaiXeTu
            // 
            this.txtBaiXeTu.Location = new System.Drawing.Point(39, 59);
            this.txtBaiXeTu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBaiXeTu.Name = "txtBaiXeTu";
            this.txtBaiXeTu.Size = new System.Drawing.Size(593, 42);
            this.txtBaiXeTu.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(39, 31);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(179, 21);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Điều chuyển từ bãi xe : ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(39, 138);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(191, 21);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Điều chuyển đến bãi xe : ";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnXacNhan.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.Appearance.Options.UseBackColor = true;
            this.btnXacNhan.Appearance.Options.UseFont = true;
            this.btnXacNhan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(147, 245);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(176, 54);
            this.btnXacNhan.TabIndex = 14;
            this.btnXacNhan.Text = "XÁC NHẬN";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Appearance.Options.UseBackColor = true;
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btnHuy.Location = new System.Drawing.Point(345, 245);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(177, 54);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = "HỦY LỆNH";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frm_ChuyenXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 332);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtBaiXeTu);
            this.Controls.Add(this.cboBaiXeDen);
            this.IconOptions.Image = global::SmartTMS_Project.Properties.Resources.LOGO_TMS_2;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChuyenXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Di chuyển xe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_ChuyenXe_FormClosed);
            this.Load += new System.EventHandler(this.frm_ChuyenXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboBaiXeDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaiXeTu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboBaiXeDen;
        private DevExpress.XtraEditors.TextEdit txtBaiXeTu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
    }
}