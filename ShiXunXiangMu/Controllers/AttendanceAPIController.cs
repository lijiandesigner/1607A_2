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
        /// <returns></returns>
        public List<Punchcard> Get()
        {
            return bll.GetAllAttendance();
        }
        public int Post(Attendance atte)
        {
            return bll.Punchcard(atte);
        }
        public Paymessage Get(int Id)
        {
            return bll.ShowMoney(Id);
        }
        public int Post(Vacate vacate)
        {
            return bll.VacateAttendance(vacate);
        }
    }
}
