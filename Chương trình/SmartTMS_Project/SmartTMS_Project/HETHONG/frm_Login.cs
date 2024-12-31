using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTMS_Project.HETHONG
{
    public partial class frm_Login : DevExpress.XtraEditors.XtraForm
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void txtUsername_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Entities db = Entities.CreateEntities();
            // Lấy thông tin từ các trường nhập liệu
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra xem các trường có trống hay không
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tài khoản
            TAIKHOAN user = db.TAIKHOAN.FirstOrDefault(x => x.TenDangNhap == username);
            if (user == null)
            {
                MessageBox.Show("Tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mật khẩu
            if (user.MatKhau != password)
            {
                MessageBox.Show("Mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đăng nhập thành công
            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Chuyển hướng đến form chính của ứng dụng
            frmTrangChu mainForm = new frmTrangChu();
            this.Hide(); // Ẩn form đăng nhập
            mainForm.Show();
        }

        // Hàm kiểm tra thông tin đăng nhập (giả lập)


    }
}