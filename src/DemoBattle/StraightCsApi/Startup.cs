using Microsoft.Owin;
using Owin;
using StraightCsApi;

[assembly: OwinStartup(typeof(Startup))]
namespace StraightCsApi
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
