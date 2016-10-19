using Pubs.Core.Abstract.Places;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pubs.WebApi.Controllers
{
    [RoutePrefix("api/Location")]
    public class LocationController : ApiController
    {
        private IPlacesService _placeService;

        public LocationController(IPlacesService placeService)
        {
            _placeService = placeService;
        }

        [Route("DefaultLocation")]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _placeService.GetDefaultLocationAsync();

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
