using System.Collections.Generic;

namespace Martijn.HouseInsight.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<RetailProduct> RetailProducts { get; set; }

        public virtual ItemType ItemType { get; set; }
    }
}
