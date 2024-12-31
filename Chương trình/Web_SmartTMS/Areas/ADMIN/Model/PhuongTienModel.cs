using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SmartTMS.Areas.ADMIN.Model
{
    public class PhuongTienModel
    {
        public string MaPT { get; set; }
        public string BienSo { get; set; }
        public string LoaiXe { get; set; }
        public string HangXe { get; set; }
        public string Model { get; set; }
        public int? NamSX { get; set; }
        public float? TaiTrong { get; set; }
        public float? DungTich { get; set; }
        public string MauXe { get; set; }
        public string SoKhung { get; set; }
        public string SoMay { get; set; }
        public DateTime? NgayDangKiem { get; set; }
        public DateTime? NgayHetHanDK { get; set; }
        public string TrangThai { get; set; }
        public float? KmHienTai { get; set; }
        public string GhiChu { get; set; }
        public string MaBai { get; set; }
        public bool? KhongSuDung { get; set; }
        public string MaTX { get; set; }
        public string MaDTC { get; set; }
    }
}