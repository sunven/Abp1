using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using OwinDemo.DynamicApi;
using OwinDemo.Service;

namespace OwinDemo.Selector
{
    /// <summary>
    /// ������̬ApiController
    /// </summary>
    public class AbpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            //var controller = (IHttpController)UnityService.Resolve(controllerType);
            //����ֻ�о���OrderService
            //һ���ǣ��ڻ���Serviceʱ��Ž�IOC����������IOC����ȡ
            var dynamicApiController = new DynamicApiController<OrderService>(new OrderService());
            var controller = (IHttpController)dynamicApiController;
            return controller;
        }
    }
}