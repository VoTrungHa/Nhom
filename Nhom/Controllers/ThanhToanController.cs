using Nhom.Areas.admin.Controllers;
using Nhom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Controllers
{
    public class ThanhToanController : BaseController
    {
        //
        // GET: /ThanhToan/
        public ActionResult Index()
        {
            var cart = Session["CARTSESSION"];
            var list = new List<CartChoose>();
            if(cart!=null)
            {
                list = (List<CartChoose>)cart;
            }
            return View(list);
        }
	}
}