using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using 上海燕洵物联网科技有限公司人事管理系统.Models;
namespace 上海燕洵物联网科技有限公司人事管理系统.Controllers
{
    [ShouQuan]
   [Authorize]
    public class FinanceController : Controller
    {
        // GET: Finance
        /// <summary>
        /// 获取所有员工的工资详细
        /// </summary>
        /// <returns>list集合</returns>
        [Authorize(Users = "万耀祖")]
        public ActionResult GetAllMoney()
        {
            var result = HttpClientHelper.Seng("get", "api/Finance/GetAllMoney",null);
            var list = JsonConvert.DeserializeObject<List<PaymessageViewModel>>(result);
            return View(list);
        }
        /// <summary>
        /// 显示职工信息
        /// </summary>
        /// <returns>list集合</returns>
        
        public ActionResult ShowMoney()
        {
           var list = HttpClientHelper.Seng("get", "api/Finance/Emps", null);
           var result=  JsonConvert.DeserializeObject<List<TempFinanceViewModel>>(list);
            var theOne= result.Where(a=>a.Ename==Session["Name"].ToString()).FirstOrDefault();
            return View(theOne);
        }
        /// <summary>
        /// 请假页面显示
        /// </summary>
        /// <returns>int</returns>
        [HttpGet]
        public ActionResult Vacatefinance()
        {
            return View();
        }

        /// <summary>
        /// 获取请假信息
        /// </summary>
        /// <param name="vacate"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Vacatefinance(VacateViewModel vacate)
        {
            vacate.VacateState = 1;
            vacate.EmpsId = Convert.ToInt32(Session["EmpsId"]);
            string str = JsonConvert.SerializeObject(vacate);
            string result = HttpClientHelper.Seng("post", "api/Finance/Vacatefinance",str);
            return Content("<script>alert("+result+"),location.href='/login/Show'</script>");
        }

        /// <summary>
        /// 显示离职页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LiZhi()
        {

            return View();
        }
        /// <summary>
        /// 接收离职信息
        /// </summary>
        /// <param name="dimission"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LiZhi(DimissionViewModel dimission,string[] reason,string name)
        {
            var list = HttpClientHelper.Seng("get", "api/Finance/Emps", null);
            var result = JsonConvert.DeserializeObject<List<TempFinanceViewModel>>(list);
            dimission.LeaveReason= string.Join(",",reason);
            dimission.EmpsId = result.Where(a=>a.Ename==name).FirstOrDefault().Id;
            var str= JsonConvert.SerializeObject(dimission);
            string result1 = HttpClientHelper.Seng("post", "api/Finance/Dimission",str);
            return Content("<script>alert(" + result1 + "),location.href='/login/Show'</script>");
        }
    }
}