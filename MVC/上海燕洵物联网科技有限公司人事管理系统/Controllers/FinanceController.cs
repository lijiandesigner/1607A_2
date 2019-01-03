using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 上海燕洵物联网科技有限公司人事管理系统.Controllers
{
    public class FinanceController : Controller
    {
        // GET: Finance
        /// <summary>
        /// 获取所有员工的工资详细
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult GetAllMoney()
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
        /// 显示个人工资
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult ShowMoney()
        {
            return View();
        }
        /// <summary>
        /// 请假
        /// </summary>
        /// <returns>int</returns>
        public ActionResult Vacatefinance()
        {
            return View();
        }
    }
}