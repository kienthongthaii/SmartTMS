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
using BusinessLayer.DANHMUC;
using BusinessLayer;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace SmartTMS_Project.DANHMUC
{
    public partial class frm_TaiXe : DevExpress.XtraEditors.XtraForm
    {
        public frm_TaiXe()
        {
            InitializeComponent();
        }
        TaiXe _TaiXe;
        DonVi _donvi;
        bool _them;
        string _maTaiXe;
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

        private void frm_TaiXe_Load(object sender, EventArgs e)
        {
            _TaiXe = new TaiXe();
            _donvi = new DonVi();
            gvDanhSach.OptionsView.ColumnAutoWidth = false;
            LoadData();
            loadDonVi();
            showHideControl(true);
            txtMaTX.Enabled = false;
            Load_StepProgress();
        }
        void loadDonVi()
        {
            cboDonVi.Properties.DataSource = _donvi.getAll();
            cboDonVi.Properties.Columns.Clear();
            cboDonVi.Properties.Columns.Add(new LookUpColumnInfo("TenDonVi", "Tên Đơn Vị"));
            cboDonVi.Properties.DisplayMember = "TenDonVi";
            cboDonVi.Properties.ValueMember = "MaDonVi";
        }
        private void Load_StepProgress()
        {
            sPBTrangThai.ItemOptions.Indicator.Width = 50;
            sPBTrangThai.ConnectorLineThickness = 2;
            sPBTrangThai.ItemOptions.ConnectorOffset = -20;
            sPBTrangThai.ItemOptions.Indicator.ActiveStateDrawMode = IndicatorDrawMode.Full;
            sPBTrangThai.ItemOptions.Indicator.InactiveStateDrawMode = IndicatorDrawMode.Outline;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _TaiXe.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void ClearData()
        {
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSoDT.Clear();
            txtDiaChi.Clear();
            txtGhiChu.Clear();
            dtNgaySinh.EditValue = DateTime.Now;
            txtCCCD.Clear();
            dtNgayHetHan.EditValue = DateTime.Now;
            dtNgayVaoLam.EditValue = DateTime.Now;
            txtLuongCoBan.Clear();
            txtTrinhDoChuyenMon.Clear();
            txtKinhNghiem.Clear();
            tgGioiTinh.IsOn  = true;
            cbLoaiBangLai.Clear();
            cbLoaiBangLai.Clear();
            cboDonVi.Clear();
        }
        private bool KiemTraDuLieuDay()
        {
            // Danh sách để lưu các trường chưa được điền
            List<string> truongChuaDay = new List<string>();

            // Kiểm tra các TextEdit
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                truongChuaDay.Add("Họ Tên");

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                truongChuaDay.Add("Email");

            if (string.IsNullOrWhiteSpace(txtSoDT.Text))
                truongChuaDay.Add("Số Điện Thoại");

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                truongChuaDay.Add("Địa Chỉ");

            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
                truongChuaDay.Add("Căn Cước Công Dân");

            if (string.IsNullOrWhiteSpace(txtLuongCoBan.Text))
                truongChuaDay.Add("Lương Cơ Bản");

            if (string.IsNullOrWhiteSpace(txtTrinhDoChuyenMon.Text))
                truongChuaDay.Add("Trình Độ Chuyên Môn");

            if (string.IsNullOrWhiteSpace(txtKinhNghiem.Text))
                truongChuaDay.Add("Kinh Nghiệm");

            // Kiểm tra các DateEdit
            if (dtNgaySinh.EditValue == null)
                truongChuaDay.Add("Ngày Sinh");

            if (dtNgayHetHan.EditValue == null)
                truongChuaDay.Add("Ngày Hết Hạn");

            if (dtNgayVaoLam.EditValue == null)
                truongChuaDay.Add("Ngày Vào Làm");

            // Kiểm tra TextEdit và ComboBox khác
            if (string.IsNullOrWhiteSpace(txtGhiChu.Text))
                truongChuaDay.Add("Ghi Chú");

            if (cbLoaiBangLai.SelectedItem == null)
                truongChuaDay.Add("Loại Bằng Lái");

            if (cbLoaiBangLai.SelectedItem == null)
                truongChuaDay.Add("Bằng Lái");

            if (cboDonVi.EditValue == null)
                truongChuaDay.Add("Đơn Vị");

            // Kiểm tra trạng thái Toggle
            // Lưu ý: IsOn của ToggleSwitch luôn có giátrị, nên không cần kiểm tra null

            // Nếu có trường chưa được điền
            if (truongChuaDay.Count > 0)
            {
                // Tạo thông báo chi tiết
                string thongBao = "Các trường sau chưa được điền đầy đủ:\n";
                thongBao += string.Join("\n", truongChuaDay);

                // Hiển thị thông báo cảnh báo
                XtraMessageBox.Show(thongBao, "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            // Tất cả các trường đã được điền
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaTX.Text = Function.GenerateAutoCode("TX", 5, "MaTX", "TAIXE");
            txtMaTX.Enabled = true;
            showHideControl(false);
            ClearData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaTX.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_maTaiXe);
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _TaiXe.Delete(_maTaiXe);
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
            if (_them)
            {
                if (KiemTraDuLieuDay())
                {
                    TAIXE item = new TAIXE();
                    item.MaTX = txtMaTX.Text;
                    item.MaDV = cboDonVi.EditValue.ToString();
                    item.HoTen = txtHoTen.Text;
                    item.GioiTinh = tgGioiTinh.IsOn;
                    item.NgaySinh = DateTime.Parse(dtNgaySinh.EditValue.ToString());
                    item.SoDT = txtSoDT.Text;
                    item.DiaChi = txtDiaChi.Text;
                    item.Email = txtEmail.Text;
                    item.CCCD = txtCCCD.Text;
                    item.GhiChu = txtGhiChu.Text;
                    item.NgayVaoLam = DateTime.Parse(dtNgayVaoLam.EditValue.ToString());
                    item.BangLai = cbLoaiBangLai.Text;
                    item.LoaiBangLai = cbLoaiBangLai.Text;
                    item.NgayHetHanBL = DateTime.Parse(dtNgayHetHan.EditValue.ToString());
                    item.LuongCoBan = Double.Parse(txtLuongCoBan.Text);
                    item.TrinhDoChuyenMon = txtTrinhDoChuyenMon.Text;
                    item.KinhNghiem = txtKinhNghiem.Text;
                    item.TrangThai = "Chờ đơn";
                    item.Anh = ConvertImageToByteArray(pAnh);
                    _TaiXe.Add(item);
                }
            }
            else
            {
                TAIXE item = _TaiXe.getItem(_maTaiXe);
                item.MaDV = cboDonVi.EditValue.ToString();
                item.HoTen = txtHoTen.Text;
                item.GioiTinh = tgGioiTinh.IsOn;
                item.NgaySinh = DateTime.Parse(dtNgaySinh.EditValue.ToString());
                item.SoDT = txtSoDT.Text;
                item.DiaChi = txtDiaChi.Text;
                item.Email = txtEmail.Text;
                item.CCCD = txtCCCD.Text;
                item.GhiChu = txtGhiChu.Text;
                item.NgayVaoLam = DateTime.Parse(dtNgayVaoLam.EditValue.ToString());
                item.BangLai = cbLoaiBangLai.Text;
                item.LoaiBangLai = cbLoaiBangLai.Text;
                item.NgayHetHanBL = DateTime.Parse(dtNgayHetHan.EditValue.ToString());
                item.LuongCoBan = Double.Parse(txtLuongCoBan.Text);
                item.TrinhDoChuyenMon = txtTrinhDoChuyenMon.Text;
                item.KinhNghiem = txtKinhNghiem.Text;
                item.TrangThai = "Chờ đơn";
                item.Anh = ConvertImageToByteArray(pAnh);
                _TaiXe.Update(item);
            }
            _them = false;
            LoadData();
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaTX.Enabled = false;
        }
         // Random từ 1 đến 100 (101 không được bao gồm)

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            float tongDon = random.Next(1, 101);
            if (gvDanhSach.RowCount > 0 && gvDanhSach.FocusedRowHandle >= 0)
            {
                _maTaiXe = gvDanhSach.GetFocusedRowCellValue("MaTX").ToString();
                txtMaTX.Text = gvDanhSach.GetFocusedRowCellValue("MaTX").ToString();
                cboDonVi.EditValue = gvDanhSach.GetFocusedRowCellValue("MaDV").ToString();
                txtHoTen.Text = gvDanhSach.GetFocusedRowCellValue("HoTen").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("Email").ToString();
                txtSoDT.Text = gvDanhSach.GetFocusedRowCellValue("SoDT").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DiaChi").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChu")?.ToString() ?? "";
                dtNgaySinh.EditValue = gvDanhSach.GetFocusedRowCellValue("NgaySinh");
                txtCCCD.Text = gvDanhSach.GetFocusedRowCellValue("CCCD").ToString();
                dtNgayHetHan.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayHetHanBL");
                dtNgayVaoLam.EditValue = gvDanhSach.GetFocusedRowCellValue("NgayVaoLam");
                txtLuongCoBan.Text = gvDanhSach.GetFocusedRowCellValue("LuongCoBan").ToString();
                txtTrinhDoChuyenMon.Text = gvDanhSach.GetFocusedRowCellValue("TrinhDoChuyenMon").ToString();
                txtKinhNghiem.Text = gvDanhSach.GetFocusedRowCellValue("KinhNghiem").ToString();
                tgGioiTinh.IsOn = bool.Parse(gvDanhSach.GetFocusedRowCellValue("GioiTinh").ToString());
                cbLoaiBangLai.EditValue = gvDanhSach.GetFocusedRowCellValue("LoaiBangLai").ToString();
                txtBangLai.Text = gvDanhSach.GetFocusedRowCellValue("BangLai").ToString();
                txtTongSoDonGiao.Text = tongDon.ToString();
                txtSoDonThang.Text = (tongDon/12).ToString();
                txtSoDonNgay.Text = (tongDon/365).ToString();
                Random randomx = new Random();
                rcDanhGia.Rating = randomx.Next(0, 6); // Random từ 0 đến 5 (6 không được bao gồm)

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

                string trangThai = gvDanhSach.GetFocusedRowCellValue("TrangThai").ToString();
                // Reset trạng thái của tất cả các bước về mặc định
                foreach (StepProgressBarItem item in sPBTrangThai.Items)
                {
                    item.State = StepProgressBarItemState.Inactive;
                }

                sPBTrangThai.Appearances.CommonActiveColor = Color.Gray; // Màu mặc định
                switch (trangThai)
                {
                    case "Nghỉ phép":
                        spNghiPhep.State = StepProgressBarItemState.Active;
                        sPBTrangThai.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                        sPBTrangThai.Appearances.CommonActiveColor = Color.Green;
                        sPBTrangThai.Items[0].ContentBlock2.Caption = "Nghỉ phép";
                        break;
                    case "Chờ đơn":
                        spChoDon.State = StepProgressBarItemState.Active;
                        sPBTrangThai.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                        sPBTrangThai.Appearances.CommonActiveColor = Color.Green;
                        sPBTrangThai.Items[1].ContentBlock2.Caption = "Chờ đơn";
                        break;
                    case "Giao hàng":
                        spGiaoHang.State = StepProgressBarItemState.Active;
                        sPBTrangThai.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                        sPBTrangThai.Appearances.CommonActiveColor = Color.Green;
                        sPBTrangThai.Items[2].ContentBlock2.Caption = "Giao hàng";
                        break;
                    case "Bảo trì xe":
                        spBaoTri.State = StepProgressBarItemState.Active;
                        sPBTrangThai.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection1[0];
                        sPBTrangThai.Appearances.CommonActiveColor = Color.Green;
                        sPBTrangThai.Items[3].ContentBlock2.Caption = "Bảo trì xe";
                        break;
                    // Thêm các trường hợp khác nếu cần
                    default:
                        // Xử lý khi không khớp với các giá trị trên
                        break;
                }


            }
        }

        private void btnKeThua_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaTX.Text = Function.GenerateAutoCode("TX", 5, "MaTX", "TAIXE");
            txtMaTX.Enabled = true;
            showHideControl(false);
        }
    }
}