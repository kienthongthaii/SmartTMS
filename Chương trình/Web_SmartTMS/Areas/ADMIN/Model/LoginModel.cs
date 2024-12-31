using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_SmartTMS.Areas.ADMIN.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Vui lòng nhập tên đăng nhập!")]
        public string TenDangNhap {  get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}