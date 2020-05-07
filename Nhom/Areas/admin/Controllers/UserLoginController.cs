using ModeDb.DB;
using Nhom.Areas.admin.Models;
using Nhom.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Areas.admin.Controllers
{
    public class UserLoginController : Controller
    {
        //
        // GET: /admin/UserLogin/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLoginModel model)
        {
            if(ModelState.IsValid)
            {
                var db = new UserDb();
                var result=db.LoginUser(model.Email,Encryptor.MD5Hash(model.PassWord));
                if(result>0)
                {
                    var user = db.GetUserByEmail(model.Email);
                    var userSesstion = new UserSection();// khỏi tạo lớp để theeo sesstion
                    userSesstion.email = user.Email;// đưa email vào user section 
                    Session.Add(CommonContact.USER_SESSION, userSesstion);// lưu userSesstion vào
                    
                    if(result==1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         
                    }
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài Khoản Không tồn tại !");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài Khoản đang bị khóa !");
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng !");
                } 
            }


            return View("Index");
        }


	}
}