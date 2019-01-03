using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    public class Punchcard
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string Signindate { get; set; }
        public string Signoutdate { get; set; }

        public virtual Emp Emps { get; set; }
        public int MyProperty { get; set; }
    }
}
