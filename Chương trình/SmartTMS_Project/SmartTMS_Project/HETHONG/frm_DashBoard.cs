using BusinessLayer;
using BusinessLayer.NGHIEPVU;
using DataLayer;
using DevExpress.XtraCharts;
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

namespace SmartTMS_Project.HETHONG
{
    public partial class frm_DashBoard : DevExpress.XtraEditors.XtraForm
    {
        public frm_DashBoard()
        {
            InitializeComponent();
        }
        DonHang _donHang;
        PhuongTien _phuongTien;
        private void frm_DashBoard_Load(object sender, EventArgs e)
        {
            _donHang = new DonHang();
            _phuongTien = new PhuongTien();
            LoadPhuongTien();
            LoadColumnChart();
            btnTongSoDon.Text = "TỔNG SỐ ĐƠN : "+_donHang.demSoDonHang_Tong().ToString();
            btnDonMoi.Text = "SỐ ĐƠN MỚI : " + _donHang.demSoDonHang_Moi().ToString();
            btnSoDonThanhCong.Text = "SỐ ĐƠN HOÀN THÀNH : " + _donHang.demSoDonHang_HoanThanh().ToString();
            btnDangGiao.Text = "SỐ ĐƠN ĐANG GIAO : " + _donHang.demSoDonHang_DangGiao().ToString();
        }
        public void LoadColumnChart()
        {
            // Lấy dữ liệu từ hàm getAll_ThongKe
            List<DONHANG> data = _donHang.getAll();

            // Nhóm dữ liệu theo tháng
            var groupedData = Enumerable.Range(1, 12) // Duyệt qua 12 tháng
                .Select(month => new
                {
                    ThangNam = $"{month.ToString("D2")}/{DateTime.Now.Year}", // Tạo chuỗi Tháng/Năm (01/2024, 02/2024,...)
                    TongSoTien = data
                        .Where(d => d.NgayDat.HasValue && d.NgayDat.Value.Month == month) // Lọc theo tháng
                        .Sum(d => d.TongTien) // Tính tổng tiền
                }).ToList();

            // Tạo Series cho biểu đồ cột
            Series series = new Series("Thống kê doanh thu", ViewType.Bar); // Biểu đồ dạng cột
            foreach (var item in groupedData)
            {
                series.Points.Add(new SeriesPoint(item.ThangNam, item.TongSoTien)); // Đảm bảo ThangNam là string
            }

            // Gán Series vào ChartControl
            chartDoanhSo.Series.Clear();
            chartDoanhSo.Series.Add(series);

            // Tùy chỉnh hiển thị
            BarSeriesView view = series.View as BarSeriesView;
            if (view != null)
            {
                view.ColorEach = true; // Tô màu khác nhau cho từng cột
            }

            // Thêm tiêu đề cho ChartControl
            chartDoanhSo.Titles.Clear();
            chartDoanhSo.Titles.Add(new ChartTitle { Text = "Thống kê doanh thu theo tháng" });

            // Hiển thị Tooltip
            chartDoanhSo.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;

            // Hiển thị giá trị trên cột
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            BarSeriesLabel label = series.Label as BarSeriesLabel;
            if (label != null)
            {
                label.TextPattern = "{V:N0} VNĐ"; // Hiển thị giá trị dưới dạng số tiền
            }

            // Tùy chỉnh trục X và Y
            XYDiagram diagram = chartDoanhSo.Diagram as XYDiagram;
            if (diagram != null)
            {
                // Tùy chỉnh trục X
                diagram.AxisX.Title.Text = "Tháng/Năm";
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisX.Label.TextPattern = "{A}"; // Hiển thị chính xác định dạng Tháng/Năm
                diagram.AxisX.QualitativeScaleOptions.AutoGrid = false; // Đảm bảo không tự động gộp nhãn
                diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = true;


                // Tùy chỉnh trục Y
                diagram.AxisY.Title.Text = "Tổng số tiền (VNĐ)";
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.AxisY.Label.TextPattern = "{V:N0}"; // Hiển thị giá trị dạng số tiền
            }

            // Ẩn Legend (nếu không cần)
            chartDoanhSo.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
        }



