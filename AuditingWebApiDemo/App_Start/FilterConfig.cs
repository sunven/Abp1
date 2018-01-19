using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using AuditingWebApiDemo.Filters;

namespace AuditingWebApiDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new AuditFilter());
        }
    }
}
