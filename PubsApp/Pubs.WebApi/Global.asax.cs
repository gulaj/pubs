using System.Web.Http;

namespace Pubs.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            LightInjectConfig.InitializeLightInject(GlobalConfiguration.Configuration);
        }
    }
}
