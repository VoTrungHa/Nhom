using ModeDb.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ContentMain(int page=1,int sizePage=10)
        {
            var db = new ProductDB();
            var model = db.getPageListProduct(page, sizePage); 
            return PartialView(model);
        }

	}
}