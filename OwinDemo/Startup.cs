using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Owin;

namespace OwinDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseWebApi(ApiGlobalConfiguration.Configuration);
            appBuilder.Use((cxt, next) =>
            {
                return next.Invoke();
            });
        }

        static Task HandleRequest(IOwinContext context)
        {
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello, world!");
        }
    }
}