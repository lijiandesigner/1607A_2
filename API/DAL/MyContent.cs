using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
namespace DAL
{
    public class MyContent:DbContext
    {
        public MyContent() : base("BaseContext") {

        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Dimission> Dimissions { get; set; }
        public virtual DbSet<Emp> Emps { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Paymessage> Paymessages { get; set; }
        public virtual DbSet<Punchcard> Punchcards { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<Vacate> Vacates { get; set; }
    }
}
