using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 上海燕洵物联网科技有限公司人事管理系统.Models
{
    public class PunchcardViewModel
    {
        public int Id { get; set; }
        public int EmpsId { get; set; }
        public string Signindate { get; set; }
        public string Signoutdate { get; set; }
        public int AttenState { get; set; }
    }
}