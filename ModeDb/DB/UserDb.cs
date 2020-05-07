using ModeDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeDb.DB
{
    public class UserDb
    {
        ModelDbNhom db = null;
        public UserDb()
        {
            db = new ModelDbNhom();
        }

        public User GetUserByEmail(string Email)// kiem tra user theo email
        {

            return db.Users.SingleOrDefault(x => x.Email == Email);
        } 
        public string InsertUser(User model)// insert user đen db
        {
            db.Users.Add(model);
            db.SaveChanges();
            return model.Email;
        }
    }
}
