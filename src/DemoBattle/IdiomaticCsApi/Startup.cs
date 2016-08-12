using Microsoft.Owin;
using Owin;
using IdiomaticCsApi;

[assembly: OwinStartup(typeof(Startup))]
namespace IdiomaticCsApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Append("Access-Control-Allow-Headers", "Content-Type");
                await next();
            });
        }
    }
}
