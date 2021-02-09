using System;

namespace App1.Domain.Entities
{
    public class SubscriptionTerms
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public TimeSpan TermOfNotice { get; set; }
    }
}