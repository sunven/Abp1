using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OwinDemo
{
    public class DyanamicHttpActionDescriptor : ReflectedHttpActionDescriptor
    {
        private readonly IFilter[] _filters;

        /// <summary>获取或设置支持的 http 方法。</summary>
        /// <returns>支持的 http 方法。</returns>
        public override Collection<HttpMethod> SupportedHttpMethods { get; }

        public DyanamicHttpActionDescriptor(HttpControllerDescriptor controllerDescriptor, MethodInfo methodInfo,
            IFilter[] filters, HttpMethod method)
            : base(controllerDescriptor, methodInfo)
        {
            SupportedHttpMethods = new Collection<HttpMethod> {method};
            _filters = filters;
        }

        public override Task<object> ExecuteAsync(HttpControllerContext controllerContext,
            IDictionary<string, object> arguments, CancellationToken cancellationToken)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException(nameof(controllerContext));
            }

            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return CancelTask();
            }

            try
            {
                var argumentValues = this.ExecuteParentMethod<object[]>(typeof(ReflectedHttpActionDescriptor),
                    "PrepareParameters", arguments, controllerContext);

                var actionexcutorType = typeof(ReflectedHttpActionDescriptor).GetNestedType("ActionExecutor",
                    BindingFlags.Instance | BindingFlags.NonPublic);

                var actionExecutor = Activator.CreateInstance(actionexcutorType, MethodInfo);

                if (!(controllerContext.Controller is IDynamicApiController dynamicController))
                {
                    return base.ExecuteAsync(controllerContext, arguments, cancellationToken);
                }
                return actionExecutor.ExecuteMethod<Task<object>>("Execute", dynamicController.ProxyObject,
                    argumentValues);
            }
            catch (Exception ex)
            {
                return CancelTask(ex);
            }
        }


        public override Collection<IFilter> GetFilters()
        {
            var actionFilters = new Collection<IFilter>();

            if (_filters != null && _filters.Length != 0)
                foreach (var filter in _filters)
                    actionFilters.Add(filter);

            foreach (var baseFilter in base.GetFilters())
                actionFilters.Add(baseFilter);
            return actionFilters;
        }


        #region 帮助方法

        private Task<object> CancelTask()
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetCanceled();
            return tcs.Task;
        }

        private Task<object> CancelTask(Exception ex)
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetException(ex);
            return tcs.Task;
        }

        #endregion
    }
}