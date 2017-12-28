using System.Web.Http;

namespace OwinDemo
{
    /// <summary>
    ///     This class is used as base class for all dynamically created ApiControllers.
    /// </summary>
    /// <typeparam name="T">Type of the proxied object</typeparam>
    /// <remarks>
    ///     A dynamic ApiController is used to transparently expose an object (Generally an Application Service class)
    ///     to remote clients.
    /// </remarks>
    public class DynamicApiController<T> : ApiController, IDynamicApiController
    {
        private readonly T _service;

        public DynamicApiController(T service)
        {
            _service = service;
        }

        public object ProxyObject => _service;
    }
}