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
    public partial class frm_DonVi : DevExpress.XtraEditors.XtraForm
    {
        public frm_DonVi()
        {
            InitializeComponent();
        }
        DonVi _donvi;
        bool _them;
        string _maDonVi;
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

        private void frm_DonVi_Load(object sender, EventArgs e)
        {
            _donvi = new DonVi();
            LoadData();
            showHideControl(true);
            txtMaDonVi.Enabled = false;

        }

        private void CboCongTy_EditValueChanged(object sender, EventArgs e)
        {
            LoadDonVi_By_Cty();
        }

       
        void LoadDonVi_By_Cty()
        {
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _donvi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaDonVi.Enabled = true;
            showHideControl(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaDonVi.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _donvi.Delete(_maDonVi);
            }
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateDepartmentInputs())
                return;
            if (_them)
            {
                DONVI dv = new DONVI();
                dv.MaDonVi = txtMaDonVi.Text;
                dv.TenDonVi = txtTenDonVi.Text;
                dv.Email = txtEmail.Text;
                dv.DiaChi = txtDiaChi.Text;
                dv.SoDT = txtDienThoai.Text;
                dv.KhongSuDung = tgsKhongSuDung.IsOn;
                _donvi.Add(dv);
            }
            else
            {
                DONVI dv = _donvi.getItem(_maDonVi);
                dv.TenDonVi = txtTenDonVi.Text;
                dv.Email = txtEmail.Text;
                dv.DiaChi = txtDiaChi.Text;
                dv.SoDT = txtDienThoai.Text;
                dv.KhongSuDung = tgsKhongSuDung.IsOn;
                _donvi.Update(dv);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }
        private bool ValidateDepartmentInputs()
        {
            // Kiểm tra mã đơn vị
            if (string.IsNullOrWhiteSpace(txtMaDonVi.Text))
            {
                MessageBox.Show("Mã đơn vị không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDonVi.Focus();
                return false;
            }

            // Kiểm tra tên đơn vị
            if (string.IsNullOrWhiteSpace(txtTenDonVi.Text))
            {
                MessageBox.Show("Tên đơn vị không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDonVi.Focus();
                return false;
            }

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(txtDienThoai.Text) || txtDienThoai.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return false;
            }

            return true;
        }


        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaDonVi.Enabled = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount>0)
            {
                _maDonVi = gvDanhSach.GetFocusedRowCellValue("MaDonVi").ToString();
                txtMaDonVi.Text = gvDanhSach.GetFocusedRowCellValue("MaDonVi").ToString();
                txtTenDonVi.Text = gvDanhSach.GetFocusedRowCellValue("TenDonVi").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("Email").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("SoDT").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DiaChi").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChu").ToString();
                tgsKhongSuDung.IsOn = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KhongSuDung").ToString());

            }
        }
    }
}