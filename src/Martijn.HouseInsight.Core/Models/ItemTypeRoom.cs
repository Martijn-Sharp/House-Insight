namespace Martijn.HouseInsight.Core.Models
{
    /// <summary>Join table entity</summary>
    public class ItemTypeRoom
    {
        public int ItemTypeId { get; set; }

        public virtual ItemType ItemType { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
