using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class LoginBll
    {
        LoginDal ld = new LoginDal();
        public Admin Login(string name,string pwd)
        {
            return ld.login(name,pwd);
        }
        public List<Menu> ShowMenu(int Permission)
        {
            return ld.ShowMenu(Permission);
        }
    }
}
