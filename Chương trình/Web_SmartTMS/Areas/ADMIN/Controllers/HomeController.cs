using Microsoft.Ajax.Utilities;
using Model.EF;
using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web.Mvc;
using Web_SmartTMS.Areas.ADMIN.Commons;
using Web_SmartTMS.Areas.ADMIN.Model;
using System.Collections.Generic;
using System.IO;

namespace Web_SmartTMS.Areas.ADMIN.Controllers
{
    public class HomeController : Controller
    {
        private Web_SmartTMS_DbContext db;

        // Constructor
        public HomeController()
        {
            db = new Web_SmartTMS_DbContext(); // Khởi tạo DbContext
        }

        // Trang chủ
        public ActionResult Index()
        {
            return View();
        }

       

        // Đăng xuất
        public ActionResult Logout()
        {
            Session.Clear(); // Xóa toàn bộ session
            return RedirectToAction("Login", "Login", new { area = "ADMIN" });
        }

        // Trang thông tin chính sách và chế độ
        public ActionResult ChinhSachCheDo()
        {
            return View(); // Trả về view "ChinhSachCheDo.cshtml"
        }

        // Lấy họ tên tài khoản từ session
        public string GetHoTen()
        {
            if (Session["USER_SESSION"] is UserLogin userSession)
            {
                var user = db.TAIKHOAN.FirstOrDefault(x => x.MaTK == userSession.MaTK);
                return user?.TenDayDu ?? "Khách";
            }
            return "Khách";
        }

        public ActionResult ThongTinCaNhan()
        {
            var maTK = Session["MaTK"] as string;
            if (string.IsNullOrEmpty(maTK))
            {
                TempData["Error"] = "Vui lòng đăng nhập.";
                return RedirectToAction("Index", "Login", new { area = "ADMIN" });
            }

            // Lấy thông tin tài xế từ cơ sở dữ liệu
            var taiXe = db.TAIXE.FirstOrDefault(tx => tx.MaTK == maTK);

            if (taiXe == null)
            {
                TempData["Error"] = "Không tìm thấy thông tin tài xế.";
                return RedirectToAction("Index", "Home", new { area = "ADMIN" });
            }

            ViewBag.TaiXe = taiXe; // Gán tài xế vào ViewBag
            return View();
        }


        [HttpPost]
        public JsonResult SendFeedbackWithAttachment(string title, string content)
        {
            try
            {
                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
                {
                    return Json(new { success = false, message = "Tiêu đề và nội dung không được để trống." });
                }

                // Xử lý file đính kèm
                var attachments = new List<Attachment>();
                if (Request.Files != null && Request.Files.Count > 0)
                {
                    foreach (string fileName in Request.Files)
                    {
                        var file = Request.Files[fileName];
                        if (file != null && file.ContentLength > 0)
                        {
                            var stream = file.InputStream;
                            var attachment = new Attachment(stream, file.FileName);
                            attachments.Add(attachment);
                        }
                    }
                }

                // Gửi email
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("2121005132@sv.ufm.edu.vn", "Tvy39278");
                    smtpClient.EnableSsl = true;

                    var mail = new MailMessage
                    {
                        From = new MailAddress("2121005132@sv.ufm.edu.vn", "SmartTMS"),
                        Subject = $"Phản hồi từ hệ thống: {title}",
                        Body = $"Tiêu đề: {title}\n\nNội dung: {content}",
                        IsBodyHtml = false,
                    };

                    mail.To.Add("nguyentrungkien.forwork@gmail.com");

                    // Thêm các file đính kèm
                    foreach (var attachment in attachments)
                    {
                        mail.Attachments.Add(attachment);
                    }

                    smtpClient.Send(mail);
                }

                return Json(new { success = true, message = "Phản hồi đã được gửi thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Lỗi khi gửi phản hồi: " + ex.Message });
            }
        }


        [HttpPost]
        public JsonResult LockAccount()
        {
            try
            {
                var userSession = Session["USER_SESSION"] as UserLogin;
                if (userSession == null)
                {
                    return Json(new { success = false, message = "Vui lòng đăng nhập lại." });
                }

                var user = db.TAIKHOAN.FirstOrDefault(u => u.MaTK == userSession.MaTK);
                if (user != null)
                {
                    user.KhoaTaiKhoan =true; // Cập nhật trạng thái tài khoản thành "Khóa"
                    db.SaveChanges();

                    // Xóa session sau khi khóa tài khoản
                    Session.Clear();

                    return Json(new { success = true });
                }

                return Json(new { success = false, message = "Không tìm thấy tài khoản." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Lỗi khi khóa tài khoản: " + ex.Message });
            }
        }




        // Dispose DbContext để tránh rò rỉ tài nguyên
        protected override void Dispose(bool disposing)
        {
            if (disposing && db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
