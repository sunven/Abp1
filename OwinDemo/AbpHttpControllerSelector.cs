using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace OwinDemo
{
    /// <summary>
    /// This class is used to extend default controller selector to add dynamic api controller creation feature of Abp.
    /// It checks if requested controller is a dynamic api controller, if it is,
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
        /// This method is called by Web API system to select the controller for this request.
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>The controller to be used</returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //Get request and route data
            if (request == null)
            {
                return base.SelectController(null);
            }

            var routeData = request.GetRouteData();
            if (routeData == null)
            {
                return base.SelectController(request);
            }
            if (!routeData.Values.TryGetValue("service", out var serviceName))
            {
                return base.SelectController(null);
            }
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