using ModeDb.EF;
using Nhom.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Areas.admin.Controllers
{
    public class HomeController : BaseController
    {
        private ModelDbNhom db = new ModelDbNhom();
        //
        // GET: /admin/Home/
        public ActionResult Index()
        {
            return View();
        }

        // xem sản phẩm 
         
        [ChildActionOnly]
        public ActionResult BannerMain()
        {
            TempData["pro"] = db.MatHangs.Count();
            TempData["user"] = db.Users.Count();
            return PartialView();
        }
	}
}