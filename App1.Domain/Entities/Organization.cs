using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class Organization
    {
        public Organization()
        {
            Persons = new HashSet<Person>();
        }

        public int Id { get; set; }

        public string? CustomerNo { get; set; }

        public string Name { get; set; } = null!;

        public string OrgNo { get; set; } = null!;

        public string VatNo { get; set; } = null!;

        public ICollection<Person> Persons { get; set; }
    }
}
