using System;
using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class Discount
    {
        public Discount()
        {
            Images = new HashSet<OfferImage>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public ICollection<OfferImage> Images { get; set; }

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
        public Campaign? Campaign { get; set; }

        /// <summary>
        /// The Person to which this discount has been assigned.
        /// </summary>
        public Person? Person { get; set; }

        public int? PersonId { get; set; }

        public Contact? Contact { get; set; }

        public int? ContactId { get; set; }

        public decimal? FixedPrice { get; set; }

        public bool IsDiscountPrice { get; set; }

        public double? DiscountRate { get; set; }

        public decimal? DiscountAmount { get; set; }

        public int? Quota { get; set; } = null;

        public string? DiscountCode { get; set; }

        public Product? Product { get; set; }

        public int? ProductId { get; set; }

        public ProductVariant? ProductVariant { get; set; }

        public int? ProductVariantId { get; set; }

        public ProductCategory? Category { get; set; }

        public int? CategoryId { get; set; }
    }
}
