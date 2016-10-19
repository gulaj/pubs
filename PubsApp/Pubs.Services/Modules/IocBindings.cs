using LightInject;
using Pubs.Core.Abstract.Builders;
using Pubs.Core.Abstract.Places;
using Pubs.Services.Builders;
using Pubs.Services.Places;

namespace Pubs.Services.Modules
{
    public static class IocBindings
    {
        public static void BindServices(this ServiceContainer container)
        {
            container.Register<IPlacesService, PlacesService>();
            container.Register<IQueryStringBuilder, QueryStringBuilder>();
        }
    }
}