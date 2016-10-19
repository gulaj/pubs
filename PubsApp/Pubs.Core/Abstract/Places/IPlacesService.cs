using Pubs.Core.Models;
using System.Collections;
using System.Threading.Tasks;

namespace Pubs.Core.Abstract.Places
{
    public interface IPlacesService
    {
        Task<IList> SearchNearByAsync(SearchPlacesRequest model);
        Task<Location> GetDefaultLocationAsync();

    }
}