        public void LoadPieChart(DateTime ngayTu, DateTime ngayDen)
        {
            // Lấy dữ liệu từ hàm getAll_ThongKe
            List<DONHANG> data = _donHang.getAll_ThongKe(ngayTu, ngayDen);

            // Nhóm dữ liệu theo trạng thái hoặc danh mục
            var groupedData = data
                .GroupBy(d => d.TrangThai) // Nhóm theo trạng thái (hoặc thuộc tính khác)
                .Select(g => new
                {
                    TrangThai = g.Key, // Tên nhóm (trạng thái)
                    SoLuong = g.Count() // Số lượng đơn hàng trong nhóm
                }).ToList();

            // Tạo Series cho biểu đồ
            Series series = new Series("Thống kê đơn hàng", ViewType.Pie);
            foreach (var item in groupedData)
            {
                series.Points.Add(new SeriesPoint(item.TrangThai, item.SoLuong));
            }

            // Gán Series vào ChartControl
            chartDonHang.Series.Clear();
            chartDonHang.Series.Add(series);

            // Tùy chỉnh hiển thị
            PieSeriesView view = series.View as PieSeriesView;
            view.Titles.Add(new SeriesTitle { Text = "Thống kê theo trạng thái" });

            // Tùy chỉnh Legend hiển thị tên trạng thái
            chartDonHang.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            series.LegendTextPattern = "{A}"; // Hiển thị tên trạng thái (Argument)

        
        }
        public void LoadPhuongTien()
        {
            // Lấy dữ liệu từ hàm getAll_ThongKe
            List<PHUONGTIEN> data = _phuongTien.getAll();

            // Nhóm dữ liệu theo trạng thái hoặc danh mục
            var groupedData = data
                .GroupBy(d => d.TrangThai) // Nhóm theo trạng thái (hoặc thuộc tính khác)
                .Select(g => new
                {
                    TrangThai = g.Key, // Tên nhóm (trạng thái)
                    SoLuong = g.Count() // Số lượng phương tiện trong nhóm
                }).ToList();

            // Tạo Series cho biểu đồ
            Series series = new Series("Thống kê phương tiện", ViewType.Pie3D); // Chuyển sang Pie3D
            foreach (var item in groupedData)
            {
                series.Points.Add(new SeriesPoint(item.TrangThai, item.SoLuong));
            }

            // Gán Series vào ChartControl
            chartPhuongTien.Series.Clear();
            chartPhuongTien.Series.Add(series);

            // Tùy chỉnh Legend hiển thị tên trạng thái
            chartPhuongTien.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            series.LegendTextPattern = "{A}"; // Hiển thị tên trạng thái (Argument)

            // Tùy chỉnh Pie3D View
            Pie3DSeriesView view = series.View as Pie3DSeriesView;
            if (view != null)
            {
                view.Depth = 30; // Độ sâu của 3D
                view.ExplodedPoints.Add(series.Points[0]); // Nổi bật phần đầu tiên (nếu cần)
                view.ExplodeMode = PieExplodeMode.UsePoints; // Cách "nổ" các phần
                view.Titles.Add(new SeriesTitle { Text = "Thống kê theo trạng thái" });
            }

            // Tùy chỉnh ChartControl
            chartPhuongTien.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;
            chartPhuongTien.Titles.Add(new ChartTitle { Text = "Thống kê phương tiện" });
        }
       
        private void dtNgayDen_EditValueChanged(object sender, EventArgs e)
        {
            LoadPieChart(DateTime.Parse(dtNgayTu.EditValue.ToString()), DateTime.Parse(dtNgayDen.EditValue.ToString()));
            btnTongSoDon.Text = "TỔNG SỐ ĐƠN : " + _donHang.demSoDonHang_Tong(DateTime.Parse(dtNgayTu.EditValue.ToString()), DateTime.Parse(dtNgayDen.EditValue.ToString())).ToString();
            btnDonMoi.Text = "SỐ ĐƠN MỚI : " + _donHang.demSoDonHang_Moi(DateTime.Parse(dtNgayTu.EditValue.ToString()), DateTime.Parse(dtNgayDen.EditValue.ToString())).ToString();
            btnSoDonThanhCong.Text = "SỐ ĐƠN HOÀN THÀNH : " + _donHang.demSoDonHang_HoanThanh(DateTime.Parse(dtNgayTu.EditValue.ToString()), DateTime.Parse(dtNgayDen.EditValue.ToString())).ToString();
            btnDangGiao.Text = "SỐ ĐƠN ĐANG GIAO : " + _donHang.demSoDonHang_DangGiao(DateTime.Parse(dtNgayTu.EditValue.ToString()), DateTime.Parse(dtNgayDen.EditValue.ToString())).ToString();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}