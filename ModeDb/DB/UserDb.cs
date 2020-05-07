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

        public int LoginUser(string Email, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.Email == Email);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.PassWord == passWord)
                    {
                        
                        if(result.Admin==true)
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }

                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}
