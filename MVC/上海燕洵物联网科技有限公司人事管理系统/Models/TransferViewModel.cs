using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 上海燕洵物联网科技有限公司人事管理系统.Models
{
    public class TransferViewModel
    {
        public int Id { get; set; }
        public string Ename { get; set; }
        public string Transfertype { get; set; }
        public string Transferdate { get; set; }
        public string Remark { get; set; }
    }
}