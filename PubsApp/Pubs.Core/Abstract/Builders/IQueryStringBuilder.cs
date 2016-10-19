using Pubs.Core.Models;

namespace Pubs.Core.Abstract.Builders
{
    public interface IQueryStringBuilder
    {
        string Build();
        IQueryStringBuilder SetLocation(Location location);
        IQueryStringBuilder SetRadius(decimal radius);
        IQueryStringBuilder SetTypes(string types);
    }
}