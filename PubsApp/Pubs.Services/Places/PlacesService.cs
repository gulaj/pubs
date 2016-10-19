using Pubs.Core.Abstract.Builders;
using Pubs.Core.Abstract.Places;
using Pubs.Core.Models;
using Pubs.Services.Properties;
using System;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pubs.Services.Places
{
    public class PlacesService : IPlacesService
    {
        
        private IQueryStringBuilder _queryStringBuilder;
        public PlacesService(IQueryStringBuilder queryStringBuilder)
        {
            _queryStringBuilder = queryStringBuilder;
        }

        public async Task<Location> GetDefaultLocationAsync() => new Location
        {
            Latitude = Settings.Default.GoogleDefaultLatitude,
            Longitude =Settings.Default.GoogleDefaultLongitude,
        };

        public async Task<IList> SearchNearByAsync(SearchPlacesRequest model)
        {
            var parameters = _queryStringBuilder
               .SetLocation(model)
               .SetRadius(model.Radius)
               .SetTypes(model.Types)
               .Build();


            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(Settings.Default.GooglePlacesApiUri + Settings.Default.GoogleNearBySearch)
            };

            HttpResponseMessage response = httpClient.GetAsync(parameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<SearchPlacesResult>();
                return result.Results;
            }

            return null;
        }

    }
}
