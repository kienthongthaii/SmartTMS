using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SmartTMS.Areas.ADMIN.Model
{
    public class DonHangListViewModel
    {
        public List<DonHangViewModel> DonHangMoi { get; set; }
        public List<DonHangViewModel> DonHangDangGiao { get; set; }
        public List<DonHangViewModel> DonHangDaGiao { get; set; }
    }

}