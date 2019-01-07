using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    public class LoginDal
    {
        MyContent mc = new MyContent();
        public Admin login(string name, string pwd)
        {
            return mc.Admins.Where(a => a.UserName.Equals(name) && a.UserPwd.Equals(pwd)).FirstOrDefault();
        }
        public List<Menu> ShowMenu(int Permission)
        {
            return mc.Menus.Where(c => c.Permission==(c.Permission&Permission)).ToList(); 
        }
    }
}
