using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Model;
namespace ShiXunXiangMu.Controllers
{
    public class EmpsAPIController : ApiController
    {
        EmpBll bll = new EmpBll();
        /// <summary>
        /// 显示个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Emp Showinfo(int id)
        {
            return bll.Showinfo(id);

        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <param name="puncard"></param>
        /// <returns></returns>
        [HttpPost]
        public string Punchcard(Punchcard puncard)
        {
            int n = bll.Punchcard(puncard);
            if (n > 0)
            {
                return "打卡成功";
            }
            else
            {
                return "打卡失败";
            }
        }



        /// <summary>
        /// 下班打卡
        /// </summary>
        /// <param name="puncard"></param>
        /// <returns></returns>
        [HttpPut]
        public string UptPunchcard(Punchcard puncard)
        {
            int n = bll.UptPunchcard(puncard);
            if (n > 0)
            {
                return "打卡成功";
            }
            else
            {
                return "打卡失败";
            }
        }
        /// <summary>
        /// 显示个人工资
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Paymessage ShowMoney(int id)
        {
            return bll.ShowMoney(id);
        }
        /// <summary>
        /// 请假方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public string VacateEmp(int id)
        {
            if (bll.VacateEmp(id) > 0)
            {
                return "请假提交成功";
            }
            else
            {
                return "请假提交失败";
            }
        }
    }
}
