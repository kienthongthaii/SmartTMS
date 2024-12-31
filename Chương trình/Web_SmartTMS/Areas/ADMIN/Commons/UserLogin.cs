using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SmartTMS.Areas.ADMIN.Commons
{
    [Serializable]
    public class UserLogin
    {
        
        public string MaTK {  get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string TenDayDu { get; set; }
        public string LoaiTaiKhoan { get; set; }
        public bool KhoaTaiKhoan { get; set; }
    }
}