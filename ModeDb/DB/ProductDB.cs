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
        // xem chi tiet sản phẩm.
         

        public MatHang getProductByID(long? id)
        {
            return db.MatHangs.Find(id);
            
        } 

        public List<MatHang> ClientSearchPro(string p,string hdh, string giathanh)
        {
            if (giathanh == "desc")
            {
                return db.MatHangs.Where(x => x.TenMh.Contains(p) || x.MaHDH.Contains(hdh)).OrderByDescending(x => x.GiaThanh).ToList();
            }
            else if(giathanh == "asc")
            {
                return db.MatHangs.Where(x => x.TenMh.Contains(p) || x.MaHDH.Contains(hdh)).OrderBy (x => x.GiaThanh).ToList();
            }
            else
            {
                return db.MatHangs.Where(x => x.TenMh.Contains(p) || x.MaHDH.Contains(hdh)).OrderByDescending(x => x.NgayNhap).ToList();
            }
            
        }
 
    }
}
