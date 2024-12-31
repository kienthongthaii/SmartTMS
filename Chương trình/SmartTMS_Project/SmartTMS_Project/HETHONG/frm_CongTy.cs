using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
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
    public partial class frm_CongTy : DevExpress.XtraEditors.XtraForm
    {
        public frm_CongTy()
        {
            InitializeComponent();
        }
        
        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void frm_CongTy_Load(object sender, EventArgs e)
        {
            // Tạo đối tượng truy vấn dữ liệu
            CongTy _dvi = new CongTy();

            // Lấy dữ liệu dòng duy nhất từ bảng
            var congTy = _dvi.getItem(); // Giả sử bạn có phương thức GetSingle để lấy dòng duy nhất

            // Kiểm tra nếu dữ liệu không null
            if (congTy != null)
            {
                txtTenCty.Text = congTy.TenCty; // Gán tên công ty vào textbox
                txtTenVietTat.Text = congTy.TenVietTat;
                txtMaSoThue.Text = congTy.MaSoThue;
                txtDiaChi.Text = congTy.DiaChi;
                txtNguoiDaiDien.Text = congTy.NguoiDaiDien;
                txtLoaiHinhDoanhNghiep.Text = congTy.LoaiHinhDoanhNghiep;
                txtNgayHoatDong.Text = congTy.NgayHoatDong.ToString();
                txtEmail.Text = congTy.Email;
                txtDienThoai.Text = congTy.SoDT;
                hplFacebook.Text = congTy.Link2;
                hplWebsite.Text = congTy.Link1;
                hplTuyenDung.Text = congTy.Link3;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu công ty!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn không có quyền chỉnh sửa thông tin công ty!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}