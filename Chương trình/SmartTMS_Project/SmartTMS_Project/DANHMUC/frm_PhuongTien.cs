using BusinessLayer;
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
    public partial class frm_PhuongTien : DevExpress.XtraEditors.XtraForm
    {
        public frm_PhuongTien()
        {
            InitializeComponent();
        }

        PhuongTien _PhuongTien;
        TaiXe _TaiXe;
        Bai _bai;
        bool _them;
        string _maPHUONGTIEN;
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
        private void frm_PhuongTien_Load(object sender, EventArgs e)
        {
            _PhuongTien = new PhuongTien();
            _TaiXe = new TaiXe();
            _bai = new Bai();
            LoadData();
            LoadTaiXe();
            LoadBaiXe();
            showHideControl(true);
            txtMaPT.Enabled = false;
        }
        void LoadTaiXe()
        {
            cboTaiXe.Properties.DataSource = _TaiXe.getAll();
            cboTaiXe.Properties.Columns.Clear();
            cboTaiXe.Properties.Columns.Add(new LookUpColumnInfo("HoTen", "Tài xế"));
            cboTaiXe.Properties.DisplayMember = "HoTen";
            cboTaiXe.Properties.ValueMember = "MaTX";
        }
        void LoadBaiXe()
        {
            cboBaiXe.Properties.DataSource = _bai.getAll();
            cboBaiXe.Properties.Columns.Clear();
            cboBaiXe.Properties.Columns.Add(new LookUpColumnInfo("TenBai", "Bãi xe"));
            cboBaiXe.Properties.DisplayMember = "TenBai";
            cboBaiXe.Properties.ValueMember = "MaBai";
        }

        void LoadData()
        {
            gcDanhSach.DataSource = _PhuongTien.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaPT.Enabled = true;
            showHideControl(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaPT.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _PhuongTien.Delete(_maPHUONGTIEN);
            }
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;
            if (_them)
            {
                PHUONGTIEN item = new PHUONGTIEN();

                item.MaPT = txtMaPT.Text;
                item.BienSo = txtBienSo.Text;
                item.LoaiXe = cboLoaiXe.EditValue.ToString();
                item.Model = txtModel.Text;
                item.NamSX = int.Parse(txtNamSanXuat.Text);
                item.TaiTrong = double.Parse(txtTaiTrong.Text);
                item.DungTich = double.Parse(txtDungTich.Text);
                item.MauXe = txtMauXe.Text;
                item.SoKhung = txtSoKhung.Text;
                item.SoMay = txtSoMay.Text;
                item.NgayDangKiem = DateTime.Parse(dtNgayDangKiem.EditValue.ToString());
                item.NgayHetHanDK = DateTime.Parse(dtNgayHetHan.EditValue.ToString());
                item.TrangThai = "Đang trống"; // Giá trị mặc định nếu không có nút nào được chọn
                item.KmHienTai = double.Parse(txtSoKmHienTai.Text);
                item.GhiChu = txtGhiChu.Text;
                item.MaBai = cboBaiXe.EditValue.ToString();
                item.KhongSuDung = tgsKhongSuDung.IsOn;
                item.MaTX = cboTaiXe.EditValue.ToString();
                _PhuongTien.Add(item);
            }
            else
            {
                PHUONGTIEN item = _PhuongTien.getItem(_maPHUONGTIEN);

                item.BienSo = txtBienSo.Text;
                item.LoaiXe = cboLoaiXe.EditValue.ToString();
                item.Model = txtModel.Text;
                item.NamSX = int.Parse(txtNamSanXuat.Text);
                item.TaiTrong = double.Parse(txtTaiTrong.Text);
                item.DungTich = double.Parse(txtDungTich.Text);
                item.MauXe = txtMauXe.Text;
                item.SoKhung = txtSoKhung.Text;
                item.SoMay = txtSoMay.Text;
                item.NgayDangKiem = DateTime.Parse(dtNgayDangKiem.EditValue.ToString());
                item.NgayHetHanDK = DateTime.Parse(dtNgayHetHan.EditValue.ToString());
                item.MaTX = cboTaiXe.EditValue.ToString();
                if (rbtDangHoatDong.Checked)
                {
                    item.TrangThai = "Đang hoạt động";
                }
                else if (rbtDangTrong.Checked)
                {
                    item.TrangThai = "Đang trống";
                }
                else if (rbtBaoTri.Checked)
                {
                    item.TrangThai = "Đang bảo trì";
                }
                else if (rbtKhac.Checked)
                {
                    item.TrangThai = "Khác";
                }
                else
                {
                    item.TrangThai = "Không xác định"; // Giá trị mặc định nếu không có nút nào được chọn
                }
                item.KmHienTai = double.Parse(txtSoKmHienTai.Text);
                item.GhiChu = txtGhiChu.Text;
                item.MaBai = cboBaiXe.EditValue.ToString();
                item.KhongSuDung = tgsKhongSuDung.IsOn;
                _PhuongTien.Update(item);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }
        private bool ValidateInputs()
        {
            // Kiểm tra mã phương tiện
            if (string.IsNullOrWhiteSpace(txtMaPT.Text))
            {
                MessageBox.Show("Mã phương tiện không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPT.Focus();
                return false;
            }

            // Kiểm tra biển số
            if (string.IsNullOrWhiteSpace(txtBienSo.Text))
            {
                MessageBox.Show("Biển số không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBienSo.Focus();
                return false;
            }

            // Kiểm tra loại xe
            if (cboLoaiXe.EditValue == null || string.IsNullOrWhiteSpace(cboLoaiXe.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn loại xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiXe.Focus();
                return false;
            }

            // Kiểm tra model xe
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Model xe không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModel.Focus();
                return false;
            }

            // Kiểm tra năm sản xuất
            if (!int.TryParse(txtNamSanXuat.Text, out int namSX) || namSX <= 0)
            {
                MessageBox.Show("Năm sản xuất phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSanXuat.Focus();
                return false;
            }

            // Kiểm tra tải trọng
            if (!double.TryParse(txtTaiTrong.Text, out double taiTrong) || taiTrong <= 0)
            {
                MessageBox.Show("Tải trọng phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiTrong.Focus();
                return false;
            }

            // Kiểm tra dung tích
            if (!double.TryParse(txtDungTich.Text, out double dungTich) || dungTich <= 0)
            {
                MessageBox.Show("Dung tích phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDungTich.Focus();
                return false;
            }

            // Kiểm tra màu xe
            if (string.IsNullOrWhiteSpace(txtMauXe.Text))
            {
                MessageBox.Show("Màu xe không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMauXe.Focus();
                return false;
            }

            // Kiểm tra số khung
            if (string.IsNullOrWhiteSpace(txtSoKhung.Text))
            {
                MessageBox.Show("Số khung không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoKhung.Focus();
                return false;
            }

            // Kiểm tra số máy
            if (string.IsNullOrWhiteSpace(txtSoMay.Text))
            {
                MessageBox.Show("Số máy không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoMay.Focus();
                return false;
            }

            // Kiểm tra ngày đăng kiểm
            if (!DateTime.TryParse(dtNgayDangKiem.EditValue?.ToString(), out _))
            {
                MessageBox.Show("Ngày đăng kiểm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgayDangKiem.Focus();
                return false;
            }

            // Kiểm tra ngày hết hạn đăng kiểm
            if (!DateTime.TryParse(dtNgayHetHan.EditValue?.ToString(), out _))
            {
                MessageBox.Show("Ngày hết hạn đăng kiểm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgayHetHan.Focus();
                return false;
            }

            // Kiểm tra số km hiện tại
            if (!double.TryParse(txtSoKmHienTai.Text, out double kmHienTai) || kmHienTai < 0)
            {
                MessageBox.Show("Số km hiện tại phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoKmHienTai.Focus();
                return false;
            }

            // Kiểm tra mã bãi xe
            if (cboBaiXe.EditValue == null || string.IsNullOrWhiteSpace(cboBaiXe.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn bãi xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBaiXe.Focus();
                return false;
            }

            // Kiểm tra mã tài xế
            if (cboTaiXe.EditValue == null || string.IsNullOrWhiteSpace(cboTaiXe.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn tài xế.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTaiXe.Focus();
                return false;
            }

            return true;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaPT.Enabled = false;
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maPHUONGTIEN = gvDanhSach.GetFocusedRowCellValue("MaTX").ToString();
                txtMaPT.Text = gvDanhSach.GetFocusedRowCellValue("MaTX").ToString();
                txtBienSo.Text = gvDanhSach.GetFocusedRowCellValue("BienSo").ToString();
                cboLoaiXe.EditValue = gvDanhSach.GetFocusedRowCellValue("LoaiXe").ToString();
                cboTaiXe.EditValue = gvDanhSach.GetFocusedRowCellValue("MaTX").ToString();
                cboBaiXe.EditValue = gvDanhSach.GetFocusedRowCellValue("MaBai").ToString();
                txtHangXe.Text = gvDanhSach.GetFocusedRowCellValue("HangXe").ToString();
                txtModel.Text = gvDanhSach.GetFocusedRowCellValue("Model").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChu").ToString();
                txtTaiTrong.EditValue = gvDanhSach.GetFocusedRowCellValue("TaiTrong");
                txtDungTich.Text = gvDanhSach.GetFocusedRowCellValue("DungTich").ToString();
                dtNgayHetHan.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayHetHanDK");
                txtMauXe.EditValue = gvDanhSach.GetFocusedRowCellValue("MauXe");
                txtSoKhung.Text = gvDanhSach.GetFocusedRowCellValue("SoKhung").ToString();
                txtSoMay.Text = gvDanhSach.GetFocusedRowCellValue("SoMay").ToString();
                dtNgayDangKiem.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayDangKiem").ToString();
                txtNamSanXuat.Text = gvDanhSach.GetFocusedRowCellValue("NamSX").ToString();
                txtSoKmHienTai.Text = gvDanhSach.GetFocusedRowCellValue("KmHienTai").ToString();
                tgsKhongSuDung.IsOn = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KhongSuDung").ToString());
                string trangThai = gvDanhSach.GetFocusedRowCellValue("TrangThai").ToString();
                rbtDangHoatDong.Checked = false;
                rbtBaoTri.Checked = false;
                rbtDangTrong.Checked = false;
                rbtKhac.Checked = false;
                switch (trangThai)
                {
                    case "Nằm bãi":
                        rbtDangTrong.Checked = true;
                        break;
                    case "Đang vận hành":
                        rbtDangHoatDong.Checked = true;
                        break;
                    case "Bảo trì":
                       rbtBaoTri.Checked= true;
                        break;
                    case "Khác":
                       rbtKhac.Checked= true;
                        break;
                    // Thêm các trường hợp khác nếu cần
                    default:
                        // Xử lý khi không khớp với các giá trị trên
                        break;
                }


            }
        }
    }
}