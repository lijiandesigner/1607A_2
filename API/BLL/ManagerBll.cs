using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
   public class ManagerBll
    {
        ManagerDal dal = new ManagerDal();
        public List<Department> ShowDepart()
        {
            return dal.ShowDepart();
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public int AddDepart(Department department)
        {
            return dal.AddDepart(department);
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public int UpdateDepart(Department department)
        {
            return dal.UpdateDepart(department);
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteDepart(int id)
        {
            return dal.DeleteDepart(id);
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<Emp> GetAllEmp()
        {
            return dal.GetAllEmp();
        }
        /// <summary>
        /// 获取单个部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetOneDepart(int id)
        {
            return dal.GetOneDepart(id);
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int AddEmp(Emp emp)
        {
            return dal.AddEmp(emp);
        }
        /// <summary>
        ///根据部门查询员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Emp> SearchEmp(int id)
        {
            return dal.SearchEmp(id);

        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEmp(int id)
        {
            return dal.DeleteEmp(id);
        }
        /// <summary>
        /// 打卡方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Punchcard(int id)
        {
            return dal.Punchcard(id);
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
    }
}
