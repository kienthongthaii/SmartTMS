using BusinessLayer;
using BusinessLayer.DANHMUC;
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

namespace SmartTMS_Project.DANHMUC
{
    public partial class frm_DiemTrungChuyen : DevExpress.XtraEditors.XtraForm
    {
        public frm_DiemTrungChuyen()
        {
            InitializeComponent();
        }

        DiemTrungChuyen _DiemTrungChuyen;
        NhanVien _NhanVien;
        Tinh _tinh;
        Huyen _huyen;
        Xa _xa;
        Ap _ap;
        bool _them;
        string _maDiemTrungChuyen;
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
        void ClearData()
        {
            txtMaDTC.Clear();
            txtTenDTC.Clear();
            cboQuanLy.Clear();
            txtKinhDo.Clear();
            txtViDo.Clear();
            cboTinh.Clear();
            cboHuyen.Clear();
            cboXa.Clear();
            cboAp.Clear();
            txtDuong.Clear();
            txtSoDienThoai.Clear();
            tgsKhongSuDung.IsOn = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_DiemTrungChuyen_Load(object sender, EventArgs e)
        {


            _DiemTrungChuyen = new DiemTrungChuyen();
            _NhanVien = new NhanVien();
            _tinh = new Tinh();
            _huyen = new Huyen();
            _xa = new Xa(); 
            _ap = new Ap();



            gvDanhSach.OptionsView.ColumnAutoWidth = false;


            LoadData();
            LoadQuanLy();
            LoadTinh();
            showHideControl(true);
            txtMaDTC.Enabled = false;
        }

        void LoadQuanLy()
        {
            cboQuanLy.Properties.DataSource = _NhanVien.getAllQuanLy();
            cboQuanLy.Properties.Columns.Clear();
            cboQuanLy.Properties.Columns.Add(new LookUpColumnInfo("HoTen", "Họ tên"));
            cboQuanLy.Properties.DisplayMember = "HoTen";
            cboQuanLy.Properties.ValueMember = "MaNV";
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _DiemTrungChuyen.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void LoadTinh()
        {
            cboTinh.Properties.DataSource = _tinh.getAll();
            cboTinh.Properties.Columns.Clear();
            cboTinh.Properties.Columns.Add(new LookUpColumnInfo("TenTinh", "Tỉnh/Thành phố"));
            cboTinh.Properties.DisplayMember = "TenTinh";
            cboTinh.Properties.ValueMember = "MaTinh";
        }
        void LoadHuyen(string maTinh)
        {
            cboHuyen.Properties.DataSource = _huyen.getAll(maTinh);
            cboHuyen.Properties.Columns.Clear();
            cboHuyen.Properties.Columns.Add(new LookUpColumnInfo("TenHuyen", "Huyện/Quận/Thị xã/Thành phố thuộc tỉnh"));
            cboHuyen.Properties.DisplayMember = "TenHuyen";
            cboHuyen.Properties.ValueMember = "MaHuyen";
        }
        void LoadXa(string maHuyen)
        {
            cboXa.Properties.DataSource = _xa.getAll(maHuyen);
            cboXa.Properties.Columns.Clear();
            cboXa.Properties.Columns.Add(new LookUpColumnInfo("TenXa", "Xã/Phường/Thị trấn"));
            cboXa.Properties.DisplayMember = "TenXa";
            cboXa.Properties.ValueMember = "MaXa";
        }
        void LoadAp(string maXa)
        {
            cboAp.Properties.DataSource = _ap.getAll(maXa);
            cboAp.Properties.Columns.Clear();
            cboAp.Properties.Columns.Add(new LookUpColumnInfo("TenAp", "Thôn/Ấp/Bản/Tổ dân phố"));
            cboAp.Properties.DisplayMember = "TenAp";
            cboAp.Properties.ValueMember = "MaAp";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            ClearData();
            txtMaDTC.Text = Function.GenerateAutoCode("DTC", 5, "MaDTC", "DIEMTRUNGCHUYEN");
            txtMaDTC.Enabled = true;
            showHideControl(false);
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaDTC.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_maDiemTrungChuyen);
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _DiemTrungChuyen.Delete(_maDiemTrungChuyen);
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
                    DIEMTRUNGCHUYEN item = new DIEMTRUNGCHUYEN();
                    item.MaDTC = txtMaDTC.Text;
                    item.TenDTC = txtTenDTC.Text;
                    item.SoDienThoai = txtSoDienThoai.Text;
                    item.KinhDo = double.Parse(txtKinhDo.Text);
                    item.ViDo = double.Parse(txtViDo.Text);
                    item.KhongSuDung = tgsKhongSuDung.IsOn;
                    item.QuanLy = cboQuanLy.EditValue.ToString();
                    item.Tinh = cboTinh.EditValue.ToString();
                    item.Huyen = cboHuyen.EditValue.ToString();
                    item.Xa = cboXa.EditValue.ToString();
                    item.Ap = cboAp.EditValue.ToString();
                    item.Duong = txtDuong.Text;

                  
                    _DiemTrungChuyen.Add(item);
                }
            }
            else
            {
                DIEMTRUNGCHUYEN item = _DiemTrungChuyen.getItem(_maDiemTrungChuyen);
                item.TenDTC = txtTenDTC.Text;
                item.SoDienThoai = txtSoDienThoai.Text;
                item.KinhDo = double.Parse(txtKinhDo.Text);
                item.ViDo = double.Parse(txtViDo.Text);
                item.KhongSuDung = tgsKhongSuDung.IsOn;
                item.QuanLy = cboQuanLy.EditValue.ToString();
                item.Tinh = cboTinh.EditValue.ToString();
                item.Huyen = cboHuyen.EditValue.ToString();
                item.Xa = cboXa.EditValue.ToString();
                item.Ap = cboAp.EditValue.ToString();
                item.Duong = txtDuong.Text;
                _DiemTrungChuyen.Update(item);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaDTC.Enabled = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0 && gvDanhSach.FocusedRowHandle >= 0)
            {
                _maDiemTrungChuyen = gvDanhSach.GetFocusedRowCellValue("MaDTC").ToString();
                txtMaDTC.Text = gvDanhSach.GetFocusedRowCellValue("MaDTC").ToString();
                txtTenDTC.Text = gvDanhSach.GetFocusedRowCellValue("TenDTC").ToString();
                txtSoDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("SoDienThoai").ToString();
                cboQuanLy.EditValue = gvDanhSach.GetFocusedRowCellValue("QuanLy").ToString();
                txtKinhDo.Text = gvDanhSach.GetFocusedRowCellValue("KinhDo").ToString();
                txtViDo.EditValue = gvDanhSach.GetFocusedRowCellValue("ViDo").ToString();
                tgsKhongSuDung.IsOn = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KhongSuDung").ToString());
                cboTinh.EditValue = gvDanhSach.GetFocusedRowCellValue("Tinh");
                cboHuyen.EditValue = gvDanhSach.GetFocusedRowCellValue("Huyen");
                cboXa.EditValue = gvDanhSach.GetFocusedRowCellValue("Xa");
                cboAp.EditValue = gvDanhSach.GetFocusedRowCellValue("Ap");
                txtDuong.Text = gvDanhSach.GetFocusedRowCellValue("Duong")?.ToString() ?? "";
            }
        }
        private void btnKeThua_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaDTC.Text = Function.GenerateAutoCode("DTC", 5, "MaDTC", "DIEMTRUNGCHUYEN"); ;
            txtMaDTC.Enabled = true;
            showHideControl(false);
        }

        private void cboTinh_EditValueChanged(object sender, EventArgs e)
        {
            LoadHuyen(cboTinh.EditValue.ToString());
        }

        private void cboHuyen_EditValueChanged(object sender, EventArgs e)
        {
            LoadXa(cboHuyen.EditValue.ToString());
        }

        private void cboXa_EditValueChanged(object sender, EventArgs e)
        {
            LoadAp(cboXa.EditValue.ToString());
        }
    }
}