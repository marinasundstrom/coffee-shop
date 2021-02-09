using System.Collections.Generic;

namespace App1.Tests
{
    public class ProductDto
    {
        public ProductDto()
        {
            Offers = new HashSet<OfferDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal OrdinaryPrice { get; set; }

        public string Currency { get; set; } = null!;

        public ICollection<ProductVariationDto> Variations { get; set; } = null!;

        public ICollection<OfferDto> Offers { get; set; } = null!;
    }

    public class ProductVariationDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<OfferDto> Offers { get; set; } = null!;
    }

    public class OfferDto
    {
        public string Name { get; set; } = null!;

        public decimal? OfferPrice { get; set; }

        public double? DiscountRate { get; set; }

        public decimal? DiscountAmount { get; set; }

        public List<ProductDto> BundledWith { get; set; } = null!;
    }
}