using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class Source
    {
        public Source()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<Contact> Contacts { get; set; }
    }
}