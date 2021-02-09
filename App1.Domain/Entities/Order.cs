using System;
using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class Order : IPersonData
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; } = null!;

        public Person Person { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? SSN { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public Address BillingAddress { get; set; } = null!;

        public Address ShippingAddress { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
