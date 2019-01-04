using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginDal
    {
        MyContent mc = new MyContent();
        public int login(string name,string pwd)
        {
          int n = mc.Admins.Where(a=>a.UserName==name&&a.UserPwd==pwd).Count();
            return n;
        }
    }
}
