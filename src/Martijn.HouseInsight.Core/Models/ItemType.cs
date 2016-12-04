using System.Collections.Generic;

namespace Martijn.HouseInsight.Core.Models
{
    public class ItemType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? RequiredAmount { get; set; }

        public bool? Obtained { get; set; }

        public virtual ItemPriority Priority { get; set; }

        public virtual ItemGroup Group { get; set; }

        public virtual ICollection<ItemTypeRoom> Rooms { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
