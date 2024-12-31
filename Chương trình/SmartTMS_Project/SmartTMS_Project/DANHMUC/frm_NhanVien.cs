using BusinessLayer;
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
    public partial class frm_NhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frm_NhanVien()
        {
            InitializeComponent();
        }

        NhanVien _NhanVien;
        DonVi _DonVi;
        bool _them;
        string _maNhanVien;
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

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {

            _NhanVien = new NhanVien();
            _DonVi = new DonVi();
            gvDanhSach.OptionsView.ColumnAutoWidth = false;

            LoadData();
            loadDonVi();
            showHideControl(true);
            txtMaNV.Enabled = false;
        }
        

        private void CboCongTy_EditValueChanged(object sender, EventArgs e)
        {
            LoadNhanVien_By_Cty();
        }


        void LoadNhanVien_By_Cty()
        {
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _NhanVien.getAll();
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
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSoDT.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();
            dtNgaySinh.EditValue = DateTime.Now;
            txtCCCD.Clear();
            dtNgayVaoLam.EditValue = DateTime.Now;
            txtLuongCoBan.Clear();
            txtKinhNghiem.Clear();
            tgsGioiTinh.IsOn = false;
            cboChucVu.Clear();
            cboPhongBan.Clear();
            cboDonVi.Clear();
            cboTrinhDo.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            ClearData();
            txtMaNV.Text = Function.GenerateAutoCode("NV", 5, "MaNV", "NHANVIEN");
            txtMaNV.Enabled = true;
            showHideControl(false);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaNV.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_maNhanVien);
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _NhanVien.Delete(_maNhanVien);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
        }


        private byte[] ConvertImageToByteArray(PictureEdit pictureEdit)
        {
            if (pictureEdit.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureEdit.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Hoặc định dạng khác như JPEG
                    return ms.ToArray();
                }
            }
            return null; // Nếu không có ảnh
        }
        private Image ConvertByteArrayToImage(byte[] imageBytes)
        {
            if (imageBytes != null && imageBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            return null; // Nếu không có dữ liệu ảnh
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeInputs())
                return;
            if (_them)
            {
                NHANVIEN item = new NHANVIEN();

                item.MaNV = txtMaNV.Text;
                item.MaDV = cboDonVi.EditValue.ToString();
                item.HoTen = txtHoTen.Text;
                item.GioiTinh = tgsGioiTinh.IsOn;
                item.NgaySinh = DateTime.Parse(dtNgaySinh.EditValue.ToString());
                item.SoDT = txtSoDT.Text;
                item.DiaChi = txtDiaChi.Text;
                item.Email = txtEmail.Text;
                item.CCCD = txtCCCD.Text;
                item.GhiChu = txtGhiChu.Text;
                item.NgayVaoLam = DateTime.Parse(dtNgayVaoLam.EditValue.ToString());
                item.ChucVu = cboChucVu.EditValue.ToString();
                item.PhongBan = cboPhongBan.EditValue.ToString();
                item.TrinhDo = cboTrinhDo.EditValue.ToString();
                item.LuongCoBan = Double.Parse(txtLuongCoBan.Text);
                item.KinhNghiem = txtKinhNghiem.Text;
                item.TrangThai = "Đang làm việc";
                item.Anh = ConvertImageToByteArray(pAnh);
                _NhanVien.Add(item);
            }
            else
            {
                NHANVIEN item = _NhanVien.getItem(_maNhanVien);
                item.HoTen = txtHoTen.Text;
                item.GioiTinh = tgsGioiTinh.IsOn;
                item.NgaySinh = DateTime.Parse(dtNgaySinh.EditValue.ToString());
                item.SoDT = txtSoDT.Text;
                item.DiaChi = txtDiaChi.Text;
                item.Email = txtEmail.Text;
                item.CCCD = txtCCCD.Text;
                item.GhiChu = txtGhiChu.Text;
                item.NgayVaoLam = DateTime.Parse(dtNgayVaoLam.EditValue.ToString());
                item.ChucVu = cboChucVu.EditValue.ToString();
                item.PhongBan = cboPhongBan.EditValue.ToString();
                item.TrinhDo = cboTrinhDo.EditValue.ToString();
                item.LuongCoBan = Double.Parse(txtLuongCoBan.Text);
                item.KinhNghiem = txtKinhNghiem.Text;
                item.TrangThai = tgsTrangThai.IsOn ? "Đang làm việc" : "Nghỉ phép";
                item.Anh = ConvertImageToByteArray(pAnh);
                _NhanVien.Update(item);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }
        private bool ValidateEmployeeInputs()
        {
            // Kiểm tra mã nhân viên
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return false;
            }

            // Kiểm tra đơn vị
            if (cboDonVi.EditValue == null || string.IsNullOrWhiteSpace(cboDonVi.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDonVi.Focus();
                return false;
            }

            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            // Kiểm tra ngày sinh
            if (!DateTime.TryParse(dtNgaySinh.EditValue?.ToString(), out _))
            {
                MessageBox.Show("Ngày sinh không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgaySinh.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(txtSoDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDT.Focus();
                return false;
            }

            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra CCCD
            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("CCCD không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return false;
            }

            // Kiểm tra ngày vào làm
            if (!DateTime.TryParse(dtNgayVaoLam.EditValue?.ToString(), out _))
            {
                MessageBox.Show("Ngày vào làm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgayVaoLam.Focus();
                return false;
            }

            // Kiểm tra chức vụ
            if (cboChucVu.EditValue == null || string.IsNullOrWhiteSpace(cboChucVu.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn chức vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return false;
            }

            // Kiểm tra phòng ban
            if (cboPhongBan.EditValue == null || string.IsNullOrWhiteSpace(cboPhongBan.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn phòng ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhongBan.Focus();
                return false;
            }

            // Kiểm tra trình độ
            if (cboTrinhDo.EditValue == null || string.IsNullOrWhiteSpace(cboTrinhDo.EditValue.ToString()))
            {
                MessageBox.Show("Vui lòng chọn trình độ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrinhDo.Focus();
                return false;
            }

            // Kiểm tra lương cơ bản
            if (!double.TryParse(txtLuongCoBan.Text, out double luongCoBan) || luongCoBan <= 0)
            {
                MessageBox.Show("Lương cơ bản phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLuongCoBan.Focus();
                return false;
            }

            // Kiểm tra kinh nghiệm
            if (string.IsNullOrWhiteSpace(txtKinhNghiem.Text))
            {
                MessageBox.Show("Kinh nghiệm không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKinhNghiem.Focus();
                return false;
            }

            return true;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaNV.Enabled = false;
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maNhanVien = gvDanhSach.GetFocusedRowCellValue("MaNV").ToString();
                txtMaNV.Text = gvDanhSach.GetFocusedRowCellValue("MaNV").ToString();
                txtHoTen.Text = gvDanhSach.GetFocusedRowCellValue("HoTen").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("Email").ToString();
                txtSoDT.Text = gvDanhSach.GetFocusedRowCellValue("SoDT").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DiaChi").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChu").ToString();
                dtNgaySinh.EditValue = gvDanhSach.GetFocusedRowCellValue("NgaySinh");
                txtCCCD.Text = gvDanhSach.GetFocusedRowCellValue("CCCD").ToString();
                dtNgayVaoLam.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayVaoLam");
                txtLuongCoBan.Text = gvDanhSach.GetFocusedRowCellValue("LuongCoBan").ToString();
                cboTrinhDo.EditValue = gvDanhSach.GetFocusedRowCellValue("TrinhDo").ToString();
                txtKinhNghiem.Text = gvDanhSach.GetFocusedRowCellValue("KinhNghiem").ToString();
                tgsGioiTinh.IsOn = bool.Parse(gvDanhSach.GetFocusedRowCellValue("GioiTinh").ToString());
                cboPhongBan.EditValue = gvDanhSach.GetFocusedRowCellValue("PhongBan").ToString();
                cboChucVu.EditValue = gvDanhSach.GetFocusedRowCellValue("ChucVu").ToString();
                cboDonVi.EditValue = gvDanhSach.GetFocusedRowCellValue("MaDV").ToString();
                string trangThai = gvDanhSach.GetFocusedRowCellValue("TrangThai")?.ToString();
                tgsTrangThai.IsOn = (trangThai == "Đang làm việc") ? true : false;

                // Lấy ảnh từ GridView và hiển thị lên PictureEdit
                var anhData = gvDanhSach.GetFocusedRowCellValue("Anh");
                if (anhData != null && anhData != DBNull.Value)
                {
                    byte[] anhBytes = (byte[])anhData;
                    pAnh.Image = ConvertByteArrayToImage(anhBytes);
                }
                else
                {
                    if (!bool.Parse(gvDanhSach.GetFocusedRowCellValue("GioiTinh").ToString()))
                        pAnh.Image = Properties.Resources.avt_default_man;
                    else
                        pAnh.Image = Properties.Resources.avt_default_woman;

                }

               


            }
        }
        private void btnKeThua_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaNV.Text = Function.GenerateAutoCode("NV", 5, "MaNV", "NHANVIEN"); ;
            txtMaNV.Enabled = true;
            showHideControl(false);
        }
    }
}