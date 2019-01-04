using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using 上海燕洵物联网科技有限公司人事管理系统.Models;

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
            string json=HttpClientHelper.Send("get", "api/AttendanceAPIController/GetAllAttendance");
            return View(JsonConvert.DeserializeObject<List<PunchcardViewModel>>(json));
        }
        /// <summary>
        /// 打卡
        /// </summary>
        /// <returns>int</returns>
        [HttpGet]
        public ActionResult Punchcard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Punchcard(int Id)
        {
            PunchcardViewModel punchcard = new PunchcardViewModel() { EmpsId = Id, Signindate = DateTime.Now.ToString() };
            string json = JsonConvert.SerializeObject(punchcard);
            string result=HttpClientHelper.Send("post", "api/AttendanceAPIController/Punchcard", json);
            if (result.Contains("成功"))
	        {
                return Content("打卡成功");
	        }
            else
	        {
                return Content("打卡失败");
	        }
        }
        /// <summary>
        /// 显示个人工资方法
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult ShowMoney(int Id)
        {
            string json = HttpClientHelper.Send("get", "api/AttendanceAPIController/ShowMoney?Id="+Id);
            return View(JsonConvert.DeserializeObject<PaymessageViewModel>(json));
        }
        /// <summary>
        /// 请假方法
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet]
        public ActionResult VacateAttendance()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VacateAttendance(VacateViewModel vacate)
        {
            string json = JsonConvert.SerializeObject(vacate);
            string result = HttpClientHelper.Send("post","api/AttendanceAPIController/VacateAttendance",json);
            if (result.Contains("成功"))
	        {
                return Content("提交成功");
	        }
            else
	        {
                return Content("提交失败");
	        }
        }
    }
}