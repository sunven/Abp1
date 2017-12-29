using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using OwinDemo.DynamicApi;

namespace OwinDemo.Selector
{
    /// <summary>
    /// 此类用于扩展默认控制器选择器，以添加ABP的动态API控制器创建功能.
    /// 检查请求的控制器是否是动态API控制器
    /// returns <see cref="HttpControllerDescriptor"/> to ASP.NET system.
    /// </summary>
    public class AbpHttpControllerSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration _configuration;

        /// <summary>
        /// Creates a new <see cref="AbpHttpControllerSelector"/> object.
        /// </summary>
        /// <param name="configuration">Http configuration</param>
        public AbpHttpControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 此方法被Web API系统调用，以便为该请求选择控制器
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>The controller to be used</returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            if (request == null)
            {
                return base.SelectController(null);
            }
            //获取请求的路由
            var routeData = request.GetRouteData();
            if (routeData == null)
            {
                return base.SelectController(request);
            }
            if (!routeData.Values.TryGetValue("service", out var serviceName))
            {
                return base.SelectController(null);
            }
            //从缓存中取到DynamicApiControllerInfo
            var controllerInfo = DynamicApiControllerManager.FindOrNull(serviceName.ToString());
            if (controllerInfo == null)
            {
                return base.SelectController(request);
            }
            var controllerDescriptor = new DynamicHttpControllerDescriptor(_configuration,
                controllerInfo.ServiceName, controllerInfo.Type, controllerInfo.Filters);
            controllerDescriptor.Properties["__AbpDynamicApiControllerInfo"] = controllerInfo;
            return controllerDescriptor;
        }
    }
}