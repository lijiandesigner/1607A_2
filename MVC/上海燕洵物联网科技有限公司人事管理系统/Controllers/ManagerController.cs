using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 上海燕洵物联网科技有限公司人事管理系统.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        /// <summary>
        /// 显示部门信息
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult ShowDepart()
        {
            return View();
        }
        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <returns>int</returns>
        public ActionResult AddDepart()
        {
            return View();
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <returns>int</returns>
        public ActionResult UpdateDepart()
        {
            return View();
        }
        /// <summary>
        /// 获取一个部门信息
        /// </summary>
        /// <returns>类名</returns>
        public ActionResult GetOneDepart()
        {
            return View();
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <returns>int</returns>
        public int DeleteDepart(int id)
        {
            return 1;
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult GetAllEmp()
        {
            return View();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <returns>int</returns>
        public ActionResult AddEmp()
        {
            return View();
        }
        /// <summary>
        /// 根据部门查看员工
        /// </summary>
        /// <returns>list集合</returns>
       
        public ActionResult SearchEmp()
        {
            return View();
        }
        /// <summary>
        /// 请假审批
        /// </summary>
        /// <returns>int</returns>
        public ActionResult VacateEmp()
        {
            return View();
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <returns>int</returns>
        public int DeleteEmp()
        {
            return 1;
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
        /// <returns>类名</returns>
        public ActionResult ShowMoney()
        {
            return View();
        }
    }
}