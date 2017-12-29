using System;
using System.Collections.Generic;

namespace OwinDemo.DynamicApi
{
    /// <summary>
    /// 所有动态ApiController信息缓在这儿
    /// </summary>
    internal static class DynamicApiControllerManager
    {
        private static readonly IDictionary<string, DynamicApiControllerInfo> DynamicApiControllers;

        static DynamicApiControllerManager()
        {
            DynamicApiControllers =
                new Dictionary<string, DynamicApiControllerInfo>(StringComparer
                    .InvariantCultureIgnoreCase); //TODO@Halil: Test ignoring case
        }

        /// <summary>
        ///     Registers given controller info to be found later.
        /// </summary>
        /// <param name="controllerInfo">Controller info</param>
        public static void Register(DynamicApiControllerInfo controllerInfo)
        {
            DynamicApiControllers[controllerInfo.ServiceName] = controllerInfo;
        }

        /// <summary>
        ///     Searches and returns a dynamic api controller for given name.
        /// </summary>
        /// <param name="controllerName">Name of the controller</param>
        /// <returns>Controller info</returns>
        public static DynamicApiControllerInfo FindOrNull(string controllerName)
        {
            return DynamicApiControllers.TryGetValue(controllerName, out var obj) ? obj : null;
        }  

        public static IEnumerable<DynamicApiControllerInfo> GetAll()
        {
            return DynamicApiControllers.Values;
        }
    }
}