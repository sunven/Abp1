using System.Net.Http;
using System.Reflection;
using System.Web.Http.Filters;

namespace OwinDemo.DynamicApi
{
    /// <summary>
    /// 用来存储动态ApiController的action.
    /// </summary>
    internal class DynamicApiActionInfo
    {
        /// <summary>
        ///     Createa a new <see cref="DynamicApiActionInfo" /> object.
        /// </summary>
        /// <param name="actionName">Name of the action in the controller</param>
        /// <param name="verb">The HTTP verb that is used to call this action</param>
        /// <param name="method">The method which will be invoked when this action is called</param>
        /// <param name="filters"></param>
        public DynamicApiActionInfo(string actionName, HttpMethod verb, MethodInfo method, IFilter[] filters = null)
        {
            ActionName = actionName;
            Verb = verb;
            Method = method;
            Filters = filters ?? new IFilter[] { }; //Assigning or initialzing the action filters.
        }

        /// <summary>
        ///     Name of the action in the controller.
        /// </summary>
        public string ActionName { get; }

        /// <summary>
        ///     The method which will be invoked when this action is called.
        /// </summary>
        public MethodInfo Method { get; }

        /// <summary>
        ///     The HTTP verb that is used to call this action.
        /// </summary>
        public HttpMethod Verb { get; }

        /// <summary>
        ///     Dynamic Action Filters for this Controller Action.
        /// </summary>
        public IFilter[] Filters { get; set; }
    }
}