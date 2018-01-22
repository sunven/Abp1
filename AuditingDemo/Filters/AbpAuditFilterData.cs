using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace AuditingMvcDemo.Filters
{
    public class AbpAuditFilterData
    {
        private const string AbpAuditFilterDataHttpContextKey = "__AbpAuditFilterData";


        public AbpAuditFilterData(
            Stopwatch stopwatch)
        {
            Stopwatch = stopwatch;
        }

        public Stopwatch Stopwatch { get; }

        public static void Set(HttpContextBase httpContext, AbpAuditFilterData auditFilterData)
        {
            GetAuditDataStack(httpContext).Push(auditFilterData);
        }

        public static AbpAuditFilterData GetOrNull(HttpContextBase httpContext)
        {
            var stack = GetAuditDataStack(httpContext);
            return stack.Count <= 0
                ? null
                : stack.Pop();
        }

        /// <summary>
        ///     获取一个可变大小的后进先出 (LIFO) 集合
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private static Stack<AbpAuditFilterData> GetAuditDataStack(HttpContextBase httpContext)
        {
            if (httpContext.Items[AbpAuditFilterDataHttpContextKey] is Stack<AbpAuditFilterData> stack)
                return stack;
            stack = new Stack<AbpAuditFilterData>();
            httpContext.Items[AbpAuditFilterDataHttpContextKey] = stack;
            return stack;
        }
    }
}