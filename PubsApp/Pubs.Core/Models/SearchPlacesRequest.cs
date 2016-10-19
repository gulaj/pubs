using System.ComponentModel.DataAnnotations;

namespace Pubs.Core.Models
{
    public class SearchPlacesRequest : Location
    {
        [Required]
        public decimal Radius { get; set; }
        [Required]
        public string Types { get; set; }
    }
}
