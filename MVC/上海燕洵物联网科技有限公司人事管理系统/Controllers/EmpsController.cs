using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
        /// <summary>
        /// 打卡
        /// </summary>
        /// <returns>int</returns>
        public ActionResult Punchcard()
        {
            return View();
        }
        /// <summary>
        /// 显示个人工资信息
        /// </summary>
        /// <returns>类名</returns>
        public ActionResult ShowMoney(int id)
        {
            return View();
        }
        /// <summary>
        /// 请假
        /// </summary>
        /// <returns>int</returns>
        public ActionResult VacateEmp()
        {
            return View();
        }
    }
}