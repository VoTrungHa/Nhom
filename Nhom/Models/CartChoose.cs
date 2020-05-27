using ModeDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom.Models
{
    [Serializable]
    public class CartChoose
    {
        public MatHang mathang { get; set; }
        public int? soluong { get; set; }
        
    }
}