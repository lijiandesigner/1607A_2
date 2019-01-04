using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
namespace ShiXunXiangMu.Controllers
{
    public class LoginController : ApiController
    {
        LoginBll lb = new LoginBll();
        [HttpGet]
        public int Login(string name,string pwd)
        {
            return lb.Login(name,pwd);
        }
    }
}
