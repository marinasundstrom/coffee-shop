using System.Collections.Generic;

namespace App1.Domain.Entities
{

    public class Person : IPersonData
    {
        public Person()
        {
            Addresses = new HashSet<Address2>();
            UsedDiscounts = new HashSet<PersonDiscount>();
            TargetedOffers = new HashSet<Discount>();
            Orders = new HashSet<Order>();
            PersonProductFavorites = new HashSet<PersonProductFavorite>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int Id { get; set; }

        public string? CustomerNo { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? SSN { get; set; }

        public Organization? Organization { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public ICollection<Address2> Addresses { get; set; }

        public Address2 BillingAddress { get; set; } = null!;

        public Address2 ShippingAddress { get; set; } = null!;

        public ICollection<PersonDiscount> UsedDiscounts { get; set; }

        public ICollection<Discount> TargetedOffers { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<PersonProductFavorite> PersonProductFavorites { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
