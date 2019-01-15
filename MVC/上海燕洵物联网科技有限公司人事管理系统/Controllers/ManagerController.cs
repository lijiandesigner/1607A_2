using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 上海燕洵物联网科技有限公司人事管理系统.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data;
namespace 上海燕洵物联网科技有限公司人事管理系统.Controllers
{
    [ShouQuan]
    [Authorize(Users ="史宁伟")]
    public class ManagerController : Controller
    {
        // GET: Manager
        /// <summary>
        /// 显示部门信息
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult ShowDepart(int pageindex = 1)
        {
            string str = HttpClientHelper.Seng("get", "api/ManagerAPI/ShowDepart", null);
            List<DepartmentViewModel> list = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(str);
            ViewBag.currentindex = pageindex;
            ViewBag.totaldata = list.Count;
            ViewBag.totalpage = Math.Round((list.Count() * 1.0) / 5);
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
            string str1 = HttpClientHelper.Seng("post", "api/ManagerAPI/AddDepart", str);
            if (str1.Contains("成功"))
            {
                return Content("添加成功");
            }
            else
            {
                return Content("添加失败");
            }
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <returns>int</returns>
        [HttpGet]
        public ActionResult UpdateDepart(int id)
        {
            string str2 = HttpClientHelper.Seng("get", "api/ManagerAPI/ShowDepart", null);
            List<DepartmentViewModel> list = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(str2);
            DepartmentViewModel list1 = list.Where(c => c.Id == id).FirstOrDefault();
            return View(list1);
           
        }
        [HttpPost]
        public ActionResult UpdateDepart(DepartmentViewModel department)
        {
            string jsonstr = JsonConvert.SerializeObject(department);
            string str = HttpClientHelper.Seng("put", "api/ManagerAPI/UpdateDepart", jsonstr);
            if (str.Contains("成功"))
            {
                return Content("修改成功");
            }
            else
            {
                return Content("修改失败");
            }
        }
        /// <summary>
        /// 获取一个部门信息
        /// </summary>
        /// <returns>类名</returns>
        public ActionResult GetOneDepart(int id)
        {

            string str = HttpClientHelper.Seng("get", "api/ManagerAPI/GetOneDepart?Id=" + id, "null");
            DepartmentViewModel depart = JsonConvert.DeserializeObject<DepartmentViewModel>(str);
            return View(depart);

        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <returns>int</returns>
        public ActionResult DeleteDepart(int id)
        {
            string str = HttpClientHelper.Seng("delete", "api/ManagerAPI/DeleteDepart?Id=" + id, "null");
            if (str.Contains("成功"))
            {
                return Content("删除成功");
            }
            else
            {
               return Content("删除失败");
            }
           
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult GetAllEmp(int pageindex=1)
        {
            var list = HttpClientHelper.Seng("get", "api/Finance/Emps", null);
            var result = JsonConvert.DeserializeObject<List<TempFinanceViewModel>>(list);
            ViewBag.currentindex = pageindex;
            ViewBag.totaldata = result.Count;
            ViewBag.totalpage = Math.Ceiling((result.Count() * 1.0) / 6);
            return View(result.Skip((pageindex - 1) * 6).Take(6).ToList());
           
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <returns>int</returns>
        [HttpGet]
        public ActionResult AddEmp()
        {
            string str = HttpClientHelper.Seng("get", "api/ManagerAPI/ShowDepart", null);
            var department = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(str);
            var list = from s in department
                       select new SelectListItem()
                       {
                           Text=s.BName,
                           Value=s.Id.ToString()
                       };
            ViewBag.Showdepart = list.ToList();
            ViewBag.position = new List<SelectListItem>();
            return View();
        }
        
        [HttpPost]
        public ActionResult ErJi(int id)
        {
            var list = HttpClientHelper.Seng("get", "api/ManagerAPI/GetPositions?id="+id, null);
            var position = JsonConvert.DeserializeObject<List<PositionViewModel>>(list);
            var result = from data in position
                         select new SelectListItem
                         {
                             Text=data.Pname,
                             Value=data.Pname
                         };

            return Json(result);
        }
        [HttpPost]
        public ActionResult AddEmp(EmpViewModel emp)
        {
            string emps = JsonConvert.SerializeObject(emp);
            string str = HttpClientHelper.Seng("post", "api/ManagerAPI/AddEmp", emps);
            if (str.Contains("成功"))
            {
                return Content("添加成功");
            }
            else
            {
                return Content("添加失败");
            }           
        }
        /// <summary>
        /// 根据部门查看员工
        /// </summary>
        /// <returns>list集合</returns>
        public List<EmpViewModel> SearchEmp(int id)
        {
            string str = HttpClientHelper.Seng("get", "api/ManagerAPI/SearchEmp?id=" + id, null);
            List<EmpViewModel> emps = JsonConvert.DeserializeObject<List<EmpViewModel>>(str);
            return emps;
        }
        /// <summary>
        /// 请假审批
        /// </summary>
        /// <returns>int</returns>
        [HttpGet]
        public ActionResult VacateEmp(int id)
        {
            string str = HttpClientHelper.Seng("get", "api/ManagerAPI/ShowVacate", null);
            List<VacateViewModel> list = JsonConvert.DeserializeObject<List<VacateViewModel>>(str);
            VacateViewModel list1 = list.Where(c => c.Id == id).FirstOrDefault();
            return View(list1);
        }
        [HttpPost]
        public ActionResult VacateEmp(VacateViewModel vacate)
        {
         
            string jsonstr = JsonConvert.SerializeObject(vacate);
            string str = HttpClientHelper.Seng("put", "api/ManagerAPI/VacateEmp", jsonstr);
            if (str.Contains("完成"))
            {
                return Content("操作成功");
            }
            else
            {
                return Content("操作失败");
            }
       
        }
        
       
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <returns>int</returns>
        public ActionResult DeleteEmp(int id)
        {
            string str = HttpClientHelper.Seng("delete", "api/ManagerAPI/DeleteEmp?id=" + id, null);
            if (str.Contains("成功"))
            {
               return  Content("删除成功");
            }
            else
            {
                return Content("删除失败");
            }
            
        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <returns>int</returns>
        public ActionResult Punchcard(PunchcardViewModel punchcard)
        {
            string str1 = JsonConvert.SerializeObject(punchcard);
            string str = HttpClientHelper.Seng("post", "api/ManagerAPI/Punchcard/", str1);
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
            string str = HttpClientHelper.Seng("post", "api/ManagerAPI/Punchcard/", str1);
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
            string str = HttpClientHelper.Seng("get", "api/ManagerAPI/ShowMoney?id=" + id, null);
            PaymessageViewModel paymessage = JsonConvert.DeserializeObject<PaymessageViewModel>(str);
            return paymessage;
        }
        /// <summary>
        /// 显示请假信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowVacate(int pageindex=1)
        {
            string str = HttpClientHelper.Seng("get", "api/ManagerAPI/ShowVacate", null);
            List<VacateViewModel> list = JsonConvert.DeserializeObject<List<VacateViewModel>>(str).OrderBy(c=>c.VacateState).ToList();
            ViewBag.currentindex = pageindex;
            ViewBag.totaldata = list.Count();
            ViewBag.totalpage = Math.Round((list.Count() * 1.0)/ 5);
            return View(list.Skip((pageindex - 1) * 5).Take(5).ToList());
        }
        /// <summary>
        /// 删除请假信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteVacate(int id)
        {
            string str = HttpClientHelper.Seng("delete","api/ManagerAPI/DeleteVacate?id="+id,null);
            if(str.Contains("成功"))
            {
               return  Content("删除成功");
            }
            else
            {
                return Content("删除失败");
            }
           
        }
        /// <summary>
        /// 修改员工（调职）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateEmp(int id)
        {
            string str = HttpClientHelper.Seng("get", "api/ManagerAPI/ShowDepart", null);
            var department = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(str);
            var list = from s in department
                       select new SelectListItem()
                       {
                           Text = s.BName,
                           Value = s.Id.ToString()
                       };
            ViewBag.Showdepart = list.ToList();
            ViewBag.position = new List<SelectListItem>();
           
            string str2 = HttpClientHelper.Seng("get", "api/ManagerAPI/GetAllEmp", null);
            List<EmpViewModel> list6 = JsonConvert.DeserializeObject<List<EmpViewModel>>(str2);
            EmpViewModel list1 = list6.Where(c => c.Id == id).FirstOrDefault();

            string str10 = HttpClientHelper.Seng("get", "api/ManagerAPI/ShowDepart", null);
            List<DepartmentViewModel> list10 = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(str10);
            
            ViewBag.Bname = list10.Where(c => c.Id == list1.DepartmentsId).FirstOrDefault().BName;
            ViewBag.Zname = list1.Eduty;
            ViewBag.Ename = list1.Ename;
            list1.DepartmentsId = 0;
            return View(list1);
    
        }
        [HttpPost]
        public ActionResult UpdateEmp(EmpViewModel emp,string Transferdate)
        {
            string str10 = HttpClientHelper.Seng("get", "api/ManagerAPI/ShowDepart", null);
            var department = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(str10);
            var list = from s in department
                       select new SelectListItem()
                       {
                           Text = s.BName,
                           Value = s.Id.ToString()
                       };
            ViewBag.Showdepart = list.ToList();
            ViewBag.position = new List<SelectListItem>();
            string jsonstr = JsonConvert.SerializeObject(emp);
            string str = HttpClientHelper.Seng("put", "api/ManagerAPI/UpdateEmp", jsonstr);
            if (str.Contains("1"))
            {
                TransferViewModel transfer = new TransferViewModel();
                transfer.Ename = emp.Ename;
                transfer.Transfertype = "调职";
                transfer.Transferdate = Transferdate;
                string str1 = JsonConvert.SerializeObject(transfer);
                string strtran= HttpClientHelper.Seng("post", "api/ManagerAPI/AddTranfer", str1);
                return Content("修改成功");
            }
            else
            {
                return Content("修改失败");

            }
           
        }
    }
    public enum StateInfo
    {
        待审核 = 1,
        审核通过 = 2,
        驳回 = 3
    }

}