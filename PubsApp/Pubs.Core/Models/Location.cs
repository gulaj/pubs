using System.ComponentModel.DataAnnotations;

namespace Pubs.Core.Models
{
    public class Location
    {
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        public decimal Latitude { get; set; }
    }
}
