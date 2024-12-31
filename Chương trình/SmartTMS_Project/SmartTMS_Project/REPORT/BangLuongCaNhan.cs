using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace SmartTMS_Project.REPORT
{
    public partial class BangLuongCaNhan : DevExpress.XtraReports.UI.XtraReport
    {
        public BangLuongCaNhan()
        {
            InitializeComponent();
        }
        public void SetDataSource(DataTable dataSource)
        {
            this.DataSource = dataSource;

            // Gắn các cột từ DataTable vào các field trong báo cáo
            MaTX.DataBindings.Add("Text", null, "MaTX");
            HoTen.DataBindings.Add("Text", null, "HoTen");
            DonVi.DataBindings.Add("Text", null, "MaDonVi");
            LuongCoBan.DataBindings.Add("Text", null, "LuongCoBan", "{0:N0} ₫"); // Định dạng tiền VNĐ
            TongDon.DataBindings.Add("Text", null, "SoDonGiao");
            GiaoTre.DataBindings.Add("Text", null, "SoDonTre");
            NhanTre.DataBindings.Add("Text", null, "SoDonNhanTre");
            HoaHong.DataBindings.Add("Text", null, "LuongDon", "{0:N0} ₫"); // Định dạng tiền VNĐ
            KhauTru.DataBindings.Add("Text", null, "KhauTru", "{0:N0} ₫"); // Định dạng tiền VNĐ
            ThucNhan.DataBindings.Add("Text", null, "ThucNhan", "{0:N0} ₫"); // Định dạng tiền VNĐ
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy"); // Ngày tháng năm
            txtThoiGian.Text = DateTime.Now.ToString("HH:mm:ss"); // Giờ phút giây
        }




    }

}

