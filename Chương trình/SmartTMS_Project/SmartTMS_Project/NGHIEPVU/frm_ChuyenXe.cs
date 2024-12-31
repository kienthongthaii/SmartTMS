using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SmartTMS_Project.HETHONG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTMS_Project.NGHIEPVU
{
    public partial class frm_ChuyenXe : DevExpress.XtraEditors.XtraForm
    {
        public frm_ChuyenXe()
        {
            InitializeComponent();
        }
        public string ID_Xe { get; set; }
        public string ID_Bai { get; set; }
        public frmTrangChu MainForm { get; set; }
        Bai _baiXe;
        PhuongTien _phuongTien;
        
        
        void loadBaiXe()
        {
            cboBaiXeDen.Properties.DataSource = _baiXe.getAll();
            cboBaiXeDen.Properties.Columns.Clear();
            cboBaiXeDen.Properties.Columns.Add(new LookUpColumnInfo("TenBai", "Bãi xe"));
            cboBaiXeDen.Properties.DisplayMember = "TenBai";
            cboBaiXeDen.Properties.ValueMember = "MaBai";
        }
        private void frm_ChuyenXe_Load(object sender, EventArgs e)
        {
            _baiXe = new Bai();
            _phuongTien = new PhuongTien();
            loadBaiXe();
            
            txtBaiXeTu.Text = _baiXe.getItem(ID_Bai).TenBai;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            PHUONGTIEN pt = new PHUONGTIEN();
            pt = _phuongTien.getItem_BienSo(ID_Xe);
            pt.MaBai = cboBaiXeDen.EditValue.ToString();
            _phuongTien.Update(pt);
            MessageBox.Show("Đã chuyển xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hiển thị MessageBox xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy bỏ không?",  // Nội dung thông báo
                "Xác nhận",                            // Tiêu đề
                MessageBoxButtons.YesNo,               // Hiển thị nút Yes và No
                MessageBoxIcon.Question                // Icon dạng câu hỏi
            );

            // Nếu người dùng chọn Yes, đóng form
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frm_ChuyenXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MainForm != null)
            {
                // Sử dụng Reflection để gọi phương thức Click của btnTrangChu
                var btn = MainForm.GetType().GetField("btnTrangChu", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(MainForm) as Button;
                btn?.PerformClick();
            }
        }
    }
}