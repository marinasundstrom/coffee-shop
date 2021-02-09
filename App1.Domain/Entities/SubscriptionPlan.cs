namespace App1.Domain.Entities
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Product Product { get; set; } = null!;

        public BillingCycle BillingCycle { get; set; }

        public decimal? Price { get; set; } = null!;

        public SubscriptionTerms SubscriptionTerms { get; set; } = null!;
    }
}