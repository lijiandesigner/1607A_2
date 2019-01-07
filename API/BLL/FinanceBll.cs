using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class FinanceBll
    {
        FinanceDal FinanceDal = new FinanceDal();
        public IEnumerable<TempPaymessage> GetAllMoney()
        {
            return FinanceDal.GetAllMoney();
        }
    }
}
