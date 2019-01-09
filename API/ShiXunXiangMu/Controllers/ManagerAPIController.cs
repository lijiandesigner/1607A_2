using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using BLL;
using Model;
namespace ShiXunXiangMu.Controllers
{
    public class ManagerAPIController : ApiController
    {
        ManagerBll bll = new ManagerBll();
        [HttpGet]
        public List<Department> ShowDepart()
        {
            return bll.ShowDepart();
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddDepart(Department department)
        {
            if (bll.AddDepart(department) > 0)
            {
                return "成功";
            }
            else
            {
                return "失败";
            }
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPut]
        public string UpdateDepart(Department department)
        {
            if (bll.UpdateDepart(department) > 0)
            {
                return "修改成功";
            }
            else
            {
                return "失败";
            }
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public string DeleteDepart(int id)
        {
            if (bll.DeleteDepart(id) > 0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Emp> GetAllEmp()
        {
            return bll.GetAllEmp();
        }
        /// <summary>
        /// 获取单个部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Department GetOneDepart(int id)
        {
            return bll.GetOneDepart(id);
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddEmp(Emp emp)
        {
            if (bll.AddEmp(emp) > 0)
            {
                return "添加成功";
            }
            else
            {
                return "添加失败";
            }
        }
        /// <summary>
        ///根据部门查询员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Emp> SearchEmp(int id)
        {
            return bll.SearchEmp(id);

        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public string DeleteEmp(int id)
        {
            if (bll.DeleteEmp(id) > 0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
        /// <summary>
        /// 上班打卡
        /// </summary>
        /// <param name="puncard"></param>
        /// <returns></returns>
        [HttpGet]
        public string Post(Punchcard puncard)
        {
            int n = bll.Punchcard(puncard);
            if (n > 0)
            {
                return "打卡成功";
            }
            else
            {
                return "打卡失败";
            }
        }



        /// <summary>
        /// 下班打卡
        /// </summary>
        /// <param name="puncard"></param>
        /// <returns></returns>
        [HttpPut]
        public string UptPunchcard(Punchcard puncard)
        {
            int n = bll.UptPunchcard(puncard);
            if (n > 0)
            {
                return "打卡成功";
            }
            else
            {
                return "打卡失败";
            }
        }

        /// <summary>
        /// 显示个人工资
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Paymessage ShowMoney(int id)
        {
            return bll.ShowMoney(id);
        }
        /// <summary>
        /// 请假审批
        /// </summary>
        [HttpPut]
        public string VacateEmp(Vacate vacate)
        {
            if (bll.VacateEmp(vacate) > 0)
            {
                return "审批完成";
            }
            else
            {
                return "审批失败";
            }
        }
        /// <summary>
        /// 显示请假信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Vacate> ShowVacate()
        {
            return bll.ShowVacate();
        }
        /// <summary>
        /// 删除请假信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public string DeleteVacate(int id)
        {
            if( bll.DeleteVacate(id)>0)
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }

        /// <summary>
        /// 获取所有职位信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Position> GetPositions(int id)
        {
            return bll.GetPositions(id);
        }
        /// <summary>
        /// 修改员工（调职）
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPut]
        public int UpdateEmp(Emp emp)
        {
            return bll.UpdateEmp(emp);
        }
        /// <summary>
        /// 添加调职信息
        /// </summary>
        /// <param name="transfer"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddTranfer(Transfer transfer)
        {
            return bll.AddTranfer(transfer);
        }
    }
}
