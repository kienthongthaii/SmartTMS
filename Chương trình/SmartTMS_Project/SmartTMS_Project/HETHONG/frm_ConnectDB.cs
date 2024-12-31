using DataLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTMS_Project.HETHONG
{
    public partial class frm_ConnectDB : DevExpress.XtraEditors.XtraForm
    {
        public frm_ConnectDB()
        {
            InitializeComponent();
        }
        SqlConnection getCon(string server, string database, string username, string password)
        {
            if (rdbSQL.Checked)
            {
                return new SqlConnection("Data Source=" + txtServer.Text + "; Initial Catalog =" + txtDatabase.Text + ";User ID=" + txtUsername.Text + ";Password=" + txtPassword.Text + ";");
            }
            else
            {
                return new SqlConnection("Data Source=" + txtServer.Text + "; Initial Catalog =" + txtDatabase.Text + ";Integrated Security=true;");
            }
        }
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            SqlConnection con = getCon(txtServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);
            try
            {
                con.Open();
                MessageBox.Show("Kết nối thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối không thành công!");
            }
        }

        private void rdbWIN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbWIN.Checked)
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else 
            { 
                txtUsername.Enabled=true;
                txtPassword.Enabled=true;
            }
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            string enCryptServ = Encryptor.Encrypt(txtServer.Text,"qwertyuiop",true);
            string enCryptData = Encryptor.Encrypt(txtDatabase.Text, "qwertyuiop", true);
            string enCryptUser = Encryptor.Encrypt(txtUsername.Text, "qwertyuiop", true);
            string enCryptPass = Encryptor.Encrypt(txtPassword.Text, "qwertyuiop", true);
            connect cn = new connect(enCryptServ, enCryptData, enCryptUser, enCryptPass);
            cn.ConnectData();
            MessageBox.Show("Lưu file kết nối thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void frm_ConnectDB_Load(object sender, EventArgs e)
        {

        }
    }
}