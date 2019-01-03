using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 上海燕洵物联网科技有限公司人事管理系统.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        /// <summary>
        /// 获取所有的打卡信息
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult GetAllAttend()
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
        /// 显示个人工资方法
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult ShowMoney()
        {
            return View();
        }
        /// <summary>
        /// 请假方法
        /// </summary>
        /// <returns>int</returns>
        public ActionResult VacateAttendance()
        {
            return View();
        }
    }
}