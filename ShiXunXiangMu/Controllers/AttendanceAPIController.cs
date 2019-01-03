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
        public List<Punchcard> Get()
        {
            return bll.GetAllAttendance();
        }
        /// <summary>
        /// 员工打卡
        /// </summary>
        /// <param name="atte">打卡信息</param>
        /// <returns>string</returns>
        public string Post(Attendance atte)
        {
            int n= bll.Punchcard(atte);
            if (n>0)
            {
                return "打卡成功";
            }
            else
            {
                return "打卡失败";
            }
        }
        /// <summary>
        /// 查看个人工资
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns>返回工资对象</returns>
        public Paymessage Get(int Id)
        {
            return bll.ShowMoney(Id);
        }
        /// <summary>
        /// 请假
        /// </summary>
        /// <param name="vacate">请假对象</param>
        /// <returns></returns>
        public int Post(Vacate vacate)
        {
            int n=bll.VacateAttendance(vacate);
            if (n > 0)
            {
                return "提交成功";
            }
            else
            {
                return "提交失败";
            }
        }
        /// <summary>
        /// 下班打卡
        /// </summary>
        /// <param name="vacate">打卡类</param>
        /// <returns>int</returns>
        public string Put(Punchcard puncard)
        {
            int n = dal.UptPunchcard(puncard);
            if (n > 0)
            {
                return "打卡成功";
            }
            else
            {
                return "打卡失败";
            }
        }


    }
}
