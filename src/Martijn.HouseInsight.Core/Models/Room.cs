using System.Collections.Generic;

namespace Martijn.HouseInsight.Core.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ItemTypeRoom> ItemTypes { get; set; }
    }
}
