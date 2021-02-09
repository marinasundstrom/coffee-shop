using System;

namespace App1.Domain.Entities
{
    public class PersonProductFavorite
    {
        public int Id { get; set; }

        public Person Person { get; set; } = null!;

        public Product Product { get; set; } = null!;

        public DateTime DateAdded { get; set; }
    }
}
