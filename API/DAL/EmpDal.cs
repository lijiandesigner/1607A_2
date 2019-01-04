using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
namespace DAL
{
    public class EmpDal
    {
        MyContent my = new MyContent();
        /// <summary>
        /// 显示个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Emp Showinfo(int id)
        {
            return my.Emps.Where(c => c.Id == id).FirstOrDefault();

        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <param name="puncard">打卡类</param>
        /// <returns>int</returns>
        public int Punchcard(Punchcard puncard)
        {
            my.Punchcards.Add(puncard);
            return my.SaveChanges();
        }


        /// <summary>
        /// 下班打卡
        /// </summary>
        /// <param name="puncard">打卡类</param>
        /// <returns>int</returns>
        public int UptPunchcard(Punchcard puncard)
        {
            my.Entry(puncard).State = EntityState.Modified;
            return my.SaveChanges();
        }
        /// <summary>
        /// 显示个人工资
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Paymessage ShowMoney(int id)
        {
            return my.Paymessages.Where(c => c.Id == id).FirstOrDefault();
        }
        /// <summary>
        /// 请假方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int VacateEmp(int id)
        {
            Vacate vacate = my.Vacates.Where(c => c.EmpsId == id).FirstOrDefault();
            my.Vacates.Add(vacate);
            return my.SaveChanges();
        }
    }
}
