using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 上海燕洵物联网科技有限公司人事管理系统.Models
{
    public class VacateViewModel
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Cause { get; set; }
        public string Remark { get; set; }
    }
}