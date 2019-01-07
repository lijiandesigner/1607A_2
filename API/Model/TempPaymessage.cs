using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TempPaymessage
    {
        public int Id { get; set; }
        public int EmpsId { get; set; }
        public string EmpName { get; set; }
        public string Papersnum { get; set; }
        public string Entrydate { get; set; }
        public double TryMoney { get; set; }
        public double RegularMoney { get; set; }
        public double PresentMoney { get; set; }
    }
}
