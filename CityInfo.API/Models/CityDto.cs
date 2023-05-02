using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; }
        public int NumberOfPointsOfInterest { get; set; }

        //public ICollection<PointOfInterestDto> pointsOfInterest();
    }
}
