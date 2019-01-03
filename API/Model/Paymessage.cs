using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    public class Paymessage
    {
        [Key]
        public int Id { get; set; }
        public int EmpsId { get; set; }
        public string Papersnum { get; set; }
        public string Entrydate { get; set; }
        public double TryMoney { get; set; }
        public double RegularMoney { get; set; }
        public double PresentMoney { get; set; }

        public virtual Emp Emps { get; set; }
    }
}
