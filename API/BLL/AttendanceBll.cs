using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class AttendanceBll
    {
        AttendanceDal dal = new AttendanceDal();
        /// <summary>
        /// 获取所有员工打卡数据
        /// </summary>
        /// <returns>List<Attendance></returns>
        public List<Punchcard> GetAllAttendance()
        {
            return dal.GetAllAttendance();
        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <param name="atte">打卡类</param>
        /// <returns>int</returns>
        public int Punchcard(Punchcard punchcard)
        {
            //说明是上班打卡或者下午下班打卡
            DateTime date=Convert.ToDateTime(punchcard.Signindate);
            //正常上班
            if (date>=Convert.ToDateTime(DateTime.Now.ToShortDateString()+" 00:00:00") &&date<=Convert.ToDateTime(DateTime.Now.ToShortDateString()+" 08:00:00"))
            {
                return dal.Punchcard(punchcard);
            }
            //晚到一个小时
            else if(date> Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 08:00:00")&&date<Convert.ToDateTime(DateTime.Now.ToShortDateString()+" 09:00:00"))
            {
                punchcard.Signindate = "迟到";
            }
            else if(date >= Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:30:00") && date <= Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 13:30:00"))
            {
                return dal.Punchcard(punchcard);
            }
            else if(date > Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 13:30:00") && date < Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 14:30:00"))
            {
                punchcard.Signindate = "迟到";
            }
            else
            {
                punchcard.Signindate = "旷工";
            }
            return dal.Punchcard(punchcard);
        }
        /// <summary>
        /// 显示个人工资方法
        /// </summary>
        /// <param name="Id">员工编号</param>
        /// <returns>Paymessage</returns>
        public Paymessage ShowMoney(int Id)
        {
            return dal.ShowMoney(Id);
        }
        /// <summary>
        /// 请假方法
        /// </summary>
        /// <param name="vacate">请假类</param>
        /// <returns>int</returns>
        public int VacateAttendance(Vacate vacate)
        {
            return dal.VacateAttendance(vacate);
        }
        /// <summary>
        /// 下班打卡
        /// </summary>
        /// <param name="atte">打卡类</param>
        /// <returns>int</returns>       
        public int UptPunchcard(Punchcard punchcard)
        {
            DateTime date = Convert.ToDateTime(punchcard.Signoutdate);
            //正常下班
            if (date >= Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:30:00")&&date<=Convert.ToDateTime(DateTime.Now.ToShortDateString()+" 13:30:00"))
            {
                return dal.UptPunchcard(punchcard);
            }
            //正常下班
            else if (date >= Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 18:00:00") && date <= Convert.ToDateTime(DateTime.Now.AddDays(1).ToShortDateString() + " 00:00:00"))
            {
                return dal.UptPunchcard(punchcard);
            }
            //早退
            else if (date < Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:30:00")&&date> Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 08:00:00"))
            {
                punchcard.Signoutdate = "早退";
            }
            else if (date<Convert.ToDateTime(DateTime.Now.ToShortDateString()+" 18:00:00")&&date> Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 13:30:00"))
            {
                punchcard.Signoutdate = "早退";
            }
            else
            {
                punchcard.Signoutdate = "未打卡";
            }
            return dal.UptPunchcard(punchcard);
        }
    }
}
