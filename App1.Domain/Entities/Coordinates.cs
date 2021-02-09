using Microsoft.EntityFrameworkCore;

namespace App1.Domain.Entities
{
    [Owned]
    public class Coordinates
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
