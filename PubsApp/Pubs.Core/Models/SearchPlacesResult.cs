using System.Collections;

namespace Pubs.Core.Models
{
    public class SearchPlacesResult
    {
        public IList Html_Attributions { get; set; }

        public string Status { get; set; }

        public IList Results { get; set; }
    }
}
