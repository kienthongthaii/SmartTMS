using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SmartTMS.Areas.ADMIN.Model
{
    public class TaiXeModel
    {
        public string MaTX { get; set; } // Mã tài xế
        public string MaTK { get; set; } // Mã tài khoản
        public string MaDV { get; set; } // Mã đơn vị
        public string HoTen { get; set; } // Họ và tên
        public bool GioiTinh { get; set; } // Giới tính (true: Nam, false: Nữ)
        public DateTime NgaySinh { get; set; } // Ngày sinh
        public string SoDT { get; set; } // Số điện thoại
        public string DiaChi { get; set; } // Địa chỉ
        public string Email { get; set; } // Email
        public string CCCD { get; set; } // Chứng minh nhân dân / Căn cước công dân
        public string GhiChu { get; set; } // Ghi chú
        public DateTime NgayVaoLam { get; set; } // Ngày vào làm
        public string BangLai { get; set; } // Bằng lái
        public string LoaiBangLai { get; set; } // Loại bằng lái
        public DateTime NgayHetHanBL { get; set; } // Ngày hết hạn bằng lái
        public float LuongCoBan { get; set; } // Lương cơ bản
        public string TrinhDoChuyenMon { get; set; } // Trình độ chuyên môn
        public string KinhNghiem { get; set; } // Kinh nghiệm
        public string TrangThai { get; set; } // Trạng thái
        public byte[] Anh { get; set; } // Ảnh đại diện
        public string MaDTC { get; set; } // Mã đối tác chủ quản
    }
}