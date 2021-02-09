using System;
using System.ComponentModel.DataAnnotations;

namespace App1.Client.Common
{
    public class Address
    {
        [Required]
        public string StreetAddress { get; set; } = null!;

        [Required]
        public string StreetNumber { get; set; } = null!;

        [Required]
        public string? ApartmentNumber { get; set; }

        [Required]
        public string ZipCode { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        public string? State { get; set; }

        public string? Country { get; set; }
    }
}
