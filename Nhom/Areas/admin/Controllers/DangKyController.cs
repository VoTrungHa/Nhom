﻿using ModeDb.DB;
using ModeDb.EF;
using Nhom.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Areas.admin.Controllers
{
    public class DangKyController : Controller
    {
        //
        // GET: /admin/DangKy/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
       public ActionResult Index(User model)
        {
            if (ModelState.IsValid)
            {
                var db = new UserDb();
                var result = db.GetUserByEmail(model.Email);
                if (model.Status == true)
                {
                    if (result == null)
                    {
                        var password = Encryptor.MD5Hash(model.PassWord);// mã hóa pass
                        model.PassWord = password;
                        db.InsertUser(model);
                        return RedirectToAction("Index", "UserLogin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email Đã Tồn Tại !");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Hãy Nhấn xác nhận đăng ký để thành công !");
                }

            }
            return View();
        }
	}
}