using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_SmartTMS.Areas.ADMIN.Controllers
{
    public class NhienLieuController : Controller
    {
        // GET: ADMIN/NhienLieu
        public ActionResult Index()
        {
            var dao = new NHIENLIEU_DAO();
            var model = dao.getList(); // Lấy danh sách phiếu nhiên liệu
            return View("DanhSachPhieuNhienLieu", model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            // Tạo dropdown danh sách phương tiện và tài xế
            var phuongTienDao = new PHUONGTIEN_DAO();
            var taiXeDao = new TAIXE_DAO();

            ViewBag.MaPT = new SelectList(phuongTienDao.getList(), "MaPT", "BienSo");
            ViewBag.MaTX = new SelectList(taiXeDao.getList(), "MaTX", "HoTen");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NHIENLIEU nhienLieu)
        {
            if (ModelState.IsValid)
            {
                var dao = new NHIENLIEU_DAO();

                // Tạo mã tự động
                nhienLieu.MaNL = dao.GenerateMaNL();

                // Kiểm tra khóa ngoại có tồn tại
                var phuongTienDao = new PHUONGTIEN_DAO();
                var taiXeDao = new TAIXE_DAO();

                if (!phuongTienDao.Exists(nhienLieu.MaPT))
                {
                    ModelState.AddModelError("", "Phương tiện không tồn tại!");
                    return View(nhienLieu);
                }

                if (!taiXeDao.Exists(nhienLieu.MaTX))
                {
                    ModelState.AddModelError("", "Tài xế không tồn tại!");
                    return View(nhienLieu);
                }

                var item = dao.Add(nhienLieu);
                if (item != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm phiếu nhiên liệu không thành công!");
                }
            }

            // Nếu có lỗi, cần load lại danh sách phương tiện và tài xế
            var phuongTienReloadDao = new PHUONGTIEN_DAO();
            var taiXeReloadDao = new TAIXE_DAO();

            ViewBag.MaPT = new SelectList(phuongTienReloadDao.getList(), "MaPT", "BienSo");
            ViewBag.MaTX = new SelectList(taiXeReloadDao.getList(), "MaTX", "HoTen");

            return View(nhienLieu);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new NHIENLIEU_DAO();
            var model = dao.getItem(id); // Lấy thông tin phiếu nhiên liệu theo ID
            if (model == null)
            {
                return HttpNotFound();
            }

            // Tạo SelectList cho tài xế và phương tiện, với giá trị đang được chọn
            ViewBag.MaTX = new SelectList(new TAIXE_DAO().getList(), "MaTX", "HoTen", model.MaTX);
            ViewBag.MaPT = new SelectList(new PHUONGTIEN_DAO().getList(), "MaPT", "BienSo", model.MaPT);

            return View("Create", model); // Sử dụng lại View Create để hiển thị thông tin
        }


    }
}
