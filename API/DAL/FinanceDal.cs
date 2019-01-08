using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    public class FinanceDal
    {
        MyContent my = new MyContent();
        /// <summary>
        /// 显示所有员工工资
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TempPaymessage> GetAllMoney()
        {
            var list = my.Paymessages.ToList();
           
            var result = from data in list
                         select new TempPaymessage {
                             Id=data.Id,
                             EmpsId=data.EmpsId,
                             EmpName=data.Emps.Ename,
                             Entrydate=data.Entrydate,
                             Papersnum=data.Papersnum,
                             TryMoney=data.TryMoney,
                             PresentMoney=data.PresentMoney,
                             RegularMoney=data.RegularMoney
                         };
            return result;
        }
        /// <summary>
        /// 请假方法
        /// </summary>
        /// <returns></returns>
        public int Vacatefinance(Vacate vacate)
        {
            my.Vacates.Add(vacate);
            return my.SaveChanges();
        }

        /// <summary>
        /// 提交离职
        /// </summary>
        /// <param name="dimission"></param>
        /// <returns></returns>
        public int Dimission(Dimission dimission)
        {
            my.Dimissions.Add(dimission);
            return my.SaveChanges();
        }
    }
}