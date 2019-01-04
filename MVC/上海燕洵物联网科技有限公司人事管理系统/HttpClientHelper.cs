using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
namespace 上海燕洵物联网科技有限公司人事管理系统
{
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