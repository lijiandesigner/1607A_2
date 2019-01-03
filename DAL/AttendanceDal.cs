using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DAL
{
    public class AttendanceDal
    {
        MyContent my = new MyContent();
        /// <summary>
        /// 获取所有员工打卡数据
        /// </summary>
        /// <returns>List<Attendance></returns>
        public List<Punchcard> GetAllAttendance()
        {
            return my.Punchcards.ToList();
        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <param name="atte">打卡类</param>
        /// <returns>int</returns>
        public int Punchcard(Punchcard punchcard)
        {
            my.Punchcards.Add(punchcard);
            return my.SaveChanges();
        }
        /// <summary>
        /// 显示个人工资方法
        /// </summary>
        /// <param name="Id">员工编号</param>
        /// <returns>Paymessage</returns>
        public Paymessage ShowMoney(int Id)
        {
            return my.Paymessages.Where(c => c.Id == Id).FirstOrDefault();
        }
        /// <summary>
        /// 请假方法
        /// </summary>
        /// <param name="vacate">请假类</param>
        /// <returns>int</returns>
        public int VacateAttendance(Vacate vacate)
        {
            my.Vacates.Add(vacate);
            return my.SaveChanges();
        }
        /// <summary>
        /// 下班打卡
        /// </summary>
        /// <param name="vacate">打卡类</param>
        /// <returns>int</returns>
        public int UptPunchcard(Punchcard puncard)
        {
            my.Entry(puncard).State = EntityState.Modified;
            return my.SaveChanges();
        }
    }
}
