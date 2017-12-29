using System.Web.Http;

namespace OwinDemo.DynamicApi
{
    /// <summary>
    /// ���ж�̬������apicontroller�Ļ���
    /// </summary>
    /// <typeparam name="T">������Ķ�������</typeparam>
    public class DynamicApiController<T> : ApiController, IDynamicApiController
    {
        private readonly T _service;

        public DynamicApiController(T service)
        {
            _service = service;
        }

        /// <summary>
        /// ������Ķ���
        /// </summary>
        public object ProxyObject => _service;
    }
}