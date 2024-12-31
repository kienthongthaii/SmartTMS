using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_SmartTMS.Areas.ADMIN.Controllers
{
    public class HeaderController : Controller
    {
        // GET: ADMIN/Header
        public ActionResult Index()
        {
            return View();
        }
    }
}