using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    public class Dimission
    {
        [Key]
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string LeaveType { get; set; }
        public string Yleavedate { get; set; }
        public string Xsettledate { get; set; }
        public string Remark { get; set; }
        public string Applydate { get; set; }
        public string LeaveReason { get; set; }
        public string Lastworkdate { get; set; }

        public virtual Emp Emps { get; set; }
    }
}
