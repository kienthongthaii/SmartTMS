using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_SmartTMS.Areas.ADMIN.Model;

namespace Web_SmartTMS.Areas.ADMIN.Controllers
{
    public class PhuongTienController : Controller
    {
        private Web_SmartTMS_DbContext db = new Web_SmartTMS_DbContext(); // DbContext của ứng dụng

        // GET: ADMIN/PhuongTien
        public ActionResult Index()
        {
            var phuongTienList = db.PHUONGTIEN.ToList(); // Lấy danh sách phương tiện từ database
            return View(phuongTienList);
        }

        // GET: ADMIN/PhuongTien/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Details(string id)
        {
            var phuongTien = db.PHUONGTIEN.FirstOrDefault(pt => pt.MaPT == id);
            if (phuongTien == null)
            {
                return Json(new { success = false, message = "Không tìm thấy phương tiện." }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                success = true,
                data = new
                {
                    BienSo = phuongTien.BienSo,
                    LoaiXe = phuongTien.LoaiXe,
                    HangXe = phuongTien.HangXe,
                    Model = phuongTien.Model,
                    NamSX = phuongTien.NamSX,
                    MauXe = phuongTien.MauXe,
                    KmHienTai = phuongTien.KmHienTai,
                    TrangThai = phuongTien.TrangThai
                }
            }, JsonRequestBehavior.AllowGet);
        }

        // POST: ADMIN/PhuongTien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhuongTienModel model)
        {
            if (ModelState.IsValid)
            {
                var phuongTien = new PHUONGTIEN // Ánh xạ từ model sang entity
                {
                    MaPT = model.MaPT,
                    BienSo = model.BienSo,
                    LoaiXe = model.LoaiXe,
                    HangXe = model.HangXe,
                    Model = model.Model,
                    NamSX = model.NamSX,
                    TaiTrong = model.TaiTrong,
                    DungTich = model.DungTich,
                    MauXe = model.MauXe,
                    SoKhung = model.SoKhung,
                    SoMay = model.SoMay,
                    NgayDangKiem = model.NgayDangKiem,
                    NgayHetHanDK = model.NgayHetHanDK,
                    TrangThai = model.TrangThai,
                    KmHienTai = model.KmHienTai,
                    GhiChu = model.GhiChu,
                    MaBai = model.MaBai,
                    KhongSuDung = model.KhongSuDung,
                    MaTX = model.MaTX,
                    MaDTC = model.MaDTC
                };

                db.PHUONGTIEN.Add(phuongTien); // Thêm vào DbSet
                db.SaveChanges(); // Lưu thay đổi
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ADMIN/PhuongTien/Edit/{id}
        public ActionResult Edit(string id)
        {
            var phuongTien = db.PHUONGTIEN.Find(id); // Tìm phương tiện theo ID
            if (phuongTien == null)
            {
                return HttpNotFound();
            }

            return View(phuongTien);
        }

        // POST: ADMIN/PhuongTien/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PHUONGTIEN phuongTien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phuongTien).State = System.Data.Entity.EntityState.Modified; // Đánh dấu chỉnh sửa
                db.SaveChanges(); // Lưu thay đổi
                return RedirectToAction("Index");
            }

            return View(phuongTien);
        }

        // GET: ADMIN/PhuongTien/Delete/{id}
        public ActionResult Delete(string id)
        {
            var phuongTien = db.PHUONGTIEN.Find(id); // Tìm phương tiện theo ID
            if (phuongTien == null)
            {
                return HttpNotFound();
            }

            return View(phuongTien);
        }

        // POST: ADMIN/PhuongTien/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var phuongTien = db.PHUONGTIEN.Find(id); // Tìm phương tiện theo ID
            if (phuongTien != null)
            {
                db.PHUONGTIEN.Remove(phuongTien); // Xóa khỏi DbSet
                db.SaveChanges(); // Lưu thay đổi
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose(); // Giải phóng tài nguyên
            }
            base.Dispose(disposing);
        }
    }
}
