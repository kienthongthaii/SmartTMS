using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SmartTMS.Areas.ADMIN.Model
{
    public class ChiTietDonHangViewModel
    {
        public string MaCTDH { get; set; }
        public string TenHangHoa { get; set; }
        public int? SoLuong { get; set; }
        public double? KhoiLuong { get; set; }
        public double? GiaTri { get; set; }
        public string TrangThai { get; set; }
    }
}