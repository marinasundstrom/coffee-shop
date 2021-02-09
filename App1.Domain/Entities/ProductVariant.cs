using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App1.Domain.Entities
{
    public class ProductVariant
    {
        public ProductVariant()
        {
            Images = new HashSet<ProductImage>();
        }

        public int Id { get; set; }

        public Product Product { get; set; } = null!;

        public int ProductId { get; set; }

        public string SKU { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<ProductImage> Images { get; set; }

        public decimal Price { get; set; }

        public decimal? CompareAtPrice { get; set; }

        public decimal? CostPerItem { get; set; }
    }
}
