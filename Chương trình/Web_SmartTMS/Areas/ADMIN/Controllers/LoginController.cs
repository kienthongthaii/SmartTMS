using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_SmartTMS.Areas.ADMIN.Commons;
using Web_SmartTMS.Areas.ADMIN.Model;

namespace Web_SmartTMS.Areas.ADMIN.Controllers
{
    public class LoginController : Controller
    {
        // GET: ADMIN/Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new USER_DAO();
                var result = dao.Login(model.TenDangNhap, model.Password);
                if (result == 1)
                {
                    var user = dao.getItem(model.TenDangNhap); // Lấy thông tin người dùng
                    var session = new UserLogin
                    {
                        TenDayDu = user.TenDayDu,
                        TenDangNhap = user.TenDangNhap,
                        MatKhau = user.MatKhau,
                        MaTK = user.MaTK // Lưu mã tài khoản vào session
                    };

                    // Lưu vào Session
                    Session.Add(Function.USER_SESSION, session); // Lưu toàn bộ thông tin người dùng
                    Session["MaTK"] = user.MaTK; // Lưu riêng MaTK vào session để dùng cho các mục đích khác

                    // Chuyển hướng sau khi đăng nhập thành công
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 3)
                {
                    ModelState.AddModelError("", "Tài khoản đã bị khóa!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng vui lòng kiểm tra lại!");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
            }
            return View("Index");
        }


    }
}