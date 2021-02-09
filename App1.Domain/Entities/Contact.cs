using System.Collections.Generic;

namespace App1.Domain.Entities
{

    public class Contact 
    {
        public Contact()
        {
            Offers = new HashSet<Discount>();
        }

        public int Id { get; set; } 

        public Source? Source { get; set; } 

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string SSN { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public Address Address { get; set; } = null!;

        public string OfferCode { get; set; } = null!;

        public Campaign? Campaign { get; set; }

        public ICollection<Discount> Offers { get; set; }
    }
}