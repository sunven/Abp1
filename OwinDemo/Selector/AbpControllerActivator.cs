using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using OwinDemo.DynamicApi;
using OwinDemo.Service;

namespace OwinDemo.Selector
{
    /// <summary>
    /// 创建动态ApiController
    /// </summary>
    public class AbpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            //var controller = (IHttpController)UnityService.Resolve(controllerType);
            //这里只列举了OrderService
            //一般是：在缓存Service时会放进IOC，这里再用IOC来获取
            var dynamicApiController = new DynamicApiController<OrderService>(new OrderService());
            var controller = (IHttpController)dynamicApiController;
            return controller;
        }
    }
}