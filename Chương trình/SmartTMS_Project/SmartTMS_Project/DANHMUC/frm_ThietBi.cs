using BusinessLayer.DANHMUC;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGauges.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTMS_Project.DANHMUC
{
    public partial class frm_ThietBi : DevExpress.XtraEditors.XtraForm
    {
        public frm_ThietBi()
        {
            InitializeComponent();
        }


        ThietBi _ThietBi;
        bool _them;
        string _maThietBi;
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

        private void frm_ThietBi_Load(object sender, EventArgs e)
        {

            _ThietBi = new ThietBi();
            gvDanhSach.OptionsView.ColumnAutoWidth = false;

            LoadData();
            showHideControl(true);
            txtMaTB.Enabled = false;
        }


        private void CboCongTy_EditValueChanged(object sender, EventArgs e)
        {
            LoadThietBi_By_Cty();
        }


        void LoadThietBi_By_Cty()
        {
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _ThietBi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
       
        //void ClearData()
        //{
        //    txtHoTen.Clear();
        //    txtEmail.Clear();
        //    txtSoDT.Clear();
        //    txtDiaChi.Clear();
        //    txtGhiChu.Clear();
        //    dtNgaySinh.EditValue = DateTime.Now;
        //    txtCCCD.Clear();
        //    dtNgayHetHan.EditValue = DateTime.Now;
        //    dtNgayVaoLam.EditValue = DateTime.Now;
        //    txtLuongCoBan.Clear();
        //    txtTrinhDoChuyenMon.Clear();
        //    txtKinhNghiem.Clear();
        //    tgGioiTinh.IsOn = true;
        //    cbLoaiBangLai.Clear();
        //    cbBangLai.Clear();
        //}

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaTB.Text = Function.GenerateAutoCode("TB", 5, "MaTB", "THIETBI");
            txtMaTB.Enabled = true;
            showHideControl(false);
            //ClearData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaTB.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_maThietBi);
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ThietBi.Delete(_maThietBi);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
        }




        private bool ValidateDeviceInputs()
        {
            // Kiểm tra mã thiết bị
            if (string.IsNullOrWhiteSpace(txtMaTB.Text))
            {
                MessageBox.Show("Mã thiết bị không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTB.Focus();
                return false;
            }

            // Kiểm tra tên thiết bị
            if (string.IsNullOrWhiteSpace(txtTenTB.Text))
            {
                MessageBox.Show("Tên thiết bị không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTB.Focus();
                return false;
            }

            // Kiểm tra loại phương tiện
            if (cboLoaiPT.EditValue == null || string.IsNullOrWhiteSpace(cboLoaiPT.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn loại phương tiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiPT.Focus();
                return false;
            }

            // Kiểm tra thời hạn kiểm tra
            if (!double.TryParse(cboThoiHanKiemTra.EditValue?.ToString(), out double thoiHan) || thoiHan <= 0)
            {
                MessageBox.Show("Thời hạn kiểm tra phải là một số hợp lệ lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboThoiHanKiemTra.Focus();
                return false;
            }

            // Kiểm tra đơn giá
            if (!int.TryParse(txtDonGia.Text, out int donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là một số nguyên hợp lệ lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;
            }

            // Kiểm tra số lượng tồn
            if (!int.TryParse(txtSoLuongTon.Text, out int soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn phải là một số nguyên không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongTon.Focus();
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateDeviceInputs())
                return;
            if (_them)
            {
                THIETBI item = new THIETBI();

                item.MaTB = txtMaTB.Text;
                item.TenThietBi = txtTenTB.Text;
                item.LoaiPT = cboLoaiPT.EditValue.ToString();
                item.ThoiHanKiemTra = double.Parse(cboThoiHanKiemTra.EditValue.ToString()); // Nếu bạn muốn giá trị là kiểu double

                item.DonGia = int.Parse(txtDonGia.Text);
                item.KhongSuDung = tgsKhongSuDung.IsOn;
                item.SoLuongConLai = int.Parse(txtSoLuongTon.Text);
                item.GhiChu = txtGhiChu.Text;


                _ThietBi.Add(item);
            }
            else
            {
                THIETBI item = _ThietBi.getItem(_maThietBi);
                item.TenThietBi = txtTenTB.Text;
                item.LoaiPT = cboLoaiPT.EditValue.ToString();
                item.ThoiHanKiemTra = double.Parse(cboThoiHanKiemTra.EditValue.ToString()); // Nếu bạn muốn giá trị là kiểu double
                item.DonGia = int.Parse(txtDonGia.Text);
                item.KhongSuDung = tgsKhongSuDung.IsOn;
                item.SoLuongConLai = int.Parse(txtSoLuongTon.Text);
                item.GhiChu = txtGhiChu.Text;
                _ThietBi.Update(item);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaTB.Enabled = false;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maThietBi = gvDanhSach.GetFocusedRowCellValue("MaTB").ToString();
                txtMaTB.Text = gvDanhSach.GetFocusedRowCellValue("MaTB").ToString();
                txtTenTB.Text = gvDanhSach.GetFocusedRowCellValue("TenThietBi").ToString();
                cboLoaiPT.EditValue = gvDanhSach.GetFocusedRowCellValue("LoaiPT").ToString();
                cboThoiHanKiemTra.EditValue = int.Parse(gvDanhSach.GetFocusedRowCellValue("ThoiHanKiemTra").ToString());
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DonGia").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChu").ToString();
                txtSoLuongTon.Text = gvDanhSach.GetFocusedRowCellValue("SoLuongConLai").ToString();   
                tgsKhongSuDung.IsOn = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KhongSuDung").ToString());


            }
        }

        private void btnKeThua_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaTB.Text = Function.GenerateAutoCode("TB", 5, "MaTB", "THIETBI"); ;
            txtMaTB.Enabled = true;
            showHideControl(false);
        }

    }
}