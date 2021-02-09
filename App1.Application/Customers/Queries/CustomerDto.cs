using App1.Application.Common;
using System.Collections.Generic;

namespace App1.Application.Customers.Queries
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string SSN { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public ICollection<AddressDto> Addresses { get; set; } = null!;

        public AddressDto BillingAddress { get; set; } = null!;

        public AddressDto ShippingAddress { get; set; } = null!;
    }
}