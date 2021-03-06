using System;
using System.Collections.Generic;
using System.Web.Http.Filters;

namespace OwinDemo.DynamicApi
{
    /// <summary>
    /// �����洢��̬ApiController��Controller
    /// </summary>
    internal class DynamicApiControllerInfo
    {
        /// <summary>
        ///     Creates a new <see cref="DynamicApiControllerInfo" /> instance.
        /// </summary>
        /// <param name="serviceName">Name of the service</param>
        /// <param name="type">Controller type</param>
        /// <param name="filters">Filters</param>
        public DynamicApiControllerInfo(string serviceName, Type type, IFilter[] filters = null)
        {
            ServiceName = serviceName;
            Type = type;
            Filters = filters ?? new IFilter[] { }; //Assigning or initialzing the action filters.

            Actions = new Dictionary<string, DynamicApiActionInfo>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        ///     Name of the service.
        /// </summary>
        public string ServiceName { get; }

        /// <summary>
        ///     Controller type.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        ///     Dynamic Action Filters for this controller.
        /// </summary>
        public IFilter[] Filters { get; set; }

        /// <summary>
        ///     All actions of the controller.
        /// </summary>
        public IDictionary<string, DynamicApiActionInfo> Actions { get; }
    }
}