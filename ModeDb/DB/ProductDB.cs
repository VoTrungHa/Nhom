using ModeDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace ModeDb.DB
{

   
    public class ProductDB
    {
        ModelDbNhom db = null;
        public ProductDB()
        {
            db = new ModelDbNhom();
        }
        // lấy danh sách sản phẩm theo kiểu phân trang
        public IEnumerable<MatHang> getPageListProduct(int page, int pageSize)// bắt đầu và kết thúc. tải packe topagelist
        {
            return db.MatHangs.OrderByDescending(x => x.NgayNhap).ToPagedList(page, pageSize);
        }
        // lấy danh sách sản phẩm

        public List<MatHang> getlistAll()
        {
            return db.MatHangs.ToList();
            
        }



        public bool addProduct(MatHang mathang)
        {
            try
            {
                db.MatHangs.Add(mathang);
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool EditProduct(MatHang mathang)
        {
            try
            {
                var pro = db.MatHangs.Find(mathang.MaMH);
                pro.TenMh = mathang.TenMh;
                pro.GiaThanh = mathang.GiaThanh;
                pro.GiaKhuyenMai = pro.GiaKhuyenMai;
                pro.Soluong = mathang.Soluong;
                pro.MaLoaiHang = mathang.MaLoaiHang;
                mathang.NgaySuaDoi = new DateTime();
                pro.Image = mathang.Image;
                pro.ManHinh = mathang.ManHinh;
                pro.Ram = mathang.Ram;
                pro.CameraS = mathang.CameraS;
                pro.CameraT = mathang.CameraT;
                pro.Cpu = mathang.Cpu;
                pro.Gpu = mathang.Gpu;
                pro.BoNho = mathang.BoNho;
                pro.DungLuongPin = mathang.DungLuongPin;
                db.SaveChanges();
                return true; 
            }
            catch(Exception ex)
            {
                return false;
            }
           

        }

         
    }
}
