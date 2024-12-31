using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_SmartTMS.Areas.ADMIN.Commons;
using Web_SmartTMS.Areas.ADMIN.Model;

namespace Web_SmartTMS.Areas.ADMIN.Controllers
{
    public class DonHangController : Controller
    {
        // GET: ADMIN/DonHang
        // Action mặc định
        public ActionResult Index()
        {
            return View();
        }
        private readonly Web_SmartTMS_DbContext _db = new Web_SmartTMS_DbContext();


        public ActionResult DonHang()
        {
            var userSession = Session[Function.USER_SESSION] as UserLogin;
            if (userSession == null)
            {
                return RedirectToAction("Index", "Login"); // Nếu không có session, chuyển về trang login
            }

            // Lấy MaTK từ session
            string maTK = userSession.MaTK;
            string selectedMaTX = _db.TAIXE.FirstOrDefault(x => x.MaTK == maTK).MaTX;

            if (string.IsNullOrEmpty(selectedMaTX))
            {
                // Xử lý nếu MaTX trong session không tồn tại
                return RedirectToAction("Login", "User"); // Điều hướng về trang đăng nhập hoặc trang khác
            }

            // Lấy danh sách đơn hàng dựa trên MaTX từ Session và trạng thái "Mới"
            var donHangs = (from dh in _db.DONHANG
                            join lsdh in _db.LICHSUHANHTRINH on dh.MaDH equals lsdh.MaDH
                            join tram in _db.DIEMTRUNGCHUYEN on lsdh.DiaDiem equals tram.MaDTC
                            where lsdh.MaTX == selectedMaTX && (lsdh.TrangThai == "Mới" || lsdh.TrangThai == "Đang giao")
                            select new
                            {
                                dh.MaDH,
                                dh.MaKH,
                                dh.NgayDat,
                                dh.TongTien,
                                lsdh.TrangThai,
                                tram.KinhDo,
                                tram.ViDo,
                                DiaDiem = _db.LICHSUHANHTRINH
                                    .Where(l => l.MaDH == dh.MaDH)
                                    .Select(l => l.DiaDiem)
                                    .FirstOrDefault(),
                                ThoiGianXacNhan = _db.NHOMLICHSUHANHTRINH
                                    .Where(l => l.MaDH == dh.MaDH)
                                    .Select(l => l.ThoiGianXacNhan)
                                    .FirstOrDefault(),
                                ThoiGianNhanDon = _db.LICHSUHANHTRINH
                                    .Where(l => l.MaDH == dh.MaDH)
                                    .Select(l => l.ThoiGianNhanDon)
                                    .FirstOrDefault(),
                                ThoiGianHoanThanh = _db.LICHSUHANHTRINH
                                    .Where(l => l.MaDH == dh.MaDH)
                                    .Select(l => l.ThoiGianHoanThanh)
                                    .FirstOrDefault(),
                                ChiTietDonHangs = _db.CHITIETDONHANG
                                    .Where(ct => ct.MaDH == dh.MaDH)
                                    .Select(ct => new
                                    {
                                        MaCTDH = ct.MaCTDH,
                                        TenHangHoa = ct.TenHangHoa,
                                        SoLuong = ct.SoLuong,
                                        KhoiLuong = ct.KhoiLuong,
                                        GiaTri = ct.GiaTri,
                                        TrangThai = ct.TrangThai
                                    }).ToList(),
                                MaTX = lsdh.MaTX
                            }).ToList()
                            .Select(d => new DonHangViewModel
                            {
                                MaDH = d.MaDH,
                                MaKH = d.MaKH,
                                NgayDat = d.NgayDat,
                                TongTien = d.TongTien,
                                TrangThai = d.TrangThai,
                                DiaDiem = d.DiaDiem ?? "Chưa có",
                                ToaDo = d.ViDo + "," + d.KinhDo,

                                ThoiGianXacNhanHienThi = d.ThoiGianXacNhan.HasValue
                                    ? d.ThoiGianXacNhan.Value.ToString("dd/MM/yyyy HH:mm:ss")
                                    : "Chưa được đi đơn",
                                IsOutOfThoiGianXacNhan = d.ThoiGianXacNhan.HasValue
                                    ? d.ThoiGianXacNhan.Value < DateTime.Now
                                    : false,
                                ThoiGianNhanDonHienThi = d.ThoiGianNhanDon.HasValue
                                    ? d.ThoiGianNhanDon.Value.ToString("dd/MM/yyyy HH:mm:ss")
                                    : "Hàng chưa đến trạm",
                                IsOverOneHour = d.ThoiGianNhanDon.HasValue
                                    ? d.ThoiGianNhanDon.Value > d.ThoiGianXacNhan
                                    : false,
                                ThoiGianGiaoDonHienThi = d.ThoiGianHoanThanh.HasValue
                                    ? d.ThoiGianHoanThanh.Value.ToString("dd/MM/yyyy HH:mm:ss")
                                    : "Hàng chưa đến trạm",
                                IsOutOfDeadline = d.ThoiGianHoanThanh.HasValue
                                    ? d.ThoiGianHoanThanh.Value < DateTime.Now
                                    : false,
                                MaTX = d.MaTX,
                                ChiTietDonHangs = d.ChiTietDonHangs.Select(ct => new ChiTietDonHangViewModel
                                {
                                    MaCTDH = ct.MaCTDH,
                                    TenHangHoa = ct.TenHangHoa,
                                    SoLuong = ct.SoLuong,
                                    KhoiLuong = ct.KhoiLuong,
                                    GiaTri = ct.GiaTri,
                                    TrangThai = ct.TrangThai
                                }).ToList()
                            }).ToList();

            return View(donHangs);
        }




