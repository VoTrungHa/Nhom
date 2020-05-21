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

        public ActionResult XemChiTietSP( )
        {
           
            return View();

            
        }

        // tim kiếm sản phẩm
        public ActionResult SearchSP()
        {
            return View();
        }
        // thanh toán sản phẩm.
        public ActionResult ThanhToan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThanhToan(List<DonHang> donhangs)
        {
            return View();
        }

	}
}