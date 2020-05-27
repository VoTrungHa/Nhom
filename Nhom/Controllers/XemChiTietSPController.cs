using ModeDb.DB;
using ModeDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Controllers
{
    public class XemChiTietSPController : Controller
    {
        
        //
        // GET: /XemChiTietSP/
        public ActionResult Index(long? id)
        { 
            var db=new ProductDB();
            MatHang mathang = db.getProductByID(id);
            return View(mathang);
            
        }
        [ChildActionOnly]
        public ActionResult Shopping()
        {

            return PartialView();
        }
	}
}