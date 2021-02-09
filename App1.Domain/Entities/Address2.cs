using System.ComponentModel.DataAnnotations.Schema;

namespace App1.Domain.Entities
{
    public class Address2 : IAddress
    {
        public int Id { get; set; }

        /*
        public Person Person { get; set; } = null!;

        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        */

        public string StreetAddress { get; set; } = null!;

        public string StreetNumber { get; set; } = null!;

        public string? ApartmentNumber { get; set; } = null!;

        public string ZipCode { get; set; } = null!;

        public string City { get; set; } = null!;

        public string? State { get; set; } = null!;

        public string? Country { get; set; } = null!;
    }
}
