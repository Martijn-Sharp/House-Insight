namespace Martijn.HouseInsight.Core.Models
{
    public class GeoPosition
    {
        public int Id { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public virtual Retail Retail { get; set; }
    }
}
