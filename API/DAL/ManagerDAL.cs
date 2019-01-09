using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.Entity;
using EntityState = System.Data.Entity.EntityState;

namespace DAL
{

    public class ManagerDal
    {
        MyContent my = new MyContent();
        /// <summary>
        /// 显示部门信息
        /// </summary>
        /// <returns></returns>
        public List<Department> ShowDepart()
        {
            return my.Departments.ToList();
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public int AddDepart(Department department)
        {
            my.Departments.Add(department);
            return my.SaveChanges();
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public int UpdateDepart(Department department)
        {
            my.Entry(department).State = EntityState.Modified;
            return my.SaveChanges();
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteDepart(int id)
        {
            var a = my.Departments.Where(c => c.Id == id).FirstOrDefault();
            my.Entry(a).State = EntityState.Deleted;
            return my.SaveChanges();
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        public  List<Emp> GetAllEmp()
        {
            return my.Emps.ToList();
        }
        /// <summary>
        /// 获取单个部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetOneDepart(int id)
        {
            return my.Departments.Where(c => c.Id == id).FirstOrDefault();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int AddEmp(Emp emp)
        {
            my.Emps.Add(emp);
            return my.SaveChanges();
        }
        /// <summary>
        ///根据部门查询员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Emp> SearchEmp(int id)
        {
            return my.Emps.Where(c => c.DepartmentsId == id).ToList();

        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEmp(int id)
        {
            var a = my.Emps.Where(c => c.Id == id).FirstOrDefault();
            my.Entry(a).State = EntityState.Deleted;
            return my.SaveChanges();
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
        /// 请假审批
        /// </summary>
        public int VacateEmp(Vacate vacate)
        {
            my.Entry(vacate).State = EntityState.Modified;
            return my.SaveChanges();
        }
        /// <summary>
        /// 显示请假信息
        /// </summary>
        /// <returns></returns>
        public List<Vacate> ShowVacate()
        {
            return my.Vacates.ToList();
        }
        /// <summary>
        /// 删除请假信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteVacate(int id)
        {
            var a = my.Vacates.Where(c => c.Id == id).FirstOrDefault();
            my.Entry(a).State = EntityState.Deleted;
            return my.SaveChanges();
        }

        /// <summary>
        /// 获取所有职位
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Position> GetPositions(int id) {
            var list= my.Positions.Where(a=>a.DepartmentsId==id).ToList();
            var result = from data in list
                         select new Position
                         {
                             Id = data.Id,
                             DepartmentsId = data.DepartmentsId,
                             Pname = data.Pname
                         };
            return result;
        }
            
    }
}
