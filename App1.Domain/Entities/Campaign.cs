using System;
using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class Campaign
    {

        public Campaign()
        {
            //Contacts = new HashSet<Contact>();
            Offers = new HashSet<Discount>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? ImageId { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateThru { get; set; }

        //public ICollection<Contac>t Contacts { get; set; }

        public ICollection<Discount> Offers { get; set; }
    }
}
