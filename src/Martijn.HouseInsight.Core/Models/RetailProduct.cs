using System;

namespace Martijn.HouseInsight.Core.Models
{
    public class RetailProduct
    {
        public decimal? Price { get; set; }

        public string Link { get; set; }

        public DateTime? LastUpdated { get; set; }

        public bool? IsDiscount { get; set; }

        public int RetailId { get; set; }

        public virtual Retail Retail { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
