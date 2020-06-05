using ModeDb.DB;
using ModeDb.EF;
using Nhom.Areas.admin.Controllers;
using Nhom.Common;
using Nhom.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom.Controllers
{
    public class ThanhToanController : BaseController
    {
        private ModelDbNhom db = new ModelDbNhom();
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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(KhachHang cus,DonHang dh)
        {
            if(ModelState.IsValid)
            {
                var user = Session["USER_SESSION"];
                double tongtien = 0;
                // laay danh sach sanr pham dc chon
                var cart = (List<CartChoose>)Session["CARTSESSION"];
                var list = new List<CartChoose>();
                list = cart;
                if(user!=null && list!=null)
                {
                    foreach (var item in list)// tính tổng tiền của đơn hàng
                    {
                        tongtien = tongtien + (double)item.mathang.GiaThanh.GetValueOrDefault(0) * (double)item.soluong;


                    }

                    var Idcus = (UserSection)Session["USER_SESSION"];
                    cus.Email = Request["email"];
                    cus.TenKH = Request["tenkh"];
                    cus.SoDT = Request["sodt"];
                    cus.Diachi = Request["diachi"];
                    cus.IDUser = Idcus.IDUser;
                    db.KhachHangs.Add(cus);
                    db.SaveChanges();


                    //long kh = db.KhachHang
                    // don hang : thêm thông tin sản phẩm vào đơn hàng
                    string dateAsString = DateTime.Now.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt");
                    dh.MaKH = Idcus.IDUser;
                    dh.NgayDH = DateTime.Parse(dateAsString);
                    dh.NoiGiaoHang = Request["diachi"];
                    dh.ghichu = Request["ghichu"];
                    dh.TongTien = (decimal)tongtien;
                    dh.status = bool.Parse(Request["status"]);
                    db.DonHangs.Add(dh);
                    db.SaveChanges();


                    // laays ra SoHoaDon vừa nhập vào .
                    long NewDH = new UserDb().getNewDonHang(Idcus.IDUser, true);
                    foreach (var item in list)// đưa danh sách sản phẩm đặt hàn vào chitiethoadon
                    {
                        ChiTietDonHang ct = new ChiTietDonHang();
                        ct.MaMH = item.mathang.MaMH;
                        ct.SoHoaDon = NewDH;
                        ct.GiaThanh = item.mathang.GiaThanh;
                        ct.SoLuong = item.soluong;
                        ct.MucGiamGia = item.mathang.GiaKhuyenMai;
                        ct.Tongtien = item.soluong * item.mathang.GiaThanh;
                        db.ChiTietDonHangs.Add(ct);
                        db.SaveChanges();
                    }

                    TempData["thanhtoan"] = "Thanh Toán Thành Công";
                }
                else
                {
                    TempData["thanhtoan"] = "Thanh Toán Không Thành Công";
                } 
            }
            else
            {
                TempData["thanhtoan"] = "Thanh Toán Không Thành Công";
            } 
            return RedirectToAction("Index", "ThanhToan");
        }
        



        public ActionResult DeleteCartProduct(long MaMH)
        {
             var cart = Session["CARTSESSION"];// danh sách sản phẩm lưu trong sé
             var List = new List<CartChoose>();
             var removecart = new List<CartChoose>();
             List = (List<CartChoose>)cart;
            foreach(var iten in List)
            {
                if(iten.mathang.MaMH==MaMH)
                {
                    removecart.Add(iten);
                }
            }
            foreach(var item in removecart)
            {
                List.Remove(item);
            }
           Session["CARTSESSION"]= List;

            return RedirectToAction("Index", "ThanhToan");
        }
         
	}
}