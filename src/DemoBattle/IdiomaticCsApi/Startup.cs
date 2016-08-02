using Microsoft.Owin;
using Owin;
using CsApi;

[assembly: OwinStartup(typeof(Startup))]
namespace CsApi
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
