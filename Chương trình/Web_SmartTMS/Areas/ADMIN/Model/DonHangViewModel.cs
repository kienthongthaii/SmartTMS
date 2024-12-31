using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SmartTMS.Areas.ADMIN.Model
{
    public class DonHangViewModel
    {
        public string MaDH { get; set; }
        public string MaKH { get; set; }
        public DateTime? NgayDat { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public double? TongTien { get; set; }
        public string TrangThai { get; set; }
        public string DiaDiem { get; set; } // Thêm trường này
        public DateTime? ThoiGianXacNhan { get; set; } // Thêm trường này
        public DateTime? ThoiGianNhanDon { get; set; } // Thêm trường này
        public DateTime? ThoiGianGiaoDon { get; set; } // Thêm trường này
        public bool IsOverOneHour { get; set; } // Thêm thuộc tính này
        public bool IsOutOfThoiGianXacNhan { get; set; } // Thêm thuộc tính này
        public bool IsOutOfDeadline { get; set; } // Thêm thuộc tính này
        public string MaTX { get; set; }
        public string ThoiGianXacNhanHienThi { get; set; } // Thêm trường này
        public string ThoiGianNhanDonHienThi { get; set; } // Thêm trường này
        public string ThoiGianGiaoDonHienThi { get; set; } // Thêm trường này
        public string KinhDo { get; set; } // Thêm trường này
        public string ViDo { get; set; } // Thêm trường này
        public string ToaDo { get; set; } // Thêm trường này
        public List<ChiTietDonHangViewModel> ChiTietDonHangs { get; set; }
    }
}