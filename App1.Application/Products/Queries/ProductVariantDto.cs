using App1.Application.Common;

namespace App1.Application.Products.Queries
{
    public class ProductVariantDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal? CompareAtPrice { get; set; }
    }
}