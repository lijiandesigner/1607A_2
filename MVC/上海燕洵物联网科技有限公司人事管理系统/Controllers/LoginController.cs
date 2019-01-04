using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 上海燕洵物联网科技有限公司人事管理系统.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns>int</returns>
        [HttpGet]
        public ActionResult GetoneLogin()
        {
            return View();
        }
       [HttpPost]
        public ActionResult GetoneLogin(string UserName, string UserPwd)
        {
            string result= HttpClientHelper.Seng("get","api/login/login/?name='"+UserName+"'&pwd='"+UserPwd+"' ",null);
            return View();
        }
    }
}