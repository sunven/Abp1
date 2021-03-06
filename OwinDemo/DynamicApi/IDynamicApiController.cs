using System.Web.Http.Controllers;

namespace OwinDemo.DynamicApi
{
    /// <summary>
    ///     This interface is just used to mark dynamic web api controllers.
    /// </summary>
    internal interface IDynamicApiController : IHttpController
    {
        object ProxyObject { get; }
    }
}