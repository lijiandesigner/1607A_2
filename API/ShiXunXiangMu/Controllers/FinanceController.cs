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
    }
}
