using ModeDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        private ModelDbNhom db = new ModelDbNhom();
        //
        // GET: /admin/Home/
        public ActionResult Index()
        {
            return View();
        }

        
         
        [ChildActionOnly]
        public ActionResult BannerMain()
        {
            TempData["pro"] = db.MatHangs.Count();
            TempData["user"] = db.Users.Count();
            return PartialView();
        }
	}
}