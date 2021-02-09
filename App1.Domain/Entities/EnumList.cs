using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class EnumList
    {
        public EnumList()
        {
            Values = new List<EnumListValue>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<EnumListValue> Values { get; set; }
    }
}
