using System;
using System.ComponentModel.DataAnnotations;

namespace App1.Client.Admin.Discounts
{
    public class CreateDiscountFormViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public string DiscountCode { get; set; } = null!;

        public int? CampaignId { get; set; }

        public int? ProductId { get; set; }

        public int? ProductVariantId { get; set; }

        public int? ProductCategoryId { get; set; }

        public decimal FixedPrice { get; set; }

        public int? CurrencyId { get; set; }

        public double? DiscountRate { get; set; }

        public decimal? DiscountAmount { get; set; }

        public int? PersonId { get; set; }

        public int? ContactId { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? ExpirationDate { get; set; }
    }
}
