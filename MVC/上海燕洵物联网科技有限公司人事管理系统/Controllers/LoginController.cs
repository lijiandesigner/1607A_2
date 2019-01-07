using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using 上海燕洵物联网科技有限公司人事管理系统.Models;
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
            string result= HttpClientHelper.Seng("get","api/login/login/?name="+UserName+"&pwd="+UserPwd+" ",null);
            if (result!="null")
            {
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

        private void GetEmpsId()
        {
            var result = HttpClientHelper.Seng("get", "api/Finance/GetAllMoney", null);
            var list = JsonConvert.DeserializeObject<List<PaymessageViewModel>>(result);
            string name = Session["Name"].ToString();
            var theOne = list.Where(a => a.EmpName == name).FirstOrDefault();
            Session["EmpsId"] = theOne.EmpsId;
        }

        public ActionResult Show()
        {
            return View();
        }
        public ActionResult ShowMenu()
        {
            string result = HttpClientHelper.Seng("get", "api/login/ShowMenu?permission=" + Session["permission"], null);
            return Content(result);
        }
        public ActionResult funmenu(string PermissionName = "")
        {
            string result = "";
            switch (PermissionName)
            {
                case "个人系统":
                    result = "<script>location.href='/Emps/Showinfo'</script>";
                    break;
                case "职员信息":
                    result = "<script>location.href='/Finance/ShowMoney'</script>";
                    break;
                case "我要请假":
                    result = "<script>location.href='/Finance/Vacatefinance'</script>";
                    break;
                case "我要离职":
                    result = "<script>location.href=''</script>";
                    break;
                case "打卡系统":
                    result = "<script>location.href='/Attendance/Punchcard'</script>";
                    break;
                case "每日打卡":
                    result = "<script>location.href=''</script>";
                    break;
                case "工资管理":
                    result = "<script>location.href=''</script>";
                    break;
                case "工资列表":
                    result = "<script>location.href='/Finance/GetAllMoney'</script>";
                    break;
                case "考勤管理":
                    result = "<script>location.href=''</script>";
                    break;
                case "考勤列表":
                    result = "<script>location.href='/Attendance/GetAllAttend'</script>";
                    break;
                case "部门管理":
                    result = "<script>location.href=''</script>";
                    break;
                case "部门列表":
                    result = "<script>location.href='/Manager/ShowDepart'</script>";
                    break;
                case "员工管理":
                    result = "<script>location.href=''</script>";
                    break;
                case "员工列表":
                    result = "<script>location.href='/Manager/GetAll'</script>";
                    break;
                case "审批管理":
                    result = "<script>location.href='/Manager/VacateEmp'</script>";
                    break;
                case "请假列表":
                    result = "<script>location.href='/Manager/ShowVacate'</script>";
                    break;
            }
            return Content(result);
        }

    }
}