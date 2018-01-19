using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AuditingWebApiDemo.Filters
{
    public class AuditFilter : IActionFilter
    {
        //
        // 摘要:
        //     获取或设置一个值，该值指示是否可以为单个程序元素指定多个已指示特性的实例。
        //
        // 返回结果:
        //     如果可以指定多个实例，则为 true；否则为 false。默认值为 false。
        public bool AllowMultiple => false;

        /// <summary>
        /// 异步执行筛选器操作
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="continuation"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            var method = actionContext.ActionDescriptor is ReflectedHttpActionDescriptor descriptor ? descriptor.MethodInfo : null;
            var str = $"{actionContext.ActionDescriptor.ControllerDescriptor.ControllerType.Name}/{method?.Name}/{JsonConvert.SerializeObject(actionContext.ActionArguments)}";


            var stopwatch = Stopwatch.StartNew();
            var path = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
            try
            {
                return await continuation();
            }
            catch (Exception ex)
            {
                File.AppendAllText(path,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + str + "异常：" + ex + "\r\n");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                File.AppendAllText(path,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + str + "耗时：" +
                    Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds) + "\r\n");
            }
        }
    }
}