using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 上海燕洵物联网科技有限公司人事管理系统.Models
{
    public class PaymessageViewModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Papersnum { get; set; }
        public string Entrydate { get; set; }
        public double TryMoney { get; set; }
        public double RegularMoney { get; set; }
        public double PresentMoney { get; set; }
    }
}