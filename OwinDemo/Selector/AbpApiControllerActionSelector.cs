using System;
using System.Web.Http.Controllers;
using OwinDemo.DynamicApi;

namespace OwinDemo.Selector
{
    /// <summary>
    /// 这类重写apicontrolleractionselector选择动态apicontroller的action
    /// </summary>
    public class AbpApiControllerActionSelector : ApiControllerActionSelector
    {
        /// <summary>
        /// 该类由web API系统调用，从给定控制器中选择action方法
        /// </summary>
        /// <param name="controllerContext">Controller context</param>
        /// <returns>Action to be used</returns>
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            if (!controllerContext.ControllerDescriptor.Properties.TryGetValue("__AbpDynamicApiControllerInfo",
                out var controllerInfoObj))
            {
                return base.SelectAction(controllerContext);
            }
            if (!(controllerInfoObj is DynamicApiControllerInfo controllerInfo))
            {
                throw new Exception();
            }

            //获取action
            var actionName = controllerContext.RouteData.Values["action"] as string;
            if (string.IsNullOrEmpty(actionName))
            {
                return base.SelectAction(controllerContext);
            }
            if (!controllerInfo.Actions.ContainsKey(actionName))
            {
                throw new Exception();
            }
            //返回DyanamicHttpActionDescriptor 其中有action的具体操作
            return new DyanamicHttpActionDescriptor(controllerContext.ControllerDescriptor,
                controllerInfo.Actions[actionName].Method, controllerInfo.Actions[actionName].Filters, controllerInfo.Actions[actionName].Verb);
        }
    }
}