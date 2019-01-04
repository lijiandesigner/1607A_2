using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class EmpBll
    {
        EmpDal dal = new EmpDal();

        /// <summary>
        /// 显示个人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Emp Showinfo(int id)
        {
            return dal.Showinfo(id);

        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <param name="atte">打卡类</param>
        /// <returns>int</returns>
        public int Punchcard(Punchcard puncard)
        {
            return dal.Punchcard(puncard);
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
        /// <summary>
        /// 显示个人工资
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Paymessage ShowMoney(int id)
        {
            return dal.ShowMoney(id);
        }
        /// <summary>
        /// 请假方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int VacateEmp(int id)
        {
            return dal.VacateEmp(id);
        }

    }
}
