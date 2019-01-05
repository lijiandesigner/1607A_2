using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Newtonsoft.Json;
using Model;
namespace ShiXunXiangMu.Controllers
{
    public class LoginController : ApiController
    {
        LoginBll lb = new LoginBll();
        [HttpGet]
        public Admin Login(string name,string pwd)
        {
            return lb.Login(name,pwd);
        }
        [HttpGet]
        public List<Menu> showmenu(int Permission)
        {
            return lb.showmenu(Permission);
        }
    }
}
