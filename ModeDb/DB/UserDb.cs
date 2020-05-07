using ModeDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeDb.DB
{
    class UserDb
    {
        NhomDbModel db = null;
        public UserDb()
        {
            db = new NhomDbModel();
        }

    }
}
