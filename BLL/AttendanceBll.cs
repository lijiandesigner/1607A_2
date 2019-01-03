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
        /// <param name="vacate">打卡类</param>
        /// <returns>int</returns>
        public int UptPunchcard(Punchcard puncard)
        {
            return dal.UptPunchcard(puncard);
        }

    }
}
