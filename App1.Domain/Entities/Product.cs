using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Images = new HashSet<ProductImage>();
            Attributes = new HashSet<ProductAttribute>();
            Variants = new HashSet<ProductVariant>();
            SubscriptionPlans = new HashSet<SubscriptionPlan>();
        }

        public int Id { get; set; }

        public string? SKU { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsService { get; set; }

        public bool HasSubscription { get; set; }

        public ICollection<ProductImage> Images { get; set; }

        public ProductCategory Category { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal? CompareAtPrice { get; set; }

        public decimal? CostPerItem { get; set; }

        public string? VariantsTitle { get; set; } = null!;

        public ICollection<ProductAttribute> Attributes { get; set; }

        public ICollection<ProductVariant> Variants { get; set; }

        public ICollection<SubscriptionPlan> SubscriptionPlans { get; set; }
    }
}
