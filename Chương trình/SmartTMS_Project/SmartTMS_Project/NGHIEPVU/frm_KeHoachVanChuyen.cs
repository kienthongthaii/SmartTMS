using BusinessLayer;
using BusinessLayer.DANHMUC;
using BusinessLayer.NGHIEPVU;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using SmartTMS_Project.DANHMUC;
using SmartTMS_Project.HETHONG;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTMS_Project.NGHIEPVU
{
    public partial class frm_KeHoachVanChuyen : DevExpress.XtraEditors.XtraForm
    {
        public frm_KeHoachVanChuyen()
        {
            InitializeComponent();
        }


        KeHoachVanChuyen _KeHoachVanChuyen;
        NhomKeHoach _NhomKeHoach;
        DonHang _DonHang;
        DiemTrungChuyen _DiemTrungChuyen;
        PhuongTien _phuongTien;
        TaiXe _taiXe;
        ChiTietKeHoachVanChuyen _chiTietKeHoachVanChuyen;
        LichSuHanhTrinh _lichSuHanhTrinh;
        NhomLichSuHanhTrinh _nhomLichSuHanhTrinh;
        NhanVien _nhanVien;
        ThietLapCuocPhi _cuocPhi;
        string _maNhomKeHoach;
        string _maDonHang;
        string _maDTC;
        string _maKHVC;
        double khoangCach;
        double trongLuong;
        double chieuDai;
        double chieuRong;
        double chieuCao;
        double giaTien;
        double tongTienCuoc = 0;
        bool isFillingDataSource = true;


        private void frm_KeHoachVanChuyen_Load(object sender, EventArgs e)
        {
            _KeHoachVanChuyen = new KeHoachVanChuyen();
            _NhomKeHoach = new NhomKeHoach();
            _DonHang = new DonHang();
            _DiemTrungChuyen = new DiemTrungChuyen();
            _phuongTien = new PhuongTien();
            _taiXe = new TaiXe();
            _chiTietKeHoachVanChuyen = new ChiTietKeHoachVanChuyen();
            _lichSuHanhTrinh = new LichSuHanhTrinh();
            _nhomLichSuHanhTrinh = new NhomLichSuHanhTrinh();
            _nhanVien = new NhanVien();
            _cuocPhi = new ThietLapCuocPhi();
            LoadDonHang();
            LoadTramDau();
            LoadTramCuoi();
            LoadNhanVien();
        }
        void LoadTramDau()
        {
            // Gán DataSource cho LookUpEdit
            cboDiemDau.Properties.DataSource = _DiemTrungChuyen.getAll();

            // Xóa các cột cũ (nếu có)
            cboDiemDau.Properties.Columns.Clear();

            // Thêm các cột mới
            cboDiemDau.Properties.Columns.Add(new LookUpColumnInfo("MaDTC", "Mã trạm"));
            cboDiemDau.Properties.Columns.Add(new LookUpColumnInfo("TenDTC", "Trạm"));


            // Thiết lập cột hiển thị chính
            cboDiemDau.Properties.DisplayMember = "TenDTC";

            cboDiemDau.Properties.ValueMember = "MaDTC";

            // Tùy chỉnh hiển thị trong Popup
            cboDiemDau.Properties.PopupWidth = 400; // Đặt chiều rộng Popup nếu cần
            cboDiemDau.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        void LoadTramCuoi()
        {
            // Gán DataSource cho LookUpEdit
            cboDiemDen.Properties.DataSource = _DiemTrungChuyen.getAll();

            // Xóa các cột cũ (nếu có)
            cboDiemDen.Properties.Columns.Clear();

            // Thêm các cột mới
            cboDiemDen.Properties.Columns.Add(new LookUpColumnInfo("MaDTC", "Mã trạm"));
            cboDiemDen.Properties.Columns.Add(new LookUpColumnInfo("TenDTC", "Trạm"));


            // Thiết lập cột hiển thị chính
            cboDiemDen.Properties.DisplayMember = "TenDTC";

            cboDiemDen.Properties.ValueMember = "MaDTC";

            // Tùy chỉnh hiển thị trong Popup
            cboDiemDen.Properties.PopupWidth = 400; // Đặt chiều rộng Popup nếu cần
            cboDiemDen.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        void LoadKeHoach()
        {
            // Gán DataSource cho LookUpEdit
            cboKeHoachVanChuyen.Properties.DataSource = _NhomKeHoach.getKeHoachDauCuoi(cboDiemDau.EditValue.ToString(),cboDiemDen.EditValue.ToString(),tgsChayXuyenTram.IsOn);

            // Xóa các cột cũ (nếu có)
            cboKeHoachVanChuyen.Properties.Columns.Clear();

            // Thêm các cột mới
            cboKeHoachVanChuyen.Properties.Columns.Add(new LookUpColumnInfo("MaNKH", "Mã kế hoạch"));
            cboKeHoachVanChuyen.Properties.Columns.Add(new LookUpColumnInfo("DiemBatDau", "Điểm bắt đầu"));
            cboKeHoachVanChuyen.Properties.Columns.Add(new LookUpColumnInfo("DiemKetThuc", "Điểm kết thúc"));
            cboKeHoachVanChuyen.Properties.Columns.Add(new LookUpColumnInfo("TongChiPhi", "Tổng chi phí"));

            // Thiết lập cột hiển thị chính
            cboKeHoachVanChuyen.Properties.DisplayMember = "MaNKH";

            cboKeHoachVanChuyen.Properties.ValueMember = "MaNKH";

            // Tùy chỉnh hiển thị trong Popup
            cboKeHoachVanChuyen.Properties.PopupWidth = 400; // Đặt chiều rộng Popup nếu cần
            cboKeHoachVanChuyen.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        void LoadNhanVien()
        {
            // Gán DataSource cho LookUpEdit
            cboNhanVien.Properties.DataSource = _nhanVien.getAll();

            // Xóa các cột cũ (nếu có)
            cboNhanVien.Properties.Columns.Clear();

            // Thêm các cột mới
            cboNhanVien.Properties.Columns.Add(new LookUpColumnInfo("MaNV", "ID"));
            cboNhanVien.Properties.Columns.Add(new LookUpColumnInfo("HoTen", "Họ tên"));
            cboNhanVien.Properties.Columns.Add(new LookUpColumnInfo("ChucVu", "Chức vụ"));

            // Thiết lập cột hiển thị chính
            cboNhanVien.Properties.DisplayMember = "HoTen";

            cboNhanVien.Properties.ValueMember = "MaNV";

            // Tùy chỉnh hiển thị trong Popup
            cboNhanVien.Properties.PopupWidth = 400; // Đặt chiều rộng Popup nếu cần
            cboNhanVien.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        void LoadChiTietKeHoach()
        {
            gcTram.DataSource = _chiTietKeHoachVanChuyen.getAll(_maDonHang);
            gvTram.OptionsBehavior.Editable = false;

        }
        void LoadPhuongTien()
        {
            isFillingDataSource = true;
            // Gán DataSource cho LookUpEdit
            cboPhuongTien.Properties.DataSource = _phuongTien.getAll_LoaiPT(getLoaiXePhuHop(_maDonHang), _maDTC);

            // Xóa các cột cũ (nếu có)
            cboPhuongTien.Properties.Columns.Clear();

            // Thêm các cột mới
            cboPhuongTien.Properties.Columns.Add(new LookUpColumnInfo("MaPT", "ID"));
            cboPhuongTien.Properties.Columns.Add(new LookUpColumnInfo("BienSo", "Biển số"));
            cboPhuongTien.Properties.Columns.Add(new LookUpColumnInfo("TaiTrong", "Tải trọng"));
            cboPhuongTien.Properties.Columns.Add(new LookUpColumnInfo("DungTich", "Dung tích"));

            // Thiết lập cột hiển thị chính
            cboPhuongTien.Properties.DisplayMember = "BienSo";

            cboPhuongTien.Properties.ValueMember = "MaPT";

            // Tùy chỉnh hiển thị trong Popup
            cboPhuongTien.Properties.PopupWidth = 400; // Đặt chiều rộng Popup nếu cần
            cboPhuongTien.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            isFillingDataSource = false;
        }
        public string getLoaiXePhuHop(string maDonHang)
        {
            // Lấy thông tin đơn hàng
            var donHang = _DonHang.getItem(maDonHang);

            if (donHang == null)
            {
                return "Không tìm thấy đơn hàng";
            }

            // Tính thể tích (m³)
            double theTich = donHang.ChieuDai.GetValueOrDefault()
                             * donHang.ChieuRong.GetValueOrDefault()
                             * donHang.ChieuCao.GetValueOrDefault();

            // Tính khối lượng (tấn) từ kg
            double khoiLuongTan = donHang.KhoiLuong.GetValueOrDefault() / 1000.0;
            txtKichThuocDH.Text = "Kích thước : " + donHang.ChieuDai.GetValueOrDefault() + "m X " + donHang.ChieuRong.GetValueOrDefault() + "m X " + donHang.ChieuCao.GetValueOrDefault()+"m";
            txtTrongLuong.Text = "Trọng lượng : " + donHang.KhoiLuong.GetValueOrDefault() + " (KG)";
            chieuDai = donHang.ChieuDai.GetValueOrDefault();
            chieuRong = donHang.ChieuRong.GetValueOrDefault();
            chieuCao = donHang.ChieuCao.GetValueOrDefault();
            trongLuong = donHang.KhoiLuong.GetValueOrDefault();
            // Loại xe phù hợp
            string loaiXe = "";

            if (theTich == 0 || donHang.KhoiLuong == 0)
            {
                MessageBox.Show("Đơn hàng có vấn đề kích thước hoặc khối lượng = 0, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Điều kiện kết hợp thể tích và khối lượng để chọn loại xe
                if (donHang.ChieuDai > 12 || theTich > 70 || donHang.ChieuCao > 3 || donHang.ChieuRong > 2.5 || khoiLuongTan > 25)
                {
                    loaiXe = "Container (40 feet)";
                }
                else if (theTich > 37.4 || khoiLuongTan > 20)
                {
                    loaiXe = "Container (20 feet)";
                }
                else if (theTich > 157.5 || khoiLuongTan > 100)
                {
                    loaiXe = "Xe tải > 100 tấn";
                }
                else if (theTich > 90 || khoiLuongTan > 50)
                {
                    loaiXe = "Xe tải < 100 tấn";
                }
                else if (theTich > 56.25 || khoiLuongTan > 20)
                {
                    loaiXe = "Xe tải > 10 tấn";
                }
                else if (theTich > 24 || khoiLuongTan > 10)
                {
                    loaiXe = "Xe tải < 10 tấn";
                }
                else if (theTich > 5.6 || khoiLuongTan > 1.5)
                {
                    loaiXe = "Xe van";
                }
                else
                {
                    loaiXe = "Xe máy";
                }
            }
            return loaiXe;
        }
        public string getLoaiBangLaiPhuHop(string loaiXe)
        {
            switch (loaiXe)
            {
                case "Xe máy":
                    return "A1"; // Bằng lái A1
                case "Xe van":
                    return "B1"; // Bằng lái B1
                case "Xe tải < 10 tấn":
                    return "B2"; // Bằng lái B2
                case "Xe tải > 10 tấn":
                    return "C"; // Bằng lái C
                case "Xe tải < 100 tấn":
                    return "C"; // Bằng lái C
                case "Xe tải > 100 tấn":
                    return "D"; // Bằng lái D
                case "Container":
                    return "E"; // Bằng lái E
                default:
                    return "Không xác định"; // Trường hợp không khớp
            }
            
        }
        void LoadTaiXe()
        {
               
            // Gán DataSource cho LookUpEdit
            cboTaiXe.Properties.DataSource = _taiXe.getTX_LoaiBangLai(getLoaiBangLaiPhuHop(getLoaiXePhuHop(_maDonHang)), _maDTC);
            // Xóa các cột cũ (nếu có)
            cboTaiXe.Properties.Columns.Clear();

            // Thêm các cột mới
            cboTaiXe.Properties.Columns.Add(new LookUpColumnInfo("MaTX", "ID"));
            cboTaiXe.Properties.Columns.Add(new LookUpColumnInfo("HoTen", "Họ tên"));
            cboTaiXe.Properties.Columns.Add(new LookUpColumnInfo("KinhNghiem", "Kinh nghiệm"));
            cboTaiXe.Properties.Columns.Add(new LookUpColumnInfo("TrangThai", "Trạng thái"));

            // Thiết lập cột hiển thị chính
            cboTaiXe.Properties.DisplayMember = "HoTen";
            cboTaiXe.Properties.ValueMember = "MaTX";

            // Tùy chỉnh hiển thị trong Popup
            cboTaiXe.Properties.PopupWidth = 400; // Đặt chiều rộng Popup nếu cần
            cboTaiXe.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        private void cboKeHoachVanChuyen_EditValueChanged(object sender, EventArgs e)
        {
           
            _maNhomKeHoach = cboKeHoachVanChuyen.EditValue.ToString();
            LoadCacTramTrongKeHoach();
           
        }
        void LoadDonHang()
        {
            gcDanhSach.DataSource = _DonHang.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;

        }
        void LoadCacTramTrongKeHoach()
        {
            gcTram.DataSource = _KeHoachVanChuyen.getAll(_maNhomKeHoach);
            gvTram.OptionsBehavior.Editable = false;
        }
        void LoadData()
        {
            spKhoangCach.EditValue = _NhomKeHoach.getItem(_maNhomKeHoach).TongQuangDuong;
            spNhienLieuTieuHao.EditValue = _NhomKeHoach.getItem(_maNhomKeHoach).TongTieuHaoNhienLieu;
            spThoiGianTrungBinh.EditValue = _NhomKeHoach.getItem(_maNhomKeHoach).TongThoiGian;
            spTongCuocPhi.EditValue = _NhomKeHoach.getItem(_maNhomKeHoach).TongChiPhi;

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maDonHang))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng trước khi xác nhận!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else
            {
                LoadKeHoach();
                txtLoaiXeDeXuat.Text = "Loại xe : " + getLoaiXePhuHop(_maDonHang);
                txtBangLaiDeXuat.Text = "Bằng lái : " + getLoaiBangLaiPhuHop(getLoaiXePhuHop(_maDonHang));

                List<NHOMKEHOACH> danhSach = _NhomKeHoach.getKeHoachDauCuoi(cboDiemDau.EditValue.ToString(), cboDiemDen.EditValue.ToString(),tgsChayXuyenTram.IsOn);

                if (danhSach.Any())
                {
                    // Hiển thị thông báo đầu tiên

                    DialogResult result = MessageBox.Show(
                        "Tìm thấy kế hoạch vận chuyển phù hợp! Bạn có muốn hệ thống tự động đề xuất theo tiêu chí ưu tiên đã chọn không?",
                        "Thông báo!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Kiểm tra lựa chọn của người dùng
                    if (result == DialogResult.Yes)
                    {

                        if (rbtChiPhi.Checked)
                        {
                            var keHoach = _NhomKeHoach.getItemCoGiaTriNhoNhat_ChiPhi(cboDiemDau.EditValue.ToString(), cboDiemDen.EditValue.ToString()).MaNKH;

                            if (keHoach != null)
                            {
                                cboKeHoachVanChuyen.EditValue = keHoach;
                                MessageBox.Show("Kế hoạch tối ưu [CHI PHÍ] nhất đã được đề xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _maNhomKeHoach = cboKeHoachVanChuyen.EditValue.ToString();
                                LoadCacTramTrongKeHoach();
                                LoadData();
                            }
                        }
                        if (rbtQuangDuong.Checked)
                        {
                            var keHoach = _NhomKeHoach.getItemCoGiaTriNhoNhat_QuangDuong(cboDiemDau.EditValue.ToString(), cboDiemDen.EditValue.ToString()).MaNKH;

                            if (keHoach != null)
                            {
                                cboKeHoachVanChuyen.EditValue = keHoach;
                                MessageBox.Show("Kế hoạch tối ưu [QUÃNG ĐƯỜNG] nhất đã được đề xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _maNhomKeHoach = cboKeHoachVanChuyen.EditValue.ToString();
                                LoadCacTramTrongKeHoach();
                                LoadData();
                            }
                        }
                        if (rbtThoiGian.Checked)
                        {
                            var keHoach = _NhomKeHoach.getItemCoGiaTriNhoNhat_ThoiGian(cboDiemDau.EditValue.ToString(), cboDiemDen.EditValue.ToString()).MaNKH;

                            if (keHoach != null)
                            {
                                cboKeHoachVanChuyen.EditValue = keHoach;
                                MessageBox.Show("Kế hoạch tối ưu [THỜI GIAN] nhất đã được đề xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _maNhomKeHoach = cboKeHoachVanChuyen.EditValue.ToString();
                                LoadCacTramTrongKeHoach();
                                LoadData();
                            }
                        }
                        if (rbtTieuHaoNhienLieu.Checked)
                        {
                            var keHoach = _NhomKeHoach.getItemCoGiaTriNhoNhat_NhienLieu(cboDiemDau.EditValue.ToString(), cboDiemDen.EditValue.ToString()).MaNKH;

                            if (keHoach != null)
                            {
                                cboKeHoachVanChuyen.EditValue = keHoach;
                                MessageBox.Show("Kế hoạch tối ưu [NHIÊN LIỆU] nhất đã được đề xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _maNhomKeHoach = cboKeHoachVanChuyen.EditValue.ToString();
                                LoadCacTramTrongKeHoach();
                                LoadData();
                            }
                        }
                       

                    }

                }
                else
                {
                    // Hiển thị thông báo đầu tiên
                    // Hiển thị MessageBox với lựa chọn Yes/No
                    DialogResult result = MessageBox.Show(
                        "Không tìm thấy kế hoạch vận chuyển phù hợp! Bạn vui lòng thiết lập một kế hoạch vận chuyển mới cho đơn hàng này!",
                        "Thông báo!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    

                }
            }
            
        }
        void CapNhatLichSuHanhTrinh()
        {
            var item = _nhomLichSuHanhTrinh.getItem(_maDonHang);
            if (item == null)
            {
                // Nếu không có giá trị, thực hiện thêm bản ghi mới
                NHOMLICHSUHANHTRINH ls = new NHOMLICHSUHANHTRINH();
                ls.MaDH = _maDonHang;
                ls.MaNKH = _maNhomKeHoach;
                ls.MaNV = cboNhanVien.EditValue.ToString();
                ls.TrangThai = "Chờ tài xế xác nhận";
                _nhomLichSuHanhTrinh.Add(ls);
            }
            else
            {
                if (item.TrangThai != "Chờ tài xế xác nhận")
                {
                    MessageBox.Show("Đơn hàng này đang được vận chuyển không thể thay đổi thông tin về nhân viên và kế hoạch vận chuyển!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    NHOMLICHSUHANHTRINH ls = item;
                    ls.MaNKH = _maNhomKeHoach;
                    ls.MaNV = cboNhanVien.EditValue.ToString();
                    _nhomLichSuHanhTrinh.Update(ls);
                }
               
            }

        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNhomKeHoach))
            {
                MessageBox.Show("Mã nhóm kế hoạch không được để trống!",
                                "Thông báo lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(cboNhanVien.EditValue.ToString()))
            {
                MessageBox.Show("Bạn phải chọn nhân nhiên quản lý đơn hàng này!",
                                "Thông báo lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < gvTram.RowCount; i++)
                {
                    var diemDau = gvTram.GetRowCellValue(i, "DiemBatDau")?.ToString();
                    var diemCuoi = gvTram.GetRowCellValue(i, "DiemKetThuc")?.ToString();
                    var maKHVC = gvTram.GetRowCellValue(i, "MaKHVC")?.ToString();

                    if (!string.IsNullOrWhiteSpace(diemDau) &&
                        !string.IsNullOrWhiteSpace(diemCuoi) &&
                        !string.IsNullOrWhiteSpace(maKHVC))
                    {
                        CHITIETKEHOACHVANCHUYEN item = new CHITIETKEHOACHVANCHUYEN
                        {
                            MaNKH = _maNhomKeHoach,
                            MaKHVC = maKHVC,
                            MaDH = _maDonHang,
                            MaTX = "",
                            MaPT = "",
                            DiemBatDau = diemDau,
                            DiemKetThuc = diemCuoi,
                            DaQuaTram = false
                        };

                        // Thêm vào danh sách
                        _chiTietKeHoachVanChuyen.Add(item);
                    }
                    else
                    {
                        // Xác định cụ thể thiếu cột nào
                        string missingColumns = string.Empty;
                        if (string.IsNullOrWhiteSpace(diemDau)) missingColumns += "DiemBatDau ";
                        if (string.IsNullOrWhiteSpace(diemCuoi)) missingColumns += "DiemKetThuc ";
                        if (string.IsNullOrWhiteSpace(maKHVC)) missingColumns += "MaKHVC ";

                        MessageBox.Show($"Dòng {i + 1} thiếu dữ liệu ở các cột: {missingColumns.Trim()}, vui lòng kiểm tra!",
                                        "Cảnh báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }

                LoadChiTietKeHoach();

                //Don hàng đã có kế hoạch vận chuyển
                if (_DonHang.checkItemExists(_maDonHang))
                {
                    DialogResult result = MessageBox.Show(
                       "Đơn hàng này đã có kế hoạch vận chuyển! Bạn muốn thay đổi không?",
                       "Thông báo!",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question
                   );

                    // Kiểm tra lựa chọn của người dùng
                    if (result == DialogResult.Yes)
                    {
                        DONHANG item = _DonHang.getItem(_maDonHang);

                        if (item != null)
                        {
                            item.MaNKH = cboKeHoachVanChuyen.Text;
                            _DonHang.Update(item);
                            LoadDonHang();
                           
                                CapNhatLichSuHanhTrinh();
                            
                            MessageBox.Show($"Đã lập kế hoạch thành công cho đơn hàng [{_maDonHang}]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy đơn hàng tương ứng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                //Đơn hàng chưa có kế hoạch vận chuyển
                else
                {
                    DONHANG item = _DonHang.getItem(_maDonHang);

                    if (item != null)
                    {
                        item.MaNKH = cboKeHoachVanChuyen.Text;
                        _DonHang.Update(item);
                        LoadDonHang();
                       
                            CapNhatLichSuHanhTrinh();
                        
                        MessageBox.Show($"Đã lập kế hoạch thành công cho đơn hàng [{_maDonHang}]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng tương ứng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            _maDonHang = gvDanhSach.GetFocusedRowCellValue("MaDH").ToString();
            _maNhomKeHoach = gvDanhSach.GetFocusedRowCellValue("MaNKH")?.ToString() ?? "";
            if (_maNhomKeHoach != null && _maNhomKeHoach != "")
            {
                tgsChayXuyenTram.IsOn = _NhomKeHoach.getItem(_maNhomKeHoach).XuyenTram.Value;
                spTongCuocPhi.EditValue = _NhomKeHoach.getItem(_maNhomKeHoach).TongChiPhi.Value;
            }
            else
            {
                tgsChayXuyenTram.IsOn = false;
                spTongCuocPhi.EditValue = 0;
            }
            LoadChiTietKeHoach();


        }

        private void btnXacNhanPTTX_Click(object sender, EventArgs e)
        {
            _lichSuHanhTrinh.Delete(_maDonHang);
            for (int i = 0; i < gvTram.RowCount; i++)
            {
                var DiaDiem = gvTram.GetRowCellValue(i, "DiemBatDau")?.ToString();
                var MaTX = gvTram.GetRowCellValue(i, "MaTX")?.ToString();
                var MaPT = gvTram.GetRowCellValue(i, "MaPT")?.ToString();

                if (!string.IsNullOrEmpty(MaTX) || !string.IsNullOrEmpty(MaPT))
                {
                    LICHSUHANHTRINH item = new LICHSUHANHTRINH
                    {
                        MaLS = Function.GenerateAutoCode("LSHT", 5, "MaLS", "LICHSUHANHTRINH"),
                        MaTX = MaTX,
                        MaPT = MaPT,
                        MaDH = _maDonHang,
                        TrangThai = "Chưa đến",
                        DiaDiem = DiaDiem,
                        MaNKH = _maNhomKeHoach
                    };

                    // Thêm vào danh sách
                    _lichSuHanhTrinh.Add(item);
                   
                    if (_nhomLichSuHanhTrinh.getItem(_maDonHang).MaTX == null && i == 0)
                    {
                        NHOMLICHSUHANHTRINH item_n = _nhomLichSuHanhTrinh.getItem(_maDonHang);
                        item_n.MaTX = MaTX;
                        item_n.MaPT = MaPT;
                        _nhomLichSuHanhTrinh.Update(item_n);
                            
                    }
                }
                else
                {
                    MessageBox.Show($"Dòng {i + 1} thiếu dữ liệu, vui lòng kiểm tra! [LICHSUHANHTRINH]", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            MessageBox.Show("Hoàn tất thiết lập hành trình đi đơn cho đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NHOMKEHOACH item_NKH = _NhomKeHoach.getItem(_maNhomKeHoach);
            item_NKH.TongChiPhi = tongTienCuoc;
            _NhomKeHoach.Update(item_NKH);
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
        private void cboTaiXe_EditValueChanged(object sender, EventArgs e)
        {

            //// Lấy ảnh từ GridView và hiển thị lên PictureEdit
            //var anhData = _taiXe.getItem(cboTaiXe.EditValue?.ToString() ?? "").Anh;
            //if (anhData != null)
            //{
            //    byte[] anhBytes = (byte[])anhData;
            //    pAnh.Image = ConvertByteArrayToImage(anhBytes);
            //}
            //else
            //{
            //    if (!_taiXe.getItem(cboTaiXe.EditValue.ToString()).GioiTinh.GetValueOrDefault(false))
            //    {
            //        pAnh.Image = Properties.Resources.avt_default_woman;
            //    }
            //    else
            //    {
            //        pAnh.Image = Properties.Resources.avt_default_man;
            //    }


            //}
        }

        private void cboPhuongTien_EditValueChanged(object sender, EventArgs e)
        {
           
        }
        private void cboPhuongTien_EditValueChanged_1(object sender, EventArgs e)
        {

            if (_phuongTien.getItem(cboPhuongTien.EditValue.ToString()) != null)
            {
                giaTien = _cuocPhi.GetMaxPriceByHighestLevel(_phuongTien.getItem(cboPhuongTien.EditValue.ToString()).LoaiXe, khoangCach, trongLuong, chieuDai, chieuRong, chieuCao);
                spCuocChuyen.EditValue = giaTien;

            }

        }

        private void gvTram_Click(object sender, EventArgs e)
        {
            if (gvTram.RowCount > 0)
            {
                isFillingDataSource = true;
                _maDTC = gvTram.GetFocusedRowCellValue("DiemBatDau")?.ToString() ?? "";
                _maKHVC = gvTram.GetFocusedRowCellValue("MaKHVC")?.ToString() ?? "";
                khoangCach = _KeHoachVanChuyen.getItem(_maKHVC).QuangDuong.Value;
                
                txtLoaiXeDeXuat.Text = "Loại xe : " + getLoaiXePhuHop(_maDonHang);
                txtBangLaiDeXuat.Text = "Bằng lái : " + getLoaiBangLaiPhuHop(getLoaiXePhuHop(_maDonHang));
                txtKhoangCach.Text = "Khoảng cách : " + khoangCach + " (km)";
                LoadTaiXe();
                LoadPhuongTien();
                cboPhuongTien.EditValue = gvTram.GetFocusedRowCellValue("MaPT")?.ToString() ?? "";
                cboTaiXe.EditValue = gvTram.GetFocusedRowCellValue("MaTX")?.ToString() ?? "";
            }

        }

        private void btnGanTXPT_Click(object sender, EventArgs e)
        {
            try
            {
                if (_chiTietKeHoachVanChuyen.getItem(_maKHVC, _maDonHang).DaQuaTram == true)
                {
                    MessageBox.Show("Trạm này đã đi qua không thể thay đổi tài xế hoặc phương tiện!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CHITIETKEHOACHVANCHUYEN item = _chiTietKeHoachVanChuyen.getItem(_maKHVC, _maDonHang);
                string maPT = cboPhuongTien.EditValue?.ToString();
                string maTX = cboTaiXe.EditValue?.ToString();

                if (string.IsNullOrEmpty(maPT) || string.IsNullOrEmpty(maTX))
                {
                    MessageBox.Show("Vui lòng chọn phương tiện và tài xế!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tgsChayXuyenTram.IsOn)
                {
                    List<CHITIETKEHOACHVANCHUYEN> l_item = _chiTietKeHoachVanChuyen.getAll(_maDonHang);
                    if (l_item != null && l_item.Count > 0)
                    {
                        foreach (var chiTiet in l_item)
                        {
                            chiTiet.MaPT = maPT;
                            chiTiet.MaTX = maTX;
                            chiTiet.DaQuaTram = false;
                            _chiTietKeHoachVanChuyen.Update(chiTiet);
                        }
                        LoadChiTietKeHoach();

                        MessageBox.Show($"Đã cập nhật tài xế và phương tiện cho tất cả trạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy các trạm để cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (item != null)
                {
                    item.MaPT = maPT;
                    item.MaTX = maTX;
                    _chiTietKeHoachVanChuyen.Update(item);
                    LoadChiTietKeHoach();

                    MessageBox.Show($"Đã cập nhật tài xế và phương tiện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy trạm tương ứng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                tongTienCuoc += giaTien;
                spTongCuocPhi.EditValue = tongTienCuoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tgsChayXuyenTram_Toggled(object sender, EventArgs e)
        {
            
        }

        private void btnDiDon_Click(object sender, EventArgs e)
        {
            if (_maDonHang == "" )
            {
                MessageBox.Show("Vui lòng chọn đơn hàng trước khi đi đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_lichSuHanhTrinh.getItemDH(_maDonHang).TrangThai == "Mới")
            {
                MessageBox.Show("Đơn hàng đã được đi đơn bạn không thể đi lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Hiển thị MessageBox xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đi đơn không?",      // Nội dung thông báo
                "Xác nhận",                                 // Tiêu đề
                MessageBoxButtons.YesNo,                    // Các nút Yes/No
                MessageBoxIcon.Question                     // Icon câu hỏi
            );

            // Kiểm tra kết quả người dùng chọn
            if (result == DialogResult.Yes)
            {
                // Thực hiện hành động nếu người dùng chọn Yes
                txtDiDonThoiGian.Text = $"Bạn đã đi đơn lúc: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
                NHOMLICHSUHANHTRINH item = _nhomLichSuHanhTrinh.getItem(_maDonHang);
                item.ThoiGianDiDon = DateTime.Now;
                item.ThoiGianXacNhan = DateTime.Now.AddHours(1);
                _nhomLichSuHanhTrinh.Update(item);
                LICHSUHANHTRINH itemLS = _lichSuHanhTrinh.getItemDH(_maDonHang);
                item.TrangThai = "Mới";
                _lichSuHanhTrinh.Update(itemLS);

                // Hiển thị thông báo thành công
                MessageBox.Show("Đi đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Hiển thị thông báo nếu người dùng chọn No
                MessageBox.Show("Hành động đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDiDonThoiGian_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}