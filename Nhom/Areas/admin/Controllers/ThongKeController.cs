using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModeDb.EF;
using ModeDb.DB;
using Nhom.Common;

namespace Nhom.Areas.admin.Controllers
{
    public class ThongKeController : Controller
    {
        private ModelDbNhom db = new ModelDbNhom();

        // GET: /admin/ThongKe/
        [HasCredentialAttb(ID = "DT")]
        public ActionResult Index()
        {
            TempData["date"]
                = DateTime.Now.ToString("dd/mm/yyyy");
            var donhangs = db.DonHangs.Where(x=>x.status==false).Include(d => d.KhachHang).Include(d => d.NhanVien);
            return View(donhangs.ToList());
        }
        [HttpPost]
        public ActionResult Indexs()
        {
            var t=Request["truoc"];
            var s=Request["sau"];
            DateTime truoc=new DateTime();
            DateTime sau = new DateTime();
            
            if (t.Length == 0 && s.Length == 0)
                {
                    TempData["0"] = "Hãy chọn thời gian!";
                     
                    
                }
                else
                if (t.Length == 0 )
                    {
                        TempData["0"] = "Chưa nhập ngày bắt đầu!";
                         
                    }
                else if (s.Length == 0)
                    {
                        TempData["0"] = "Chưa nhập ngày kết thúc!";
                        
                    }
                    else
                    {
                        truoc = DateTime.Parse(t);
                          sau = DateTime.Parse(s);
                    }
                  
                    if (truoc > sau)
                        {
                            TempData["0"] = "khoản thời gian cần tìm không hợp lệ!";
                            
                        } 
                        else
                        {
                            var donhangs = db.DonHangs.Where(x => x.status == false && x.NgayDH >= truoc && x.NgayDH <= sau).Include(d => d.KhachHang).Include(d => d.NhanVien);
                            if (donhangs == null)
                            {
                                TempData["check"] = 0;
                            }
                            double tong = 0;
                            List<DonHang> ds = donhangs.ToList();
                            foreach (var iten in ds)
                            {
                                tong += (double)iten.TongTien;
                            } @ViewBag.co = true;
                            @TempData["tonng"] = tong;
                            return View("Index",donhangs.ToList());
                        }
                    @ViewBag.co = false;


                    return Redirect("Index");
        }

        // GET: /admin/ThongKe/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // GET: /admin/ThongKe/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            return View();
        }

        // POST: /admin/ThongKe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SoHoaDon,MaKH,MaNV,NgayDH,NgayGH,NoiGiaoHang,TongTien,ghichu,status")] DonHang donhang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", donhang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", donhang.MaNV);
            return View(donhang);
        }

        // GET: /admin/ThongKe/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", donhang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", donhang.MaNV);
            return View(donhang);
        }

        // POST: /admin/ThongKe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SoHoaDon,MaKH,MaNV,NgayDH,NgayGH,NoiGiaoHang,TongTien,ghichu,status")] DonHang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", donhang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", donhang.MaNV);
            return View(donhang);
        }

        // GET: /admin/ThongKe/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // POST: /admin/ThongKe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DonHang donhang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
