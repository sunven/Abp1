using System.Web.Http;

namespace OwinDemo.DynamicApi
{
    /// <summary>
    /// 所有动态创建的apicontroller的基类
    /// </summary>
    /// <typeparam name="T">被代理的对象类型</typeparam>
    public class DynamicApiController<T> : ApiController, IDynamicApiController
    {
        private readonly T _service;

        public DynamicApiController(T service)
        {
            _service = service;
        }

        /// <summary>
        /// 被代理的对象
        /// </summary>
        public object ProxyObject => _service;
    }
}