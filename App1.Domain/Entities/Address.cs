using Microsoft.EntityFrameworkCore;

namespace App1.Domain.Entities
{

    [Owned]
    public class Address : IAddress
    {
        public string StreetAddress { get; set; } = null!;

        public string StreetNumber { get; set; } = null!;

        public string? ApartmentNumber { get; set; } = null!;

        public string ZipCode { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? State { get; set; } = null!;

        public string? Country { get; set; } = null!;
    }
}
