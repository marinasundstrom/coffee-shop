using App1.Application.Common;
using System.Collections.Generic;

namespace App1.Application.Contacts.Queries
{
    public class ContactDto
    {
        public int Id { get; set; }

        public SourceShortDto? Source { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string SSN { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public AddressDto Address { get; set; } = null!;

        public string OfferCode { get; set; } = null!;

        public CampaignShortDto? Campaign { get; set; }
    }
}