using ModeDb.DB;
using ModeDb.EF;
using Nhom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private ModelDbNhom db = new ModelDbNhom();
       
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]// hiển thị danh sách sản phầm phần trang chủ
        public ActionResult ContentMain(int page=1,int sizePage=10)
        {
            var db = new ProductDB();
            var model = db.getPageListProduct(page, sizePage); 
            return PartialView(model);
        }

        // event clieck on product

        // tim kiếm sản phẩm
        public ActionResult SearchSP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchSP(string name, string hdh, string giathanh)
        {
            name = Request["name"];
            hdh = Request["hdh"];
            giathanh = Request["giathanh"];
            var db = new ProductDB();
             List<MatHang> mayhang = db.ClientSearchPro(name,hdh,giathanh);
             return View(mayhang);
        }
        [ChildActionOnly]
        public ActionResult Shopping()
        {
            var list = new List<CartChoose>();
            var cart = Session["CARTSESSION"];
            if(cart!=null)
            {
                list = (List<CartChoose>)cart;
            }
              
            return PartialView(list);
        }

        public ActionResult XemChiTietSP(long? id)
        {
            var db = new ProductDB();
            MatHang mathang = db.getProductByID(id);
            return View(mathang);
        }

        public ActionResult themSoluong(int id ,string pt)
        {
            var cart = Session["CARTSESSION"];
            var List = new List<CartChoose>();
            List = (List<CartChoose>)cart;
            foreach (var item in List)
            {
                if (item.mathang.MaMH == id)
                {
                    if (pt.ToString() == "+")
                    {
                        item.soluong += 1;
                    }
                    else
                    {
                        if (item.soluong > 1)
                        {
                            item.soluong -= 1;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Số lương sản phẩm phải lớn hơn bằng 1");
                        }

                    }
                }
            }
            Session["CARTSESSION"] = List;
            return RedirectToAction("Index", "Home");
        }
  
	}
}