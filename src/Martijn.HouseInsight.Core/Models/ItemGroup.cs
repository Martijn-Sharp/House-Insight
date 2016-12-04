using System.Collections.Generic;

namespace Martijn.HouseInsight.Core.Models
{
    public class ItemGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ItemType> ItemTypes { get; set; }
    }
}
