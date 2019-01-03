using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac
{
    public interface IManaServer<T>
    {
        int AddDepart(T t);//添加部门
        int DeleteDeport(int id);//删除部门
        List<T> ShowDepart();//显示所有部门
        T GetOneDeport(int id);//根据id获取部门
        int UpdateDeport(T t);//修改部门
        int AddEmp(T t);//添加员工
        int UpdateEmp(T t);//修改员工
        int DeleteEmp(int id);//去除员工
        List<T> GetAllEmp();//获取所有员工数据
        T SearchEmp(string DepartName);//根据部门查看员工
        T VacateEmp();//请假审批
        int Punchcard();//打卡方法
        T ShowMoney();//显示个人工资方法
    }
    public interface IEmpServer<T>
    {
        T Showinfo(int id); //显示个人信息
        int Punchcard(T t);//打卡方法
        T ShowMoney();//显示个人工资方法
        int VcateEmp(T t);//请假方法
    }
    public interface IFinanceServer<T>
    {
        List<T> GetAllMoney();//获取所有数据
        int Punchcard(T t);//打卡方法
        T ShowMoney(int Id);//显示个人工资方法
        int Vacatefinance(T t);//请假方法
    }
    public interface IAttendanceServer<T>
    {
        List<T> GetAllAttendance();//获取所有员工打卡数据
        int Punchcard(T t);//打卡方法
        T ShowMoney(int Id);//显示个人工资方法
        int Vacatefinance(T t);//请假方法
    }
    public interface ILoginServer<T>
    {
        int GetoneLogin(string UserName, string UserPwd);//登录方法
        int UpdatePwd(T t);//修改密码方法
    }
}
