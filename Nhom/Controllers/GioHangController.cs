using ModeDb.DB;
using ModeDb.EF;
using Nhom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Controllers
{
    public class GioHangController : Controller
    {
        private const string CARTSESSION = "CARTSESSION";
        //
        // GET: /GioHang/

        public ActionResult Index()
        {
            var cart = Session[CARTSESSION];
            var list = new List<CartChoose>();
            if(cart!=null)
            {
                list = (List<CartChoose>)cart;
            }
            return View(list);
        }
        public ActionResult Insert(string pt,long id)
        {
            var cart = Session[CARTSESSION];
            var List = new List<CartChoose>();
            List = (List<CartChoose>)cart;
            foreach(var item in List)
            {
                if(item.mathang.MaMH==id)
                {
                    if(pt.ToString()=="+")
                    {
                        item.soluong += 1;
                    }
                    else
                    {
                        if(item.soluong>1)
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
            Session[CARTSESSION] = List;
            return RedirectToAction("Index", "GioHang");
        }

        


        public ActionResult AddCart(int soluong, long MaMH)
        {
            var cart = Session[CARTSESSION];
            var mathang = new ProductDB().getProductByID(MaMH);
            if(cart!=null)
            {

                var list = (List<CartChoose>)cart;
                if (list.Exists(x => x.mathang.MaMH == MaMH))
                {
                    foreach (var item in list)
                    {
                        if(item.mathang.MaMH==MaMH)
                        {
                            item.soluong += soluong;
                        }
                    }
                }
                else
                {
                    var item = new CartChoose();
                    item.mathang = mathang; 
                    item.soluong = soluong; 
                    list.Add(item);
                }


            }
            else
            {
                var cartchoose = new CartChoose();
                cartchoose.mathang = mathang;
                cartchoose.soluong = soluong;
                 
                var List = new List<CartChoose>();
                List.Add(cartchoose);
                Session[CARTSESSION] = List;
            }
            return RedirectToAction("Index", "GioHang");
        }
        public ActionResult DeleteCartProduct(long MaMH)
        {
            var cart = Session["CARTSESSION"];
            var List = new List<CartChoose>();
            var removecart = new List<CartChoose>();
            List = (List<CartChoose>)cart;
            foreach (var iten in List)
            {
                if (iten.mathang.MaMH == MaMH)
                {
                    removecart.Add(iten);
                }
            }
            foreach (var item in removecart)
            {
                List.Remove(item);
            }
            Session["CARTSESSION"] = List;

            return RedirectToAction("Index", "GioHang");
        }
	}
}