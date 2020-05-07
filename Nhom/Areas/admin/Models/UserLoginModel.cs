using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nhom.Areas.admin.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Mời nhập Email !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mời nhập passWord! !")]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}