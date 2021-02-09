using System;

namespace App1.Domain.Entities
{
    public class Interaction
    {
        public int Id { get; set; }

        public Session Session { get; set; } = null!;

        public DateTime? Timestamp { get; set; }

        public string Url { get; set; } = null!;

        public Product? Product { get; set; }

        public Discount? Offer { get; set; }
    }
}
