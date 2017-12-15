using System.Threading.Tasks;
using Microsoft.Owin;
//using Microsoft.Owin.Host.HttpListener;
using Owin;

namespace OwinDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Run(HandleRequest);
        }

        static Task HandleRequest(IOwinContext context)
        {
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello, world!");
        }
    }
}