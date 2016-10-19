using LightInject;
using System.Web.Http;
using Pubs.Services.Modules;

namespace Pubs.WebApi
{
    public class LightInjectConfig
    {
        public static void InitializeLightInject(HttpConfiguration httpConfiguration)
        {
            var container = new ServiceContainer();
            container.RegisterApiControllers();
            container.EnableWebApi(httpConfiguration);
            container.BindServices();
        }
    }
}