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
    public class AttendanceAPIController : ApiController
    {
        AttendanceBll bll = new AttendanceBll();
        /// <summary>
        /// 获取所有的员工打卡记录
        /// </summary>
        /// <returns>list</returns>
        public List<Punchcard> GetAllAttendance()
        {
            return bll.GetAllAttendance();
        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <param name="punchcard">打卡类</param>
        /// <returns>int</returns>
        [HttpPost]
        public int Punchcard(Punchcard punchcard)
        {
            return bll.Punchcard(punchcard);
        }
        /// <summary>
        /// 显示个人工资
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns>工资对象</returns>
        [HttpGet]
        public Paymessage ShowMoney(int Id)
        {
            return bll.ShowMoney(Id);
        }
        /// <summary>
        /// 请假方法
        /// </summary>
        /// <param name="vacate">请假类</param>
        /// <returns>int</returns>
        [HttpPost]
        public int VacateAttendance(Vacate vacate)
        {
            return bll.VacateAttendance(vacate);
        }
        /// <summary>
        /// 下班打卡
        /// </summary>
        /// <param name="atte">打卡类</param>
        /// <returns>int</returns>      
        [HttpPut]
        public int UptPunchcard(Punchcard punchcard)
        {
            return bll.UptPunchcard(punchcard);
        }
    }
}
