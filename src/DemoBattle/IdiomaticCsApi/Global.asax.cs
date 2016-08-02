using System.Web;
using System.Web.Http;

namespace CsApi
{
    public class WebApiApplication : HttpApplication
    {
        private static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(Register);
        }
    }
}
