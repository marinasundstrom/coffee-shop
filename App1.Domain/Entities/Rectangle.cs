using Microsoft.EntityFrameworkCore;

namespace App1.Domain.Entities
{
    [Owned]
    public class Rectangle
    {
        public int Height { get; set; }

        public int Width { get; set; }
    }
}
