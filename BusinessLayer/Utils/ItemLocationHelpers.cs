using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utils
{
    public static class ItemLocationHelpers
    {
        public static bool LocationIntersects(Location givenLocation, Location itemLocation)
        {
            double distance = CalculateDistance(givenLocation.Latitude, givenLocation.Longitude, itemLocation.Latitude, itemLocation.Longitude);
            return distance <= givenLocation.RadiusMeters;
        }

        private static double CalculateDistance(float lat1, float lon1, float lat2, float lon2)
        {
            const double EarthRadius = 6371000;

            double dLat = DegreeToRadian(lat2 - lat1);
            double dLon = DegreeToRadian(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreeToRadian(lat1)) * Math.Cos(DegreeToRadian(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadius * c;
        }

        private static double DegreeToRadian(double degree)
        {
            return degree * (Math.PI / 180);
        }
    }
}
