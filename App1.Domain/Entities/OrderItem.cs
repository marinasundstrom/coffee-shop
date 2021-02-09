namespace App1.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public Product? Product { get; set; } = null!;

        public int? ProductId { get; set; }

        public ProductVariant? ProductVariant { get; set; } = null!;

        public int? ProductVariantId { get; set; }

        public Discount? Discount { get; set; } = null!;

        public int? DiscountId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Currency { get; set; }

        public int Quantity { get; set; }
    }
}
