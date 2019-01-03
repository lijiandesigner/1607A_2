using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    public class Attendance
    {
        public int Id { get; set; }

        public int EmpId { get; set; }
        public int PunchcardsId { get; set; }

        public virtual Punchcard Punchcards { get; set; }
        public virtual Emp Emps { get; set; }
    }
}
