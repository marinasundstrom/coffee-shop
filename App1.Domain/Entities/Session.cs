using System;
using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class Session
    {
        public Session()
        {
            Interactions = new HashSet<Interaction>();
        }

        public int Id { get; set; }

        public DateTime? DateStarted { get; set; }

        public Person? Person { get; set; }

        public Contact? Contact { get; set; }

        public string UserAgent { get; set; } = null!;

        public Rectangle ScreenResolution { get; set; } = null!;

        public Coordinates? Coordinates { get; set; } = null!;

        public ICollection<Interaction> Interactions { get; set; }
    }
}
