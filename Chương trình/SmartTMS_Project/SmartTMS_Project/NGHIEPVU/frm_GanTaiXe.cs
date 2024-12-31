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
    public partial class frm_GanTaiXe : DevExpress.XtraEditors.XtraForm
    {
        public frm_GanTaiXe()
        {
            InitializeComponent();
        }
        public string ID_Xe { get; set; }
        public string ID_TaiXe { get; set; }
        public frmTrangChu MainForm { get; set; }
        TaiXe _taiXe;
        PhuongTien _phuongTien;
        private void frm_GanTaiXe_Load(object sender, EventArgs e)
        {
            _taiXe = new TaiXe();
            _phuongTien = new PhuongTien();
            LoadTaiXe();

            txtTaiXeTu.Text = _taiXe.getItem(_phuongTien.getItem_BienSo(ID_Xe).MaTX).HoTen;
        }



        void LoadTaiXe()
        {
            cboTaiXe.Properties.DataSource = _taiXe.getAll();
            cboTaiXe.Properties.Columns.Clear();
            cboTaiXe.Properties.Columns.Add(new LookUpColumnInfo("HoTen", "Tài xế"));
            cboTaiXe.Properties.DisplayMember = "HoTen";
            cboTaiXe.Properties.ValueMember = "MaTX";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            PHUONGTIEN pt = new PHUONGTIEN();
            pt = _phuongTien.getItem_BienSo(ID_Xe);
            pt.MaTX = cboTaiXe.EditValue.ToString();
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