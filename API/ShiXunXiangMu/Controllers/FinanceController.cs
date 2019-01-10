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
        /// <summary>
        /// 获取所有员工工资列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TempPaymessage> GetAllMoney()
        {
           return FinanceBll.GetAllMoney();
        }

        /// <summary>
        /// 请假
        /// </summary>
        /// <param name="vacate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 调用经理方法中的所有员工方法,并创建一个临时员工类,在MVC中根据Session["name"]存入的名称,从这个表中找到对应的员工名称显示
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 离职方法
        /// </summary>
        /// <param name="dimission"></param>
        /// <returns></returns>
        public string Dimission(Dimission dimission)
        {
            int n = FinanceBll.Dimission(dimission);
            if (n>0)
            {
                return "办理离职成功!员工信息已移除!";
            }
            else
            {
                return "办理离职失败";
            }
        }

    }
}
