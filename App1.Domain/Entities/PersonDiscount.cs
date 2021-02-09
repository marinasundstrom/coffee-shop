using System;

namespace App1.Domain.Entities
{
    public class PersonDiscount
    {
        public int Id { get; set; }

        public Person Person { get; set; } = null!;

        public Discount Discount { get; set; } = null!;

        public DateTime DateUsed { get; set; }
    }
}
