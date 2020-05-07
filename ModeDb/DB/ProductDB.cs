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
        NhomDbModel db = null;
        public ProductDB()
        {
            db = new NhomDbModel();
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
    }
}
