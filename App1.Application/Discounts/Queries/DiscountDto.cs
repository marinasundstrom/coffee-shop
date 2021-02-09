using System;
using System.Collections.Generic;
using App1.Application.Common;
using App1.Application.Products;
using App1.Application.Products.Queries;

namespace App1.Application.Discounts.Queries
{
    public class DiscountDto
    {
        public DiscountDto()
        {
            Images = new HashSet<ImageDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<ImageDto> Images { get; set; }

        /// <summary>
        /// The date when this discount starts.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The date on which this discount expires.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// The Campaign that this discount is part of.
        /// </summary>
        public CampaignShortDto? Campaign { get; set; }

        /// <summary>
        /// The Person to which this discount has been assigned.
        /// </summary>
        public PersonShortDto? Person { get; set; }

        public ContactShortDto? Contact { get; set; }

        public decimal? FixedPrice { get; set; }

        public bool IsDiscountPrice { get; set; }

        public double? DiscountRate { get; set; }

        public decimal? DiscountAmount { get; set; }

        public int? Quota { get; set; } = null;

        public string? DiscountCode { get; set; }

        public ProductShortDto? Product { get; set; }

        public ProductVariantShortDto? ProductVariant { get; set; }

        public CategoryShortDto? Category { get; set; }
    }
}
