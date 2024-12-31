using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

namespace SmartTMS_Project.REPORT
{
    public partial class BaoCaoDoanhThu : DevExpress.XtraReports.UI.XtraReport
    {
        public BaoCaoDoanhThu()
        {
            InitializeComponent();
        }
        public void SetDataSource(DataTable dataSource)
        {
            this.DataSource = dataSource;

            // Gắn DataTable vào DataSource của báo cáo
            MaDH.DataBindings.Add("Text", dataSource, "MaHD");
            NgayDat.DataBindings.Add("Text", dataSource, "NgayDat", "{0:dd/MM/yyyy}"); // Định dạng ngày
            NgayHoanThanh.DataBindings.Add("Text", dataSource, "NgayHoanThanh", "{0:dd/MM/yyyy}"); // Định dạng ngày
            PhiVanChuyen.DataBindings.Add("Text", dataSource, "PhiVanChuyen", "{0:N0} VND"); // Định dạng tiền
            PhiPhatSinh.DataBindings.Add("Text", dataSource, "PhiPhatSinh", "{0:N0} VND"); // Định dạng tiền
            GiaTri.DataBindings.Add("Text", dataSource, "TongTienHang", "{0:N0} VND"); // Định dạng tiền
            TongCong.DataBindings.Add("Text", dataSource, "TongTien", "{0:N0} VND"); // Định dạng tiền
                                                                                     // Tính tổng giá trị TongTien
            double tongTien = dataSource.AsEnumerable().Sum(row => row.Field<double?>("TongTien") ?? 0);
            TongTienCuoi.Text = string.Format("{0:N0} VND", tongTien);

            // Tính tổng giá trị TongTienHang
            double tongGiaTri = dataSource.AsEnumerable().Sum(row => row.Field<double?>("TongTienHang") ?? 0);
            TongGiaTri.Text = string.Format("{0:N0} VND", tongGiaTri);
            // Hiển thị ngày giờ hiện tại
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy"); // Ngày tháng năm
            txtThoiGian.Text = DateTime.Now.ToString("HH:mm:ss"); // Giờ phút giây
        }


    }
}
