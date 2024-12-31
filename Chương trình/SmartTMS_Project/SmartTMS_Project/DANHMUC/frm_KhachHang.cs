using BusinessLayer.DANHMUC;
using BusinessLayer.NGHIEPVU;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTMS_Project.DANHMUC
{
    public partial class frm_KhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frm_KhachHang()
        {
            InitializeComponent();
        }

        KhachHang _KhachHang;
        DonHang _DonHang;
        bool _them;
        string _maKhachHang;
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnKeThua.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            _KhachHang = new KhachHang();
            _DonHang = new DonHang();
            gvDanhSach.OptionsView.ColumnAutoWidth = false;
            LoadData();
            showHideControl(true);
            txtMaKH.Enabled = false;
        }
    
        void LoadData()
        {
            gcDanhSach.DataSource = _KhachHang.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void ClearData()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            cboLoaiKhachHang.Clear();
            txtTongGiaTriMua.Clear();
            txtSoDonHang.Clear();
            txtEmail.Clear();
            txtSoDT.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();
            txtMaSoThue.Clear();
            txtNguoiLienHe.Clear();
            txtSoDTNguoiLienHe.Clear();
           
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            ClearData();
            txtMaKH.Text = Function.GenerateAutoCode("KH", 5, "MaKH", "KHACHHANG");
            txtMaKH.Enabled = true;
            showHideControl(false);
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaKH.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_maKhachHang);
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _KhachHang.Delete(_maKhachHang);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                if (true)
                {
                    KHACHHANG item = new KHACHHANG();
                    item.MaKH = txtMaKH.Text;
                    item.TenKH = txtHoTen.Text;
                    item.SoDT = txtSoDT.Text;
                    item.DiaChi = txtDiaChi.Text;
                    item.Email = txtEmail.Text;
                    item.MaSoThue = txtMaSoThue.Text;
                    item.GhiChu = txtGhiChu.Text;
                    item.MaSoThue = txtMaSoThue.Text;
                    item.NguoiLienHe = txtNguoiLienHe.Text;
                    item.SoDTLienHe = txtSoDTNguoiLienHe.Text;
                    item.LoaiKH = cboLoaiKhachHang.EditValue.ToString();
                    item.NgayTao = DateTime.Now;
                    item.TrangThai = "Không đặt hàng";
                    _KhachHang.Add(item);
                }
            }
            else
            {
                KHACHHANG item = _KhachHang.getItem(_maKhachHang);
                item.TenKH = txtHoTen.Text;
                item.SoDT = txtSoDT.Text;
                item.DiaChi = txtDiaChi.Text;
                item.Email = txtEmail.Text;
                item.MaSoThue = txtMaSoThue.Text;
                item.GhiChu = txtGhiChu.Text;
                item.MaSoThue = txtMaSoThue.Text;
                item.NguoiLienHe = txtNguoiLienHe.Text;
                item.SoDTLienHe = txtSoDTNguoiLienHe.Text;
                item.LoaiKH = cboLoaiKhachHang.EditValue.ToString();
                item.NgayTao = DateTime.Now;
                item.TrangThai = cboTrangThai.EditValue.ToString();
                _KhachHang.Update(item);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaKH.Enabled = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0 && gvDanhSach.FocusedRowHandle >= 0)
            {
                _maKhachHang = gvDanhSach.GetFocusedRowCellValue("MaKH").ToString();
                txtMaKH.Text = gvDanhSach.GetFocusedRowCellValue("MaKH").ToString();
                txtHoTen.Text = gvDanhSach.GetFocusedRowCellValue("TenKH").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("Email").ToString();
                txtSoDT.Text = gvDanhSach.GetFocusedRowCellValue("SoDT").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DiaChi").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChu")?.ToString() ?? "";
                cboLoaiKhachHang.EditValue = gvDanhSach.GetFocusedRowCellValue("LoaiKH").ToString();
                txtMaSoThue.Text = gvDanhSach.GetFocusedRowCellValue("MaSoThue").ToString();
                cboTrangThai.EditValue = gvDanhSach.GetFocusedRowCellValue("TrangThai").ToString();
                txtNguoiLienHe.EditValue = gvDanhSach.GetFocusedRowCellValue("NguoiLienHe").ToString();
                txtSoDTNguoiLienHe.Text = gvDanhSach.GetFocusedRowCellValue("SoDTLienHe").ToString();
                txtTongGiaTriMua.Text = _DonHang.TongTien(_maKhachHang).ToString();
                txtSoDonHang.Text = _DonHang.SoDon(_maKhachHang).ToString();
                gcDonHang.DataSource = _DonHang.getAll_KH(_maKhachHang);
                gvDonHang.OptionsBehavior.Editable = false;
            }
        }

        private void btnKeThua_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaKH.Text = Function.GenerateAutoCode("KH", 5, "MaKH", "KHACHHANG"); ;
            txtMaKH.Enabled = true;
            showHideControl(false);
        }
    }
}