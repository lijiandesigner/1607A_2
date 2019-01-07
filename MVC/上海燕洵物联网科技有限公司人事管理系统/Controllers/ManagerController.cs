using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 上海燕洵物联网科技有限公司人事管理系统.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
namespace 上海燕洵物联网科技有限公司人事管理系统.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        /// <summary>
        /// 显示部门信息
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult ShowDepart(int pageindex = 1)
        {
            string str = HttpClientHelper.Seng("get", "api/ManagerAPIController/ShowDepart", null);
            List<DepartmentViewModel> list = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(str);
            ViewBag.currentindex = pageindex;
            ViewBag.totaldata = list.Count;
            ViewBag.totalpage = Math.Round(list.Count * 1.0 / 5);
            return View(list.Skip((pageindex - 1) * 5).Take(5).ToList());
        }
        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <returns>int</returns>
        [HttpGet]
        public ActionResult AddDepart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepart(DepartmentViewModel department)
        {

            string str = JsonConvert.SerializeObject(department);
            string str1 = HttpClientHelper.Seng("post", "api/ManagerAPIController/AddDepart", str);
            if (str1.Contains("成功"))
            {
                Response.Write("<script>alert('添加成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>");
            }
            return View();
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <returns>int</returns>
        public ActionResult UpdateDepart(DepartmentViewModel department)
        {
            string jsonstr = JsonConvert.SerializeObject(department);
            string str = HttpClientHelper.Seng("put", "api/ManagerAPIController/UpdateDepart", jsonstr);
            if (str.Contains("成功"))
            {
                Response.Write("<script>alert('修改成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
                
            }
            return View();
        }
        /// <summary>
        /// 获取一个部门信息
        /// </summary>
        /// <returns>类名</returns>
        public DepartmentViewModel GetOneDepart(int id)
        {

            string str = HttpClientHelper.Seng("get", "api/ManagerAPI/GetOneDepart/?Id=" + id, "null");
            DepartmentViewModel depart = JsonConvert.DeserializeObject<DepartmentViewModel>(str);
            return depart;

        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <returns>int</returns>
        public ActionResult DeleteDepart(int id)
        {
            string str = HttpClientHelper.Seng("delete", "api/ManagerAPI/DeleteDepart/?Id=" + id, "null");
            if (str.Contains("成功"))
            {
                Content("删除成功");
            }
            else
            {
                Content("删除失败");
            }
            return View("GetAllEmp");
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult GetAllEmp(int pageindex = 1)
        {
            string str = HttpClientHelper.Seng("get", "/api/ManagerAPIController/GetAllEmp", null);
            List<EmpViewModel> emps = JsonConvert.DeserializeObject<List<EmpViewModel>>(str);
            ViewBag.currentindex = pageindex;
            ViewBag.totaldata = emps.Count;
            ViewBag.totalpage = Math.Round(emps.Count * 1.0 / 5);
            return View(emps.Skip((pageindex - 1) * 5).Take(5).ToList());
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <returns>int</returns>
        [HttpGet]
        public ActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmp(EmpViewModel emp)
        {
            string emps = JsonConvert.SerializeObject(emp);
            string str = HttpClientHelper.Seng("post", "api/ManagerAPIController/AddEmp", emps);
            if (str.Contains("成功"))
            {
                Content("添加成功");
            }
            else
            {
                Content("添加失败");
            }
            return View("GetAllEmp");
        }
        /// <summary>
        /// 根据部门查看员工
        /// </summary>
        /// <returns>list集合</returns>

        public List<EmpViewModel> SearchEmp(int id)
        {
            string str = HttpClientHelper.Seng("get", "api/ManagerAPIController/SearchEmp/?id=" + id, null);
            List<EmpViewModel> emps = JsonConvert.DeserializeObject<List<EmpViewModel>>(str);
            return emps;
        }
        /// <summary>
        /// 请假审批
        /// </summary>
        /// <returns>int</returns>
        public ActionResult VacateEmp(VacateViewModel vacate)
        {
            string jsonstr = JsonConvert.SerializeObject(vacate);
            string str = HttpClientHelper.Seng("put", "api/ManagerAPIController/VacateEmp/", jsonstr);
            if (str.Contains("成功"))
            {
                Response.Write("<script>alert('修改成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败')<script>");
            }
            return View();
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <returns>int</returns>
        public ActionResult DeleteEmp(int id)
        {
            string str = HttpClientHelper.Seng("delete", "api/ManagerAPIController/DeleteEmp/?id=" + id, null);
            if (str.Contains("成功"))
            {
                 Content("删除成功");
            }
            else
            {
                 Content("删除失败");
            }
            return View("GetALLEmp");
        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <returns>int</returns>
        public ActionResult Punchcard(PunchcardViewModel punchcard)
        {
            string str1 = JsonConvert.SerializeObject(punchcard);
            string str = HttpClientHelper.Seng("post", "api/ManagerAPIController/Punchcard/", str1);
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
            string str = HttpClientHelper.Seng("post", "api/ManagerAPIController/Punchcard/", str1);
            if (str.Contains("成功"))
            {
                Response.Write("<script>alert('修改成功')</script>");
               

            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");

            }
            return View();
        }
        /// <summary>
        /// 显示个人工资
        /// </summary>
        /// <returns>类名</returns>
        public PaymessageViewModel ShowMoney(int id)
        {
            string str = HttpClientHelper.Seng("get", "api/ManagerAPIController/ShowMoney/?id=" + id, null);
            PaymessageViewModel paymessage = JsonConvert.DeserializeObject<PaymessageViewModel>(str);
            return paymessage;
        }
        /// <summary>
        /// 显示请假信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowVacate(int pageindex=1)
        {
            string str = HttpClientHelper.Seng("get","api/ManagerAPIController/ShowVacate",null);
            List<VacateViewModel> list = JsonConvert.DeserializeObject<List<VacateViewModel>>(str);
            ViewBag.currentindex = pageindex;
            ViewBag.totaldata = list.Count;
            ViewBag.totalpage = Math.Round(list.Count * 1.0 / 5);
            return View(list.Skip((pageindex - 1) * 5).Take(5).ToList());
        }
        /// <summary>
        /// 删除请假信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteVacate(int id)
        {
            string str = HttpClientHelper.Seng("delete","api/ManagerAPIController/DeleteVacate/?id="+id,null);
           
            if(str.Contains("成功"))
            {
                 Content("删除成功");
            }
            else
            {
                 Content("删除失败");
            }
            return View("ShowVacate");
        }
    }
   
               
}