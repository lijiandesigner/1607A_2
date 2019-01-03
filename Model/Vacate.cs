using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Vacate
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Cause { get; set; }
        public string Remark { get; set; }
        public int VacateState { get; set; }

        public virtual Emp Emps { get; set; }
    }
}
