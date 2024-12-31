using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SmartTMS.Areas.ADMIN.Model
{
    public class LichSuHanhTrinhModel
    {
        public string MaLS { get; set; }  // Mã lịch sử hành trình
        public string MaTX { get; set; }  // Mã tài xế
        public string MaPT { get; set; }  // Mã phương tiện
        public string MaDH { get; set; }  // Mã đơn hàng
        public DateTime? ThoiGian { get; set; }  // Thời gian
        public float? ToaDoX { get; set; }  // Tọa độ X
        public float? ToaDoY { get; set; }  // Tọa độ Y
        public float? VanToc { get; set; }  // Vận tốc
        public float? NhienLieuConLai { get; set; }  // Nhiên liệu còn lại
        public string TrangThai { get; set; }  // Trạng thái
        public string DiaDiem { get; set; }  // Địa điểm
        public string GhiChu { get; set; }  // Ghi chú
        public string MaNKH { get; set; }  // Mã nhóm kế hoạch
        public bool? DaQuaTram { get; set; }  // Đã qua trạm
        public DateTime? ThoiGianNhanDon { get; set; }  // Thời gian nhận đơn
        public DateTime? ThoiGianHoanThanh { get; set; }  // Thời gian hoàn thành

    }
}