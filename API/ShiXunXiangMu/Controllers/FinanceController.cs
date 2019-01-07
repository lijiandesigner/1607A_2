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
    public class FinanceController : ApiController
    {
        FinanceBll FinanceBll = new FinanceBll();
        [HttpGet]
        public IEnumerable<TempPaymessage> GetAllMoney()
        {
           return FinanceBll.GetAllMoney();
        }

        [HttpPost]
        public string Vacatefinance(Vacate vacate)
        {
            int n = FinanceBll.Vacatefinance(vacate);
            if (n>0)
            {
                return "提交成功!等待审核";
            }
            else
            {
                return "提交失败";
            }    
        }

        [HttpGet]
        public IEnumerable<TempFinance> Emps()
        {
            ManagerBll managerBll = new ManagerBll();
            var list = managerBll.GetAllEmp();
            var result = from data in list
                         select new TempFinance
                         {
                             Id=data.Id,
                             Ename=data.Ename,
                             Email=data.Email,
                             Eduty=data.Eduty,
                             Ephone=data.Ephone,
                             Esex=data.Esex,
                             Etype=data.Etype,
                             Papersnum=data.Papersnum,
                             Tracttype=data.Tracttype,
                             BName=data.Departments.BName
                         };
            return result;
        }

    }
}
