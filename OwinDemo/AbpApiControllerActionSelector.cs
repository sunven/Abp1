using System;
using System.Web.Http.Controllers;

namespace OwinDemo
{
    /// <summary>
    ///     This class overrides ApiControllerActionSelector to select actions of dynamic ApiControllers.
    /// </summary>
    public class AbpApiControllerActionSelector : ApiControllerActionSelector
    {
        /// <summary>
        ///     This class is called by Web API system to select action method from given controller.
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
            //Get controller information which is selected by AbpHttpControllerSelector.
            if (!(controllerInfoObj is DynamicApiControllerInfo controllerInfo))
            {
                throw new Exception();
            }

            //Get action name
            var actionName = controllerContext.RouteData.Values["action"] as string;
            if (string.IsNullOrEmpty(actionName))
            {
                return base.SelectAction(controllerContext);
            }
            //Get action information
            if (!controllerInfo.Actions.ContainsKey(actionName))
            {
                throw new Exception();
            }
            return new DyanamicHttpActionDescriptor(controllerContext.ControllerDescriptor,
                controllerInfo.Actions[actionName].Method, controllerInfo.Actions[actionName].Filters, controllerInfo.Actions[actionName].Verb);
        }
    }
}