using System.Web;
using System.Web.Mvc;

namespace 上海燕洵物联网科技有限公司人事管理系统
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
