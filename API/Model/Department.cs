using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string BName { get; set; }
        public string Bremark { get; set; }
    }
}
