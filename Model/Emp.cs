using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class Emp
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentsId { get; set; }
        public string Ename { get; set; }
        public string Esex { get; set; }
        public string Papersnum { get; set; }
        public string Ephone { get; set; }
        public string Eduty { get; set; }
        public string Email { get; set; }
        public string Tracttype { get; set; }
        public string Etype { get; set; }
        public string ERemark { get; set; }
        public virtual Department Departments { get; set; }
    }
}
