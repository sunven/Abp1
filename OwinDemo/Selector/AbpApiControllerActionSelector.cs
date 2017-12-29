using System;
using System.Web.Http.Controllers;
using OwinDemo.DynamicApi;

namespace OwinDemo.Selector
{
    /// <summary>
    /// ������дapicontrolleractionselectorѡ��̬apicontroller��action
    /// </summary>
    public class AbpApiControllerActionSelector : ApiControllerActionSelector
    {
        /// <summary>
        /// ������web APIϵͳ���ã��Ӹ�����������ѡ��action����
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

            //��ȡaction
            var actionName = controllerContext.RouteData.Values["action"] as string;
            if (string.IsNullOrEmpty(actionName))
            {
                return base.SelectAction(controllerContext);
            }
            if (!controllerInfo.Actions.ContainsKey(actionName))
            {
                throw new Exception();
            }
            //����DyanamicHttpActionDescriptor ������action�ľ������
            return new DyanamicHttpActionDescriptor(controllerContext.ControllerDescriptor,
                controllerInfo.Actions[actionName].Method, controllerInfo.Actions[actionName].Filters, controllerInfo.Actions[actionName].Verb);
        }
    }
}