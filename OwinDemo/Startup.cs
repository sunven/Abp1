using Owin;

namespace OwinDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseWebApi(ApiGlobalConfiguration.Configuration);
        }
    }
}