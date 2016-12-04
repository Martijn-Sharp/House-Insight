using Martijn.HouseInsight.Core.Models;

namespace Martijn.HouseInsight.EntityFramework.Tests
{
    public static class DefaultModelInstances
    {
        public static GeoPosition CreateGeoPosition()
        {
            return new GeoPosition { Latitude = 51.9191412m, Longitude = 4.185774m };
        }

        public static Retail CreateRetail()
        {
            return new Retail { Name = "Entitymarket" };
        }
    }
}
