using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace OwinDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            ApiGlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector),
                new AbpHttpControllerSelector(ApiGlobalConfiguration.Configuration));

            ApiGlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new AbpHttpControllerSelector(ApiGlobalConfiguration.Configuration));
            ApiGlobalConfiguration.Configuration.Services.Replace(typeof(IHttpActionSelector), new AbpApiControllerActionSelector());
            ApiGlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new AbpControllerActivator());

            ApiGlobalConfiguration.Configuration.Routes.MapHttpRoute(
                "DynamicWebApi",
                "apiservice/{service}/{action}/{id}",
                new { id = RouteParameter.Optional }
            );

            const string url = "http://localhost:8080/";
            var startOpts = new StartOptions(url);
            using (WebApp.Start<Startup>(startOpts))
            {
                Console.WriteLine("Server run at " + url + " , press Enter to exit.");
                //缓存服务层
                var controllerInfo = new DynamicApiControllerInfo("Order", typeof(DynamicApiController<IOrderService>));
                foreach (var methodInfo in DynamicApiControllerActionHelper.GetMethodsOfType(typeof(IOrderService)))
                {
                    controllerInfo.Actions[methodInfo.Name] = new DynamicApiActionInfo(methodInfo.Name, HttpMethod.Get, methodInfo);
                }
                DynamicApiControllerManager.Register(controllerInfo);

                Console.ReadKey();
            }


        }
    }
}
