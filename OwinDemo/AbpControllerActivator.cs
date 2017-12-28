using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace OwinDemo
{
    /// <summary>
    ///     This class is used to use IOC system to create api controllers.
    ///     It's used by ASP.NET system.
    /// </summary>
    public class AbpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            //var controller = (IHttpController)UnityService.Resolve(controllerType);
            var dynamicApiController = new DynamicApiController<OrderService>(new OrderService());
            var controller = (IHttpController)dynamicApiController;
            return controller;
        }
    }
}