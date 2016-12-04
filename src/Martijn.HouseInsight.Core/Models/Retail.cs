using System.Collections.Generic;

namespace Martijn.HouseInsight.Core.Models
{
    public class Retail
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public virtual ICollection<GeoPosition> Locations { get; set; }

        public virtual ICollection<RetailProduct> RetailProducts { get; set; }
    }
}
