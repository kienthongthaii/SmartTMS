using BusinessLayer;
using DataLayer;
using DevExpress.Charts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGauges.Core.Model;
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
    public partial class frm_BaiXe : DevExpress.XtraEditors.XtraForm
    {
        public frm_BaiXe()
        {
            InitializeComponent();
        }
        Bai _Bai;
        DonVi _DonVi;
        bool _them;
        string _maBai;
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
        private void frm_BaiXe_Load(object sender, EventArgs e)
        {

            _Bai = new Bai();
            _DonVi = new DonVi();
            gvDanhSach.OptionsView.ColumnAutoWidth = false;

            LoadData();
            loadDonVi();
            showHideControl(true);
            txtMaBai.Enabled = false;
        }
        private void CboCongTy_EditValueChanged(object sender, EventArgs e)
        {
            LoadBai_By_Cty();
        }
        void LoadBai_By_Cty()
        {
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _Bai.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadDonVi()
        {
            cboDonVi.Properties.DataSource = _DonVi.getAll();
            cboDonVi.Properties.Columns.Clear();
            cboDonVi.Properties.Columns.Add(new LookUpColumnInfo("TenDonVi", "Tên Đơn Vị"));
            cboDonVi.Properties.DisplayMember = "TenDonVi";
            cboDonVi.Properties.ValueMember = "MaDonVi";
        }
        void ClearData()
        {
            txtMaBai.Clear();
            txtTenBai.Clear();
            cboDonVi.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();
            cboLoaiBai.Clear();
            cboNguoiQuanLy.Clear();
            dtNgayHoanTra.EditValue = DateTime.Now;
            dtNgaySuDung.EditValue = DateTime.Now;
            txtSoLuongHienTai.Clear();
            txtSucChua.Clear();
            txtConTrong.Clear();
            txtChiPhiBai.Clear();
            tgsKhongSuDung.IsOn = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            ClearData();
            txtMaBai.Text = Function.GenerateAutoCode("B", 5, "MaBai", "BAI");
            txtMaBai.Enabled = true;
            showHideControl(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaBai.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_maBai);
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _Bai.Delete(_maBai);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                BAI item = new BAI();

                item.MaBai = txtMaBai.Text;
                item.TenBai = cboDonVi.EditValue.ToString();
                item.LoaiBai = cboLoaiBai.EditValue.ToString();
                item.DienTich = (double)tbcDienTich.Value;  // Nếu bạn muốn giá trị là kiểu double

                item.SoCho = int.Parse(txtSucChua.Text);
                item.KhongSuDung = tgsKhongSuDung.IsOn;
                item.MaQuanLy = cboNguoiQuanLy.EditValue.ToString();
                item.DiaChi = txtDiaChi.Text;
                item.GhiChu = txtGhiChu.Text;
                item.NgaySuDung = DateTime.Parse(dtNgaySuDung.EditValue.ToString());
                item.NgayHoanTra = DateTime.Parse(dtNgayHoanTra.EditValue.ToString());
                item.ChiPhiBai = decimal.Parse(txtChiPhiBai.Text);

                _Bai.Add(item);
            }
            else
            {
                BAI item = _Bai.getItem(_maBai);
                item.TenBai = cboDonVi.EditValue.ToString();
                item.LoaiBai = cboLoaiBai.EditValue.ToString();
                item.DienTich = (double)tbcDienTich.Value;  // Nếu bạn muốn giá trị là kiểu double

                item.SoCho = int.Parse(txtSucChua.Text);
                item.KhongSuDung = tgsKhongSuDung.IsOn;
                item.MaQuanLy = cboNguoiQuanLy.EditValue.ToString();
                item.DiaChi = txtDiaChi.Text;
                item.GhiChu = txtGhiChu.Text;
                item.NgaySuDung = DateTime.Parse(dtNgaySuDung.EditValue.ToString());
                item.NgayHoanTra = DateTime.Parse(dtNgayHoanTra.EditValue.ToString());
                item.ChiPhiBai = decimal.Parse(txtChiPhiBai.Text);
                _Bai.Update(item);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaBai.Enabled = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maBai = gvDanhSach.GetFocusedRowCellValue("MaBai").ToString();
                txtMaBai.Text = gvDanhSach.GetFocusedRowCellValue("MaBai").ToString();
                txtTenBai.Text = gvDanhSach.GetFocusedRowCellValue("TenBai").ToString();
                cboLoaiBai.Text = gvDanhSach.GetFocusedRowCellValue("LoaiBai").ToString();
                tbcDienTich.Value = int.Parse(gvDanhSach.GetFocusedRowCellValue("DienTich").ToString());
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DiaChi").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChu").ToString();
                dtNgaySuDung.EditValue = gvDanhSach.GetFocusedRowCellValue("NgaySuDung");
                txtSucChua.Text = gvDanhSach.GetFocusedRowCellValue("SoCho").ToString();
                cboNguoiQuanLy.EditValue = gvDanhSach.GetFocusedRowCellValue("MaQuanLy");
                dtNgayHoanTra.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayHoanTra").ToString();
                txtChiPhiBai.EditValue = decimal.Parse(gvDanhSach.GetFocusedRowCellValue("ChiPhiBai").ToString());
                tgsKhongSuDung.IsOn = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KhongSuDung").ToString());
                Needle.Value = 20;  // Cập nhật giá trị của kim 
                Scale.MaxValue = float.Parse(gvDanhSach.GetFocusedRowCellValue("SoCho").ToString());   // Cập nhật giá trị của scale
            }
        }

        private void btnKeThua_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaBai.Text = Function.GenerateAutoCode("B", 5, "MaBai", "BAI"); ;
            txtMaBai.Enabled = true;
            showHideControl(false);
        }

        private void tbcDienTich_EditValueChanged(object sender, EventArgs e)
        {
            txtDienTich.Text = tbcDienTich.Value.ToString();
        }

        private void txtDienTich_EditValueChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem giá trị nhập vào có hợp lệ không
            if (int.TryParse(txtDienTich.Text, out int value))
            {
                // Gán giá trị hợp lệ cho TrackBarControl, đảm bảo nằm trong khoảng tối thiểu và tối đa
                if (value >= tbcDienTich.Properties.Minimum && value <= tbcDienTich.Properties.Maximum)
                {
                    tbcDienTich.Value = value;
                }
                else
                {
                    // Thông báo lỗi nếu giá trị nằm ngoài khoảng
                    MessageBox.Show($"Giá trị phải nằm trong khoảng từ {tbcDienTich.Properties.Minimum} đến {tbcDienTich.Properties.Maximum}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Thông báo lỗi nếu giá trị nhập không hợp lệ
                MessageBox.Show("Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}