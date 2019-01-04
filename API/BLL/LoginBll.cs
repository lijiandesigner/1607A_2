using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class LoginBll
    {
        LoginDal ld = new LoginDal();
        public int Login(string name,string pwd)
        {
            return ld.login(name,pwd);
        }
    }
}
