using Pubs.Core.Abstract.Places;
using Pubs.Core.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pubs.WebApi.Controllers
{
    [RoutePrefix("api/Places")]
    public class GooglePlacesController : ApiController
    {
        private IPlacesService _placeService;

        public GooglePlacesController(IPlacesService placeService)
        {
            _placeService = placeService;
        }

        [Route("Find/Nearest/{Types}/lat/{Latitude}/lng/{Longitude}/radius/{Radius}")]
        [Route("Find/Nearest")]
        public async Task<IHttpActionResult> Get([FromUri]SearchPlacesRequest model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _placeService.SearchNearByAsync(model);

            if (result != null || result.Count > 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        //[Route("DefaultLocation")]
        //public async Task<IHttpActionResult> Get()
        //{
        //    var result = await _placeService.GetDefaultLocationAsync();

        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound();
        //}

    }
}
