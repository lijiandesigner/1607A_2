using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 上海燕洵物联网科技有限公司人事管理系统.Models
{
    public class EmpViewModel
    {
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
        public string Bname { get; set; }
    }
}