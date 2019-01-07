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
    }
}