using BusinessLayer;
using BusinessLayer.HETHONG;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class frm_TaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public frm_TaiKhoan()
        {
            InitializeComponent();
        }

        TaiKhoan _TaiKhoan;
        DonVi _donVi;
        bool _them;
        string _maTaiKhoan;
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
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
        void loadDonVi()
        {
            cboDonVi.Properties.DataSource = _donVi.getAll();
            cboDonVi.Properties.Columns.Clear();
            cboDonVi.Properties.Columns.Add(new LookUpColumnInfo("TenDonVi", "Tên Đơn Vị"));
            cboDonVi.Properties.DisplayMember = "TenDonVi";
            cboDonVi.Properties.ValueMember = "MaDonVi";
        }
        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            _TaiKhoan = new TaiKhoan();
            _donVi = new DonVi();
            loadDonVi();
            LoadData();
            showHideControl(true);
            txtMaTK.Enabled = false;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _TaiKhoan.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaTK.Enabled = true;
            showHideControl(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaTK.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _TaiKhoan.Delete(_maTaiKhoan);
            }
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateAccountInputs())
                return;
            if (_them)
            {
                TAIKHOAN dv = new TAIKHOAN();
                dv.MaTK = txtMaTK.Text;
                dv.TenDangNhap = txtTenDangNhap.Text;
                dv.MatKhau = txtMatKhau.Text;
                dv.LoaiTaiKhoan = cboLoaiTaiKhoan.EditValue.ToString();
                dv.MaCty = "SMT";
                dv.MaDonVi = cboDonVi.EditValue.ToString();
                dv.DangNhapLanCuoi = DateTime.Now;
                dv.KhoaTaiKhoan = false;
                _TaiKhoan.Add(dv);
            }
            else
            {
                TAIKHOAN dv = _TaiKhoan.getItem(_maTaiKhoan);
                dv.TenDangNhap = txtTenDangNhap.Text;
                dv.MatKhau = txtMatKhau.Text;
                dv.LoaiTaiKhoan = cboLoaiTaiKhoan.EditValue.ToString();
                dv.MaCty = "SMT";
                dv.MaDonVi = cboDonVi.EditValue.ToString();
                dv.DangNhapLanCuoi = DateTime.Now;
                dv.KhoaTaiKhoan = tgsKhongSuDung.IsOn;
                _TaiKhoan.Update(dv);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }

        private bool ValidateAccountInputs()
        {
            // Kiểm tra mã tài khoản
            if (string.IsNullOrWhiteSpace(txtMaTK.Text))
            {
                MessageBox.Show("Mã tài khoản không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTK.Focus();
                return false;
            }

            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return false;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }

            // Kiểm tra loại tài khoản
            if (cboLoaiTaiKhoan.EditValue == null || string.IsNullOrWhiteSpace(cboLoaiTaiKhoan.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiTaiKhoan.Focus();
                return false;
            }

            // Kiểm tra đơn vị
            if (cboDonVi.EditValue == null || string.IsNullOrWhiteSpace(cboDonVi.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDonVi.Focus();
                return false;
            }

            return true;
        }


        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaTK.Enabled = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maTaiKhoan = gvDanhSach.GetFocusedRowCellValue("MaTK").ToString();
                txtMaTK.Text = gvDanhSach.GetFocusedRowCellValue("MaTK").ToString();
                txtTenDangNhap.Text = gvDanhSach.GetFocusedRowCellValue("TenDangNhap").ToString();
                txtMatKhau.Text = gvDanhSach.GetFocusedRowCellValue("MatKhau").ToString();
                txtHoTen.Text = gvDanhSach.GetFocusedRowCellValue("TenDayDu").ToString();
                cboLoaiTaiKhoan.EditValue = gvDanhSach.GetFocusedRowCellValue("LoaiTaiKhoan").ToString();
                cboDonVi.EditValue = gvDanhSach.GetFocusedRowCellValue("MaDonVi").ToString();
                txtDangNhapLanCuoi.Text = gvDanhSach.GetFocusedRowCellValue("DangNhapLanCuoi").ToString();
                tgsKhongSuDung.IsOn = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KhoaTaiKhoan").ToString());
            }
        }
    }
}