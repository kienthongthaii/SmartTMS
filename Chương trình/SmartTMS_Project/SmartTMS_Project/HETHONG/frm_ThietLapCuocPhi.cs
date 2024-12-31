using BusinessLayer.DANHMUC;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
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
using System.Xml;

namespace SmartTMS_Project.HETHONG
{
    public partial class frm_ThietLapCuocPhi : DevExpress.XtraEditors.XtraForm
    {
        public frm_ThietLapCuocPhi()
        {
            InitializeComponent();
        }
        ThietLapCuocPhi _thietLapCuocPhi;
        bool _them;
        string _maCuocPhi;
        void LoadData()
        {
            gcDanhSach.DataSource = _thietLapCuocPhi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false; // Cho phép chỉnh sửa
            

        }

        private void frm_ThietLapCuocPhi_Load(object sender, EventArgs e)
        {
            _thietLapCuocPhi = new ThietLapCuocPhi();
            LoadData();
            showHideControl(true);
        }

       

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }
        void ClearData()
        {
            cboLoaiPhuongTien.Clear();
            spChieuCao.Clear();
            spChieuDai.Clear();
            spChieuRong.Clear();
            spGiaCuoc.Clear();
            spTrongLuong.Clear();
            spQuangDuong.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            ClearData();
            showHideControl(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _thietLapCuocPhi.Delete(_maCuocPhi);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                CUOCPHI item = new CUOCPHI();
                item.MaCP = Function.GenerateAutoCode("CP", 4, "MaCP", "CUOCPHI");
                item.LoaiPT = cboLoaiPhuongTien.EditValue.ToString();
                item.TrongLuong = double.Parse(spTrongLuong.EditValue.ToString());
                item.KhoangCach = double.Parse(spQuangDuong.EditValue.ToString());
                item.ChieuCao = double.Parse(spChieuCao.EditValue.ToString());
                item.ChieuRong = double.Parse(spChieuRong.EditValue.ToString());
                item.ChieuDai = double.Parse(spChieuDai.EditValue.ToString());
                item.GiaTien = double.Parse(spGiaCuoc.EditValue.ToString());
                _thietLapCuocPhi.Add(item);
            }
            else
            {
                CUOCPHI item = _thietLapCuocPhi.getItem(_maCuocPhi);
                item.LoaiPT = cboLoaiPhuongTien.EditValue.ToString();
                item.TrongLuong = double.Parse(spTrongLuong.EditValue.ToString());
                item.KhoangCach = double.Parse(spQuangDuong.EditValue.ToString());
                item.ChieuCao = double.Parse(spChieuCao.EditValue.ToString());
                item.ChieuRong = double.Parse(spChieuRong.EditValue.ToString());
                item.ChieuDai = double.Parse(spChieuDai.EditValue.ToString());
                item.GiaTien = double.Parse(spGiaCuoc.EditValue.ToString());
                _thietLapCuocPhi.Update(item);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maCuocPhi = gvDanhSach.GetFocusedRowCellValue("MaCP").ToString();
                cboLoaiPhuongTien.EditValue = gvDanhSach.GetFocusedRowCellValue("LoaiPT").ToString();
                spTrongLuong.EditValue = gvDanhSach.GetFocusedRowCellValue("TrongLuong").ToString();
                spQuangDuong.EditValue = gvDanhSach.GetFocusedRowCellValue("KhoangCach").ToString();
                spChieuCao.EditValue = gvDanhSach.GetFocusedRowCellValue("ChieuCao").ToString();
                spChieuDai.EditValue = gvDanhSach.GetFocusedRowCellValue("ChieuDai").ToString();
                spChieuRong.EditValue = gvDanhSach.GetFocusedRowCellValue("ChieuRong").ToString();
                spGiaCuoc.EditValue = gvDanhSach.GetFocusedRowCellValue("GiaTien").ToString();
            }
        }

    }
}