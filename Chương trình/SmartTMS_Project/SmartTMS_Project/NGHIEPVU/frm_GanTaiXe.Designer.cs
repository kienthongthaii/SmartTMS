namespace SmartTMS_Project.NGHIEPVU
{
    partial class frm_GanTaiXe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GanTaiXe));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTaiXeTu = new DevExpress.XtraEditors.TextEdit();
            this.cboTaiXe = new DevExpress.XtraEditors.LookUpEdit();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiXeTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTaiXe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(86, 148);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(175, 21);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Điều chuyển đến tài xế";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(86, 41);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(175, 21);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Điều chuyển từ tài xế : ";
            // 
            // txtTaiXeTu
            // 
            this.txtTaiXeTu.Location = new System.Drawing.Point(86, 69);
            this.txtTaiXeTu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTaiXeTu.Name = "txtTaiXeTu";
            this.txtTaiXeTu.Size = new System.Drawing.Size(593, 42);
            this.txtTaiXeTu.TabIndex = 7;
            // 
            // cboTaiXe
            // 
            this.cboTaiXe.Location = new System.Drawing.Point(86, 177);
            this.cboTaiXe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTaiXe.Name = "cboTaiXe";
            this.cboTaiXe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTaiXe.Properties.NullText = "Chọn tài xế";
            this.cboTaiXe.Size = new System.Drawing.Size(593, 42);
            this.cboTaiXe.TabIndex = 6;
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Appearance.Options.UseBackColor = true;
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.Location = new System.Drawing.Point(389, 262);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(177, 54);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "HỦY LỆNH";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.btnXacNhan.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.Appearance.Options.UseBackColor = true;
            this.btnXacNhan.Appearance.Options.UseFont = true;
            this.btnXacNhan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.ImageOptions.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(191, 262);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(176, 54);
            this.btnXacNhan.TabIndex = 12;
            this.btnXacNhan.Text = "XÁC NHẬN";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // frm_GanTaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 379);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtTaiXeTu);
            this.Controls.Add(this.cboTaiXe);
            this.IconOptions.Image = global::SmartTMS_Project.Properties.Resources.LOGO_TMS_2;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_GanTaiXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉ định tài xế cho xe";
            this.Load += new System.EventHandler(this.frm_GanTaiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiXeTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTaiXe.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTaiXeTu;
        private DevExpress.XtraEditors.LookUpEdit cboTaiXe;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
    }
}