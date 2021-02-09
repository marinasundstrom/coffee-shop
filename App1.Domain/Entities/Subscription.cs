using System;

namespace App1.Domain.Entities
{
    public class Subscription
    {
        public int Id { get; set; }

        public Person Person { get; set; } = null!;

        public SubscriptionPlan SubscriptionPlan { get; set; } = null!;

        public DateTime IntroductionDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? RenewalDate { get; set; }

        public DateTime? EndDate { get; set; }

        public SubscriptionStatus Status { get; set; }
    }
}