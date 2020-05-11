using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModeDb.EF;

namespace Nhom.Areas.admin.Controllers
{
    public class ManagerProductController : Controller
    {
        private ModelDbNhom db = new ModelDbNhom();

        // GET: /admin/ManagerProduct/
        public ActionResult Index()
        {
            var mathangs = db.MatHangs.Include(m => m.LoaiMatHang);
            return View(mathangs.ToList());
        }

        // GET: /admin/ManagerProduct/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang mathang = db.MatHangs.Find(id);
            if (mathang == null)
            {
                return HttpNotFound();
            }
            return View(mathang);
        }

        // GET: /admin/ManagerProduct/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiHang = new SelectList(db.LoaiMatHangs, "MaLoaiHang", "TenLoaiMH");
            return View();
        }

        // POST: /admin/ManagerProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaMH,TenMh,GiaThanh,Soluong,MaLoaiHang,NgayNhap,NgaySuaDoi,Image,status,ManHinh,Ram,CameraT,CameraS,Cpu,Gpu,BoNho,DungLuongPin,luotXem,link")] MatHang mathang)
        {
            if (ModelState.IsValid)
            {
                db.MatHangs.Add(mathang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiHang = new SelectList(db.LoaiMatHangs, "MaLoaiHang", "TenLoaiMH", mathang.MaLoaiHang);
            return View(mathang);
        }

        // GET: /admin/ManagerProduct/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang mathang = db.MatHangs.Find(id);
            if (mathang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiHang = new SelectList(db.LoaiMatHangs, "MaLoaiHang", "TenLoaiMH", mathang.MaLoaiHang);
            return View(mathang);
        }

        // POST: /admin/ManagerProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaMH,TenMh,GiaThanh,Soluong,MaLoaiHang,NgayNhap,NgaySuaDoi,Image,status,ManHinh,Ram,CameraT,CameraS,Cpu,Gpu,BoNho,DungLuongPin,luotXem,link")] MatHang mathang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mathang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiHang = new SelectList(db.LoaiMatHangs, "MaLoaiHang", "TenLoaiMH", mathang.MaLoaiHang);
            return View(mathang);
        }

        // GET: /admin/ManagerProduct/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang mathang = db.MatHangs.Find(id);
            if (mathang == null)
            {
                return HttpNotFound();
            }
            return View(mathang);
        }

        // POST: /admin/ManagerProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MatHang mathang = db.MatHangs.Find(id);
            db.MatHangs.Remove(mathang);
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
