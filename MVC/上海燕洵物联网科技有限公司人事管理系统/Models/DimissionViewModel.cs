using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 上海燕洵物联网科技有限公司人事管理系统.Models
{
    public class DimissionViewModel
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string LeaveType { get; set; }
        public string Yleavedate { get; set; }
        public string Xsettledate { get; set; }
        public string Remark { get; set; }
        public string Applydate { get; set; }
        public string LeaveReason { get; set; }
        public string Lastworkdate { get; set; }
    }
}