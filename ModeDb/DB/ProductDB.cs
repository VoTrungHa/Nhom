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

        public IEnumerable<MatHang> getPageListProduct(int page, int pageSize)// bắt đầu và kết thúc. tải packe topagelist
        {
            return db.MatHangs.OrderByDescending(x => x.NgayNhap).ToPagedList(page, pageSize);
        }
    }
}
