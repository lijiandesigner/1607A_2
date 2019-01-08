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
            string json=HttpClientHelper.Seng("get", "api/AttendanceAPI/GetAllAttendance",null);
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
            string result;
            string Showjson = HttpClientHelper.Seng("get", "api/AttendanceAPI/GetAllAttendance", null);
            List<PunchcardViewModel> punchcards = JsonConvert.DeserializeObject<List<PunchcardViewModel>>(Showjson);
            var pun = punchcards.Where(c => c.EmpsId == Id).FirstOrDefault();
            if (pun == null)
            {
                PunchcardViewModel punchcard = new PunchcardViewModel() { EmpsId = Id, Signindate = DateTime.Now.ToString() };
                string json = JsonConvert.SerializeObject(punchcard);
                result = HttpClientHelper.Seng("post", "api/AttendanceAPI/Punchcard", json);
            }
            else
            {
                pun.Signoutdate = DateTime.Now.ToString();
                string json = JsonConvert.SerializeObject(pun);
                result = HttpClientHelper.Seng("put", "api/AttendanceAPI/UptPunchcard", json);
            }
            if (result.Contains("成功"))
	        {
                Response.Write("<script>alert('打卡成功')<script>");
	        }
            else
	        {
                Response.Write("<script>alert('打卡失败')<script>");
            }
            return View();
        }
        /// <summary>
        /// 显示个人工资方法
        /// </summary>
        /// <returns>list集合</returns>
        public ActionResult ShowMoney(int Id)
        {
            string json = HttpClientHelper.Seng("get", "api/AttendanceAPIController/ShowMoney?Id="+Id,null);
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
            string result = HttpClientHelper.Seng("post","api/AttendanceAPIController/VacateAttendance",json);
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