        [HttpPost]
        public JsonResult NhanDon(string maDH)
        {
            var userSession = Session[Function.USER_SESSION] as UserLogin;
            // Lấy MaTX từ session
            string maTK = userSession.MaTK;
            string selectedMaTX = _db.TAIXE.FirstOrDefault(h => h.MaTK == maTK)?.MaTX;
            try
            {
                var donhang = _db.DONHANG.FirstOrDefault(d => d.MaDH == maDH);
                if (donhang != null)
                {
                    donhang.TrangThai = "Đang giao"; // Cập nhật trạng thái đơn hàng

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _db.SaveChanges();
                }
                var nhomLS = _db.NHOMLICHSUHANHTRINH.FirstOrDefault(d => d.MaDH == maDH);
                if (nhomLS != null)
                {
                    nhomLS.TrangThai = "Đang giao"; // Cập nhật trạng thái đơn hàng

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _db.SaveChanges();
                }

                // Tìm đơn hàng theo mã đơn hàng
                var lsht = _db.LICHSUHANHTRINH.FirstOrDefault(d => d.MaDH == maDH && d.MaTX == selectedMaTX);
                
                if (lsht != null)
                {
                    // Cập nhật thời gian nhận đơn và thời gian hoàn thành
                    lsht.ThoiGianNhanDon = DateTime.Now;
                    lsht.ThoiGianHoanThanh = DateTime.Now.AddHours(3); // Hoàn thành sau 3 giờ
                    lsht.TrangThai = "Đang giao"; // Cập nhật trạng thái đơn hàng

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _db.SaveChanges();

                    return Json(new { success = true, message = "Nhận đơn thành công!" });
                }
                return Json(new { success = false, message = "Đơn hàng không tồn tại!" });
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DaGiaoHang(string maDH)
        {
            var userSession = Session[Function.USER_SESSION] as UserLogin;
            // Lấy MaTX từ session
            string maTK = userSession.MaTK;
            string selectedMaTX = _db.TAIXE.FirstOrDefault(h => h.MaTK == maTK)?.MaTX;

            if (string.IsNullOrEmpty(selectedMaTX))
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin tài xế!" });
            }

            try
            {
                // Lấy danh sách LICHSUHANHTRINH theo MaDH, sắp xếp theo MaLS tăng dần
                var lichSuHanhTrinhs = _db.LICHSUHANHTRINH
                    .Where(d => d.MaDH == maDH)
                    .OrderBy(l => l.MaLS)
                    .ToList();

                // Kiểm tra nếu không tìm thấy lịch sử hành trình
                if (!lichSuHanhTrinhs.Any())
                {
                    return Json(new { success = false, message = "Không tìm thấy lịch sử hành trình cho đơn hàng này!" });
                }

                // Lấy dòng hiện tại của tài xế
                var currentLS = lichSuHanhTrinhs.FirstOrDefault(x => x.MaTX == selectedMaTX);

                if (currentLS == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy dòng hiện tại của tài xế!" });
                }

                // Kiểm tra nếu dòng hiện tại là MaLS lớn nhất
                var maxMaLS = lichSuHanhTrinhs.Last();
                if (currentLS.MaLS == maxMaLS.MaLS)
                {
                    // Nếu là MaLS lớn nhất, cập nhật trạng thái thành "Hoàn thành"
                    var nhomLS = _db.NHOMLICHSUHANHTRINH.FirstOrDefault(x => x.MaDH == maDH);
                    var donHang = _db.DONHANG.FirstOrDefault(x => x.MaDH == maDH);
                    if (nhomLS != null)
                    {
                        nhomLS.TrangThai = "Hoàn thành";
                        donHang.TrangThai = "Hoàn thành";
                        currentLS.TrangThai = "Hoàn thành";
                        currentLS.ThoiGian = DateTime.Now;
                        currentLS.DaQuaTram = true;
                        _db.SaveChanges();
                       
                        return Json(new { success = true, message = "Giao hàng thành công!" });
                    }
                }
                else
                {
                    // Nếu không phải MaLS lớn nhất, lấy dòng kế tiếp
                    var nextLSIndex = lichSuHanhTrinhs.IndexOf(currentLS) + 1;
                    if (nextLSIndex < lichSuHanhTrinhs.Count)
                    {
                        var nextLS = lichSuHanhTrinhs[nextLSIndex];

                        // Cập nhật thời gian nhận đơn và thời gian xác nhận cho dòng kế tiếp
                        nextLS.TrangThai = "Mới";
                        currentLS.TrangThai = "Hoàn thành";
                        currentLS.ThoiGian = DateTime.Now;
                        currentLS.DaQuaTram = true;
                        _db.SaveChanges();

                        return Json(new { success = true, message = "Giao hàng thành công!" });
                    }
                }
                // Nếu là MaLS lớn nhất, cập nhật trạng thái thành "Hoàn thành"
                

                return Json(new { success = false, message = "Không thể xác định dòng kế tiếp!" });
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new { success = false, message = ex.Message });
            }
        }




    }
}
