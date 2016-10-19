using Pubs.Core.Abstract.Builders;
using Pubs.Core.Models;
using Pubs.Services.Properties;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Pubs.Services.Builders
{
    public class QueryStringBuilder : IQueryStringBuilder
    {
        private Dictionary<string, string> _queryStringParams;
        private string _queryString = "json?";
        private const string LocationPattern = "{0},{1}";
        private const string parametersPattern = "{0}={1}";

        public QueryStringBuilder()
        {
            _queryStringParams = new Dictionary<string, string>
            {
                {"key", Settings.Default.GooglePlacesApiKey},
            };
        }

        public IQueryStringBuilder SetLocation(Location location)
        {
            if (location != null)
            {
                _queryStringParams.Add("location", string.Format(CultureInfo.InvariantCulture, LocationPattern, location.Latitude, location.Longitude));
            }
            return this;
        }

        public IQueryStringBuilder SetRadius(decimal radius)
        {
            _queryStringParams.Add("radius", radius.ToString());
            return this;
        }

        public IQueryStringBuilder SetTypes(string types)
        {
            if (types != null && types.Any())
            {
                _queryStringParams.Add("types",types);
            }
            return this;
        }

        public string Build() =>
            _queryString + string.Join("&", _queryStringParams.Select(
                    p => string.Format(parametersPattern,
                        HttpUtility.UrlEncode(p.Key),
                        HttpUtility.UrlEncode(p.Value))));


    }
}
