using BusinessLayer;
using BusinessLayer.DANHMUC;
using BusinessLayer.NGHIEPVU;
using DataLayer;
using DevExpress.PivotGrid.OLAP.Mdx;
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
    public partial class frm_ThietLapKeHoachVanChuyen : DevExpress.XtraEditors.XtraForm
    {
        public frm_ThietLapKeHoachVanChuyen()
        {
            InitializeComponent();
        }

        NhomKeHoach _NhomKeHoach;
        KeHoachVanChuyen _keHoachVanChuyen;
        DiemTrungChuyen _diemTrungChuyen;
        bool _them;
        string _maNhomKeHoach;
        string _maKHVC;
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_ThietLapKeHoachVanChuyen_Load(object sender, EventArgs e)
        {

            _NhomKeHoach = new NhomKeHoach();
            _keHoachVanChuyen = new KeHoachVanChuyen();
            _diemTrungChuyen = new DiemTrungChuyen();
            gvDanhSach.OptionsView.ColumnAutoWidth = false;

            LoadData();
            LoadDiemDau();
            LoadDiemKetThuc();
            showHideControl(true);
            txtMaKH.Enabled = false;
        }

        void LoadData()
        {
            gcDanhSach.DataSource = _NhomKeHoach.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void LoadTram()
        {
            gcTram.DataSource = _keHoachVanChuyen.getAll(_maNhomKeHoach);
            gvTram.OptionsBehavior.Editable = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMaKH.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_maNhomKeHoach);
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _NhomKeHoach.Delete(_maNhomKeHoach);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
        }

        void LoadDiemDau()
        {
            cboDiemDau.Properties.DataSource = _diemTrungChuyen.getAll();
            cboDiemDau.Properties.Columns.Clear();
            cboDiemDau.Properties.Columns.Add(new LookUpColumnInfo("TenDTC", "Điểm trung chuyển"));
            cboDiemDau.Properties.DisplayMember = "TenDTC";
            cboDiemDau.Properties.ValueMember = "MaDTC";
        }

        void LoadDiemKetThuc()
        {
            cboDiemDen.Properties.DataSource = _diemTrungChuyen.getAll();
            cboDiemDen.Properties.Columns.Clear();
            cboDiemDen.Properties.Columns.Add(new LookUpColumnInfo("TenDTC", "Điểm trung chuyển"));
            cboDiemDen.Properties.DisplayMember = "TenDTC";
            cboDiemDen.Properties.ValueMember = "MaDTC";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
                NHOMKEHOACH item = new NHOMKEHOACH();

                item.MaNKH = Function.GenerateAutoCode("NKH", 5, "MaNKH", "NHOMKEHOACH");
                item.TongThoiGian = 0;
                item.TongQuangDuong = 0;
                item.TongTieuHaoNhienLieu = 0; // Nếu bạn muốn giá trị là kiểu double
                item.TongChiPhi = 0;
                item.KhongSuDung = tgsKhongSuDung.IsOn;
                item.DiemBatDau = "";
                item.DiemKetThuc = "";
            _NhomKeHoach.Add(item);
            _them = false;
            LoadData();
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            txtMaKH.Enabled = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _maNhomKeHoach = gvDanhSach.GetFocusedRowCellValue("MaNKH").ToString();
                txtMaKH.Text = gvDanhSach.GetFocusedRowCellValue("MaNKH").ToString();
                tgsKhongSuDung.IsOn = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KhongSuDung").ToString());
                var tramCuoi = _keHoachVanChuyen.getTramCuoiTrongKeHoach(_maNhomKeHoach);

                if (tramCuoi != null)
                {
                    cboDiemDau.EditValue = tramCuoi.DiemKetThuc;
                    cboDiemDau.ReadOnly = true;
                }
                else
                {
                    cboDiemDau.EditValue = null;
                    cboDiemDau.ReadOnly = false;
                }

                gcTram.DataSource = _keHoachVanChuyen.getAll(_maNhomKeHoach);
                gvTram.OptionsBehavior.Editable = false;
            }
        }

        private void btnKeThua_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMaKH.Text = Function.GenerateAutoCode("NKH", 5, "MaNKH", "NHOMKEHOACH"); 
            txtMaKH.Enabled = true;
            showHideControl(false);
        }

        private void btnThemTram_Click(object sender, EventArgs e)
        {
            if (_keHoachVanChuyen.checkTonTai(cboDiemDau.EditValue.ToString(), cboDiemDen.EditValue.ToString(), _maNhomKeHoach))
            {
                MessageBox.Show("Kế hoạch vận chuyển đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (_keHoachVanChuyen.checkDiemCuoi(cboDiemDen.EditValue.ToString(), _maNhomKeHoach))
                {
                    MessageBox.Show("Đã có trạm đến điểm cuối này : "+ cboDiemDen.EditValue.ToString() + "]. Vui lòng chọn điểm cuối khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    KEHOACHVANCHUYEN item = new KEHOACHVANCHUYEN();

                    item.MaNKH = _maNhomKeHoach;
                    item.MaKHVC = Function.GenerateAutoCode("KHVC", 5, "MaKHVC", "KEHOACHVANCHUYEN");
                    item.ThoiGianNhanhNhat = double.Parse(spThoiGianNhanhNhat.EditValue.ToString());
                    item.ThoiGianChamNhat = double.Parse(spThoiGianChamNhat.EditValue.ToString()); // Nếu bạn muốn giá trị là kiểu double
                    item.QuangDuong = double.Parse(spKhoangCach.EditValue.ToString()); // Nếu bạn muốn giá trị là kiểu double
                    item.DiemBatDau = cboDiemDau.EditValue.ToString();
                    item.DiemKetThuc = cboDiemDen.EditValue.ToString();
                    item.PhuongAnDuPhong = cboKeHoachDuPhong.EditValue?.ToString() ?? "";
                    item.GhiChu = txtGhiChu.Text;
                    item.TieuHaoNhienLieu = double.Parse(spNhienLieuTieuHao.EditValue.ToString());
                    item.ChiPhi = double.Parse(spChiPhi.EditValue.ToString());
                    item.STT = Function.GenerateAutoSTT(_maNhomKeHoach);
                    _keHoachVanChuyen.Add(item);
                    LoadTram();
                    LoadData();
                    cboDiemDau.EditValue = cboDiemDen.EditValue?.ToString();
                    cboDiemDen.EditValue = null;
                    cboDiemDau.ReadOnly = true;
                }
            }


           
              
        }

        private void gvTram_Click(object sender, EventArgs e)
        {
            
            if (gvTram.RowCount > 0)
            {
                _maKHVC = gvTram.GetFocusedRowCellValue("MaKHVC").ToString();
                
                cboDiemDau.EditValue = gvTram.GetFocusedRowCellValue("DiemBatDau");
                cboDiemDen.EditValue = gvTram.GetFocusedRowCellValue("DiemKetThuc");
                spThoiGianNhanhNhat.EditValue = gvTram.GetFocusedRowCellValue("ThoiGianNhanhNhat");
                spThoiGianChamNhat.EditValue = gvTram.GetFocusedRowCellValue("ThoiGianChamNhat");
                spKhoangCach.EditValue = gvTram.GetFocusedRowCellValue("QuangDuong");
                spNhienLieuTieuHao.EditValue = gvTram.GetFocusedRowCellValue("TieuHaoNhienLieu");
                cboKeHoachDuPhong.EditValue = gvTram.GetFocusedRowCellValue("PhuongAnDuPhong");
                spThoiGianNhanhNhat.EditValue = gvTram.GetFocusedRowCellValue("ThoiGianNhanhNhat");
                spChiPhi.EditValue = gvTram.GetFocusedRowCellValue("ChiPhi");
                txtGhiChu.Text = gvTram.GetFocusedRowCellValue("GhiChu")?.ToString() ?? "";
            }
        }

        private void btnXoaTram_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maKHVC))
            {
                MessageBox.Show("Vui lòng chọn trạm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _keHoachVanChuyen.Delete(_maKHVC);
                LoadTram();
            }


        }

        private void btnCapNhatTram_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maKHVC))
            {
                MessageBox.Show("Vui lòng chọn trạm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                KEHOACHVANCHUYEN item = _keHoachVanChuyen.getItem(_maKHVC);
                item.ThoiGianNhanhNhat = double.Parse(spThoiGianNhanhNhat.EditValue.ToString());
                item.ThoiGianChamNhat = double.Parse(spThoiGianChamNhat.EditValue.ToString()); // Nếu bạn muốn giá trị là kiểu double
                item.QuangDuong = double.Parse(spKhoangCach.EditValue.ToString()); // Nếu bạn muốn giá trị là kiểu double
                item.DiemBatDau = cboDiemDau.EditValue.ToString();
                item.DiemKetThuc = cboDiemDen.EditValue.ToString();
                item.PhuongAnDuPhong = cboKeHoachDuPhong.EditValue?.ToString() ?? "";
                item.GhiChu = txtGhiChu.Text;
                item.TieuHaoNhienLieu = double.Parse(spNhienLieuTieuHao.EditValue.ToString());
                item.ChiPhi = double.Parse(spChiPhi.EditValue.ToString());
                _keHoachVanChuyen.Update(item);
                LoadTram();
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNhomKeHoach))
            {
                MessageBox.Show("Vui lòng chọn kế hoạch cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _NhomKeHoach.Delete(_maNhomKeHoach);
                LoadData();
            }

        }

        private void tgsKhongSuDung_Click(object sender, EventArgs e)
        {


            if (_NhomKeHoach.getItem(_maNhomKeHoach).KhongSuDung.Value)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn không sử dụng kế hoạch vận chuyển này nữa không?",
                    "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Kiểm tra lựa chọn của người dùng
                if (result == DialogResult.Yes)
                {
                    NHOMKEHOACH item = _NhomKeHoach.getItem(_maNhomKeHoach);
                    item.KhongSuDung = false;
                    _NhomKeHoach.Update(item);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                NHOMKEHOACH item = _NhomKeHoach.getItem(_maNhomKeHoach);
                item.KhongSuDung = true;
                _NhomKeHoach.Update(item);
            }
           
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void spThoiGianNhanhNhat_EditValueChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(spThoiGianNhanhNhat.EditValue?.ToString(), out decimal value) && value < 0)
            {
                MessageBox.Show("Giá trị thời gian không được là số âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spThoiGianNhanhNhat.EditValue = 0; // Đặt lại giá trị về 0 hoặc giá trị mặc định khác
            }
        }

        private void spThoiGianChamNhat_EditValueChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(spThoiGianChamNhat.EditValue?.ToString(), out decimal value) && value < 0)
            {
                MessageBox.Show("Giá trị thời gian không được là số âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spThoiGianChamNhat.EditValue = 0; // Đặt lại giá trị về 0 hoặc giá trị mặc định khác
            }
        }

        private void spNhienLieuTieuHao_EditValueChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(spNhienLieuTieuHao.EditValue?.ToString(), out decimal value) && value < 0)
            {
                MessageBox.Show("Giá trị nhiên liệu không được là số âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spNhienLieuTieuHao.EditValue = 0; // Đặt lại giá trị về 0 hoặc giá trị mặc định khác
            }
        }

        private void spKhoangCach_EditValueChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(spNhienLieuTieuHao.EditValue?.ToString(), out decimal value) && value < 0)
            {
                MessageBox.Show("Giá trị khoảng cách không được là số âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spKhoangCach.EditValue = 0; // Đặt lại giá trị về 0 hoặc giá trị mặc định khác
            }
        }

        private void spChiPhi_EditValueChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(spNhienLieuTieuHao.EditValue?.ToString(), out decimal value) && value < 0)
            {
                MessageBox.Show("Giá trị chi phí không được là số âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spChiPhi.EditValue = 0; // Đặt lại giá trị về 0 hoặc giá trị mặc định khác
            }
        }
    }
}