using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_SmartTMS.Areas.ADMIN.Commons;

namespace Web_SmartTMS.Areas.ADMIN.Controllers
{
    public class BangLuongController : Controller
    {
        private Web_SmartTMS_DbContext db = new Web_SmartTMS_DbContext(); // DbContext của bạn
        
        [HttpGet]
        public ActionResult Index(string maTK)
        {
            if (string.IsNullOrEmpty(maTK))
            {
                maTK = Session["USER_SESSION"] is UserLogin session ? session.MaTK : null;
                if (string.IsNullOrEmpty(maTK))
                {
                    TempData["Error"] = "Bạn cần đăng nhập để xem bảng lương.";
                    return RedirectToAction("Login", "Home", new { area = "ADMIN" });
                }
            }
            string MaTX = db.TAIXE.FirstOrDefault(x => x.MaTK == maTK).MaTX;
            var bangLuong = db.BANGLUONG.Where(bl => bl.MaTX == MaTX).ToList();
            return View(bangLuong);
        }

    }
}