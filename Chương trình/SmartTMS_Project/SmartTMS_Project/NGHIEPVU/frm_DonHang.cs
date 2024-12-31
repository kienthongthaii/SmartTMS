using BusinessLayer.NGHIEPVU;
using DevExpress.DashboardCommon;
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

namespace SmartTMS_Project.NGHIEPVU
{
    public partial class frm_DonHang : DevExpress.XtraEditors.XtraForm
    {
        public frm_DonHang()
        {
            InitializeComponent();
        }

        DonHang _DonHang;
        ChiTietDonHang _ChiTietDonHang;
        bool _them;
        string _maDonHang;
        string _maCTDonHang;
        string _maHangHoa;
        void showHideControl(bool t)
        {
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

        private void frm_DonHang_Load(object sender, EventArgs e)
        {
            _DonHang = new DonHang();
            _ChiTietDonHang = new ChiTietDonHang();
            LoadData();
            showHideControl(true);
            txtMaHang.Enabled = false;
        }
       

        void LoadData()
        {
            gcDonHang.DataSource = _DonHang.getAll();
            gvDonHang.OptionsBehavior.Editable = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaHang.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _DonHang.Delete(_maDonHang);
            }
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //if (_them)
            //{
            //    DonHang item = new DonHang();

            //    item.MaPT = txtMaCTDH.Text;
            //    item.BienSo = txtBienSo.Text;
            //    item.LoaiXe = cboLoaiXe.EditValue.ToString();
            //    item.Model = txtModel.Text;
            //    item.NamSX = int.Parse(txtNamSanXuat.Text);
            //    item.TaiTrong = double.Parse(txtTaiTrong.Text);
            //    item.DungTich = double.Parse(txtDungTich.Text);
            //    item.MauXe = txtMauXe.Text;
            //    item.SoKhung = txtSoKhung.Text;
            //    item.SoMay = txtSoMay.Text;
            //    item.NgayDangKiem = DateTime.Parse(dtNgayDangKiem.EditValue.ToString());
            //    item.NgayHetHanDK = DateTime.Parse(dtNgayHetHan.EditValue.ToString());
            //    item.TrangThai = "Đang trống"; // Giá trị mặc định nếu không có nút nào được chọn
            //    item.KmHienTai = double.Parse(txtSoKmHienTai.Text);
            //    item.GhiChu = txtGhiChu.Text;
            //    item.MaBai = cboBaiXe.EditValue.ToString();
            //    item.KhongSuDung = tgsKhongSuDung.IsOn;
            //    item.MaTX = cboTaiXe.EditValue.ToString();



            //    _DonHang.Add(item);
            //}
            //else
            //{
            //    DonHang item = _DonHang.getItem(_maDonHang);

            //    item.BienSo = txtBienSo.Text;
            //    item.LoaiXe = cboLoaiXe.EditValue.ToString();
            //    item.Model = txtModel.Text;
            //    item.NamSX = int.Parse(txtNamSanXuat.Text);
            //    item.TaiTrong = double.Parse(txtTaiTrong.Text);
            //    item.DungTich = double.Parse(txtDungTich.Text);
            //    item.MauXe = txtMauXe.Text;
            //    item.SoKhung = txtSoKhung.Text;
            //    item.SoMay = txtSoMay.Text;
            //    item.NgayDangKiem = DateTime.Parse(dtNgayDangKiem.EditValue.ToString());
            //    item.NgayHetHanDK = DateTime.Parse(dtNgayHetHan.EditValue.ToString());
            //    item.MaTX = cboTaiXe.EditValue.ToString();
            //    if (rbtDangHoatDong.Checked)
            //    {
            //        item.TrangThai = "Đang hoạt động";
            //    }
            //    else if (rbtDangTrong.Checked)
            //    {
            //        item.TrangThai = "Đang trống";
            //    }
            //    else if (rbtBaoTri.Checked)
            //    {
            //        item.TrangThai = "Đang bảo trì";
            //    }
            //    else if (rbtKhac.Checked)
            //    {
            //        item.TrangThai = "Khác";
            //    }
            //    else
            //    {
            //        item.TrangThai = "Không xác định"; // Giá trị mặc định nếu không có nút nào được chọn
            //    }
            //    item.KmHienTai = double.Parse(txtSoKmHienTai.Text);
            //    item.GhiChu = txtGhiChu.Text;
            //    item.MaBai = cboBaiXe.EditValue.ToString();
            //    item.KhongSuDung = tgsKhongSuDung.IsOn;
            //    _DonHang.Update(item);
            //}
            //_them = false;
            //LoadData();
            //showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaHang.Enabled = false;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gvDonHang_Click(object sender, EventArgs e)
        {
            if (gvDonHang.RowCount > 0)
            {
                _maDonHang = gvDonHang.GetFocusedRowCellValue("MaDH").ToString();
                gcCTDonHang.DataSource = _ChiTietDonHang.getAll(_maDonHang);
                gvCTDonHang.OptionsBehavior.Editable = false;

            }
        }

        private void gvCTDonHang_Click(object sender, EventArgs e)
        {
            if (gvCTDonHang.RowCount > 0)
            {
                _maHangHoa = gvCTDonHang.GetFocusedRowCellValue("MaHangHoa").ToString();
                txtMaHang.Text = gvCTDonHang.GetFocusedRowCellValue("MaHangHoa").ToString();
                txtTenHang.Text = gvCTDonHang.GetFocusedRowCellValue("TenHangHoa").ToString();
                cboTrangThai.EditValue = gvCTDonHang.GetFocusedRowCellValue("TrangThai");
                txtKhoiLuong.Text = gvCTDonHang.GetFocusedRowCellValue("KhoiLuong").ToString();
                txtDai.Text = gvCTDonHang.GetFocusedRowCellValue("ChieuDai").ToString();
                txtRong.Text = gvCTDonHang.GetFocusedRowCellValue("ChieuRong").ToString();
                txtCao.Text = gvCTDonHang.GetFocusedRowCellValue("ChieuCao").ToString();
                spSoLuong.Value = int.Parse(gvCTDonHang.GetFocusedRowCellValue("SoLuong").ToString());
                txtGiaTri.Text = gvCTDonHang.GetFocusedRowCellValue("GiaTri").ToString();
                txtYeuCauDacBiet.Text = gvCTDonHang.GetFocusedRowCellValue("YeuCauDB")?.ToString() ?? "";

                txtGhiChu.Text = gvCTDonHang.GetFocusedRowCellValue("GhiChu")?.ToString() ?? "";
            }

        }

        
    }
}