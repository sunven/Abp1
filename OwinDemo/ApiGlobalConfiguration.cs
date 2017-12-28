using System.Web;
using System.Web.Http;

namespace OwinDemo
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApiGlobalConfiguration
    {
        static readonly HttpConfiguration HttpConfiguration = new HttpConfiguration();

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public static HttpConfiguration Configuration => HttpContext.Current != null ? GlobalConfiguration.Configuration : HttpConfiguration;

    }
}