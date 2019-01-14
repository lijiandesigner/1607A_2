using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Position
    {
        public int Id { get; set; }
        public string Pname { get; set; }
        public int DepartmentsId { get; set; }

        public virtual Department Departments { get; set; }
    }
}
