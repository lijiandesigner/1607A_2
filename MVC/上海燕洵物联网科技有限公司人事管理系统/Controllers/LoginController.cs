using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using 上海燕洵物联网科技有限公司人事管理系统.Models;
using System.Web.Security;
namespace 上海燕洵物联网科技有限公司人事管理系统.Controllers
{[Authorize ]
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
            Session["Name"] = null;
            Session["EmpsId"] = null;
            Session["permission"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult GetoneLogin(string UserName, string UserPwd)
        {
            
            string result= HttpClientHelper.Seng("get","api/login/login/?name="+UserName+"&pwd="+UserPwd+" ",null);
            if (result!="null")
            {
                FormsAuthentication.SetAuthCookie(UserName, true);
                var list = JsonConvert.DeserializeObject<AdminViewModel>(result);
                Session["Name"] = list.UserName;
                Session["permission"] = list.Permission;

                //获取所有职员信息,并根据登录名称获取职员的Id,存入Session
                GetEmpsId();

                return Content("<script>location.href='/login/Show'</script>");
            }
            else
            {
                return Content("<script>alert('登录失败',location.href='/login/GetoneLogin')</script>");
            }
        }
        /// <summary>
        /// 根据Session中存入的名称找到其对应的员工Id
        /// </summary>
        private void GetEmpsId()
        {
            var result = HttpClientHelper.Seng("get", "api/Finance/GetAllMoney", null);
            var list = JsonConvert.DeserializeObject<List<PaymessageViewModel>>(result);
            string name = Session["Name"].ToString();
            var theOne = list.Where(a => a.EmpName == name).FirstOrDefault();
            Session["EmpsId"] = theOne.EmpsId;
        }

        /// <summary>
        /// 显示页面
        /// </summary>
        /// <returns></returns>
        
        public ActionResult Show()
        {
            return View();
        }
        /// <summary>
        /// 获取权限值对应的菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowMenu()
        {
            string result = HttpClientHelper.Seng("get", "api/login/ShowMenu?permission=" + Session["permission"], null);
            return Content(result);
        }
    }
}