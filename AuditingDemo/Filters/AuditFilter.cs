using System;
using System.Diagnostics;
using System.IO;
using System.Web.Mvc;
using AuditingDemo.Filters;

namespace AuditingMvcDemo.Filters
{
    public class AuditFilter : IActionFilter
    {
        /// <summary>
        ///     在执行操作方法后调用。
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var auditData = AbpAuditFilterData.GetOrNull(filterContext.HttpContext);
            if (auditData == null)
                return;
            auditData.Stopwatch.Stop();
            var path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            if (filterContext.Exception != null)
                File.AppendAllText(path,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "异常：" + filterContext.Exception + "\r\n");
            else
                File.AppendAllText(path,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "耗时：" +
                    Convert.ToInt32(auditData.Stopwatch.Elapsed.TotalMilliseconds) + "\r\n");
        }

        /// <summary>
        ///     在执行操作方法之前调用。
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionStopwatch = Stopwatch.StartNew();
            AbpAuditFilterData.Set(
                filterContext.HttpContext,
                new AbpAuditFilterData(actionStopwatch)
            );
        }
    }
}