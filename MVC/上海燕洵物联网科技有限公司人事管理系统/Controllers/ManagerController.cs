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
        public ActionResult ShowDepart()
        {
            string str = HttpClientHelper.Seng("get", "/api/ManagerAPIController/ShowDepart", null);
            List<DepartmentViewModel> list = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(str);
            return View(list);
        }
        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <returns>int</returns>
        public ActionResult AddDepart(DepartmentViewModel department)
        {

            string str = JsonConvert.SerializeObject(department);
            string str1 = HttpClientHelper.Seng("post", "/api/ManagerAPIController/AddDepart", str);
            if (str1.Contains("成功"))
            {
                Response.Write("<script>alert('添加成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加成功')</script>");
            }
            return View();
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <returns>int</returns>
        public string UpdateDepart(DepartmentViewModel department)
        {
            string jsonstr = JsonConvert.SerializeObject(department);
            string str = HttpClientHelper.Seng("put", "/api/ManagerAPIController/UpdateDepart/", jsonstr);
            if (str.Contains("成功"))
            {
                return "修改成功";
            }
            else
            {
                return "修改失败";
            }
        }
        /// <summary>
        /// 获取一个部门信息
        /// </summary>
        /// <returns>类名</returns>
        public DepartmentViewModel GetOneDepart(int id)
        {

            string str = HttpClientHelper.Seng("get", "/api/ManagerAPI/GetOneDepart/?Id=" + id, "null");
            DepartmentViewModel depart = JsonConvert.DeserializeObject<DepartmentViewModel>(str);
            return depart;

        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <returns>int</returns>
        public void DeleteDepart(int id)
        {
            string str = HttpClientHelper.Seng("delete", "/api/ManagerAPI/DeleteDepart/?Id=" + id, "null");
            if (str.Contains("成功"))
            {
                Response.Write("<script>alert('删除成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult GetAllEmp()
        {
            string str = HttpClientHelper.Seng("get", "/api/ManagerAPIController/ShowDepart", null);
            return View();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <returns>int</returns>
        public ActionResult AddEmp(EmpViewModel emp)
        {
            string emps = JsonConvert.SerializeObject(emp);
            string str = HttpClientHelper.Seng("post", "/api/ManagerAPIController/AddEmp", emps);
            if (str.Contains("成功"))
            {
                Content("添加成功");
            }
            else
            {
                Content("添加失败");
            }
            return View();
        }
        /// <summary>
        /// 根据部门查看员工
        /// </summary>
        /// <returns>list集合</returns>

        public List<EmpViewModel> SearchEmp(int id)
        {
            string str = HttpClientHelper.Seng("get", "/api/ManagerAPIController/SearchEmp/?id=" + id, null);
            List<EmpViewModel> emps = JsonConvert.DeserializeObject<List<EmpViewModel>>(str);
            return emps;
        }
        /// <summary>
        /// 请假审批
        /// </summary>
        /// <returns>int</returns>
        public string VacateEmp(VacateViewModel vacate)
        {
            string jsonstr = JsonConvert.SerializeObject(vacate);
            string str = HttpClientHelper.Seng("put", "/api/ManagerAPIController/VacateEmp/", jsonstr);
            if (str.Contains("成功"))
            {
                return "修改成功";
            }
            else
            {
                return "修改失败";
            }

        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <returns>int</returns>
        public string DeleteEmp(int id)
        {
            string str = HttpClientHelper.Seng("delete", "/api/ManagerAPIController/DeleteEmp/?id=" + id, null);
            if (str.Contains("成功"))
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <returns>int</returns>
        public ActionResult Punchcard(PunchcardViewModel punchcard)
        {
            string str1 = JsonConvert.SerializeObject(punchcard);
            string str = HttpClientHelper.Seng("post", "/api/ManagerAPIController/Punchcard/", str1);
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
        public string UptPunchcard(PunchcardViewModel punchcard)
        {
            string str1 = JsonConvert.SerializeObject(punchcard);
            string str = HttpClientHelper.Seng("post", "/api/ManagerAPIController/Punchcard/", str1);
            if (str.Contains("成功"))
            {

                return "下班";
            }
            else
            {
                return "失败";
            }
        }
        /// <summary>
        /// 显示个人工资
        /// </summary>
        /// <returns>类名</returns>
        public PaymessageViewModel ShowMoney(int id)
        {
            string str = HttpClientHelper.Seng("get", "/api/ManagerAPIController/ShowMoney/?id=" + id, null);
            PaymessageViewModel paymessage = JsonConvert.DeserializeObject<PaymessageViewModel>(str);
            return paymessage;
        }
    }
    public class HttpClientHelper
    {
        public static string Seng(string method, string apiMethod, string JsonStr)
        {
            Uri uri = new Uri("http://localhost:51087/");
            HttpClient client = new HttpClient();
            client.BaseAddress = uri;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage sponse = null;
            switch (method)
            {
                case "get":
                    sponse = client.GetAsync(apiMethod).Result;
                    break;
                case "post":
                    HttpContent content = new StringContent(JsonStr);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    sponse = client.PostAsync(apiMethod, content).Result;
                    break;
                case "put":
                    HttpContent content1 = new StringContent(JsonStr);
                    content1.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    sponse = client.PutAsync(apiMethod, content1).Result;
                    break;
                case "delete":
                    sponse = client.DeleteAsync(apiMethod).Result;
                    break;
                default:
                    break;

            }
            if (sponse.IsSuccessStatusCode)
            {
                return sponse.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "未知错误";
            }
        }
    }
}