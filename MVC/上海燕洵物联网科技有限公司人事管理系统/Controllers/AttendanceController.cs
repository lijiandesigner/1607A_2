using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

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
            string json=ClientHelper.Send("Get", "api/AttendanceAPIController");
            return View(JsonConvert.DeserializeObject<List<Punchcard>>(json));
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
        public ActionResult Punchcard(Punchcard punchcard)
        {
            string json = JsonConvert.SerializeObject(punchcard);
            string result=ClientHelper.Send("Post", "api/AttendanceAPIController", json);
            if (result.Contains("成功"))
	        {
                return Content("打卡成功");
	        }
            else
	        {
                return Content("打卡失败");
	        }
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
    public class ClientHelper {
        public static string Send(string Method, string path, string jsonStr = "")
        {
            Uri uri = new Uri("http://localhost:60654/");
            HttpClient client = new HttpClient();
            client.BaseAddress = uri;
            HttpResponseMessage response = null;
            switch (Method)
            {
                case "Get":
                    response = client.GetAsync(path).Result;
                    break;
                case "Post":
                    HttpContent content = new StringContent(jsonStr);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = client.PostAsync(path, content).Result;
                    break;
                case "Put":
                    HttpContent content1 = new StringContent(jsonStr);
                    content1.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = client.PutAsync(path, content1).Result;
                    break;
                case "Delete":
                    response = client.DeleteAsync(path).Result;
                    break;
            }
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return "未知错误";
            }

        }
    }
}