namespace SmartTMS_Project.HETHONG
{
    partial class frm_ConnectDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ConnectDB));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnKetNoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnKiemTra = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.rdbSQL = new System.Windows.Forms.RadioButton();
            this.rdbWIN = new System.Windows.Forms.RadioButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtDatabase = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtServer = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnKetNoi);
            this.groupControl1.Controls.Add(this.btnKiemTra);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.txtPassword);
            this.groupControl1.Controls.Add(this.txtUsername);
            this.groupControl1.Controls.Add(this.txtDatabase);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtServer);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(633, 916);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin kết nối";
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKetNoi.ImageOptions.SvgImage")));
            this.btnKetNoi.Location = new System.Drawing.Point(340, 746);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(227, 76);
            this.btnKetNoi.TabIndex = 10;
            this.btnKetNoi.Text = "Kết nối";
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKiemTra.ImageOptions.SvgImage")));
            this.btnKiemTra.Location = new System.Drawing.Point(90, 746);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(227, 76);
            this.btnKiemTra.TabIndex = 9;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.rdbSQL);
            this.groupControl2.Controls.Add(this.rdbWIN);
            this.groupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl2.Location = new System.Drawing.Point(90, 314);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(477, 165);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Tùy chọn xác thực";
            // 
            // rdbSQL
            // 
            this.rdbSQL.AutoSize = true;
            this.rdbSQL.Checked = true;
            this.rdbSQL.Location = new System.Drawing.Point(26, 106);
            this.rdbSQL.Name = "rdbSQL";
            this.rdbSQL.Size = new System.Drawing.Size(262, 32);
            this.rdbSQL.TabIndex = 1;
            this.rdbSQL.TabStop = true;
            this.rdbSQL.Text = "Xác thực bằng SQL Server";
            this.rdbSQL.UseVisualStyleBackColor = true;
            // 
            // rdbWIN
            // 
            this.rdbWIN.AutoSize = true;
            this.rdbWIN.Location = new System.Drawing.Point(26, 58);
            this.rdbWIN.Name = "rdbWIN";
            this.rdbWIN.Size = new System.Drawing.Size(248, 32);
            this.rdbWIN.TabIndex = 0;
            this.rdbWIN.Text = "Xác thực bằng Windows";
            this.rdbWIN.UseVisualStyleBackColor = true;
            this.rdbWIN.CheckedChanged += new System.EventHandler(this.rdbWIN_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 638);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(477, 52);
            this.txtPassword.TabIndex = 7;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(90, 528);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(477, 52);
            this.txtUsername.TabIndex = 6;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(90, 243);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(477, 52);
            this.txtDatabase.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(90, 602);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(87, 30);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Password";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(90, 492);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(93, 30);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Username";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(90, 207);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(87, 30);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Database";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(90, 100);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 30);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Server";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(90, 136);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(477, 52);
            this.txtServer.TabIndex = 0;
            // 
            // frm_ConnectDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 916);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.Image = global::SmartTMS_Project.Properties.Resources.LOGO_TMS_2;
            this.Name = "frm_ConnectDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối hệ thống";
            this.Load += new System.EventHandler(this.frm_ConnectDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDatabase;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtServer;
        private DevExpress.XtraEditors.SimpleButton btnKetNoi;
        private DevExpress.XtraEditors.SimpleButton btnKiemTra;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.RadioButton rdbSQL;
        private System.Windows.Forms.RadioButton rdbWIN;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
    }
}