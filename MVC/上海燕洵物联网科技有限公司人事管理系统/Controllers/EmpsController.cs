using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using 上海燕洵物联网科技有限公司人事管理系统.Models;
namespace 上海燕洵物联网科技有限公司人事管理系统.Controllers
{
    public class EmpsController : Controller
    {
        // GET: Emps
        /// <summary>
        /// 显示个人信息
        /// </summary>
        /// <returns>类名</returns>
        public ActionResult Showinfo(int id)
        {
            string str = HttpClientHelper.Seng("get", "api/EmpsAPIController/Showinfo/?id=" + id, null);
            EmpViewModel emp = JsonConvert.DeserializeObject<EmpViewModel>(str);
            return View(emp);
        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <returns>int</returns>
        public ActionResult Punchcard(PunchcardViewModel punchcard)
        {
            string str1 = JsonConvert.SerializeObject(punchcard);
            string str = HttpClientHelper.Seng("post", "api/EmpsAPIController/Punchcard", str1);
            if (str.Contains("成功"))
            {
                Response.Write("<script>alert('打卡成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('打卡失败')</script>");
            }
            return View();
        }
        /// <summary>
        /// 下班打卡
        /// </summary>
        /// <param name="punchcard"></param>
        /// <returns></returns>
        public ActionResult UptPunchcard(PunchcardViewModel punchcard)
        {
            string str1 = JsonConvert.SerializeObject(punchcard);
            string str = HttpClientHelper.Seng("post", "api/EmpsAPIController/Punchcard", str1);
            if (str.Contains("成功"))
            {
                Response.Write("<script>alert('打卡成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('打卡失败')</script>");
            }
            return View("Punchcard");
        }
        /// <summary>
        /// 显示个人工资信息
        /// </summary>
        /// <returns>类名</returns>
        public PaymessageViewModel ShowMoney(int id)
        {
            string str = HttpClientHelper.Seng("get", "api/EmpsAPIController/ShowMoney/?id=" + id, null);
            PaymessageViewModel paymessage = JsonConvert.DeserializeObject<PaymessageViewModel>(str);
            return paymessage;

        }
        /// <summary>
        /// 请假提交
        /// </summary>
        /// <returns>int</returns>
        public ActionResult VacateEmp(VacateViewModel vacate)
        {
            string str = JsonConvert.SerializeObject(vacate);
            string str1 = HttpClientHelper.Seng("post", "api/EmpsAPIController/VacateEmp", str);
            if (str1.Contains("成功"))
            {
                Response.Write("<script>alert('请假提交成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('请假提交失败')</script>");
            }
            return View();
        }
    }

}