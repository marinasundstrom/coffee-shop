using App1.Application.Common;
using App1.Application.Products.Queries;
using App1.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace App1.Application.Products
{
    public class ProductDto
    {
        public ProductDto()
        {
            Images = new HashSet<ImageDto>();
            Variants = new HashSet<ProductVariantDto>();
        }

        public int Id { get; set; }

        public string? SKU { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public CategoryShortDto Category { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal? CompareAtPrice { get; set; }

        public decimal? CostPerItem { get; set; }

        public string? VariantsTitle { get; set; }

        public ICollection<ImageDto> Images { get; set; } = null!;

        public ICollection<ProductVariantDto> Variants { get; set; }
    }
}