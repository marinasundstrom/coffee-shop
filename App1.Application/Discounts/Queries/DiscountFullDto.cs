using App1.Application.Common;
using System;
using System.Collections.Generic;

namespace App1.Application.Discounts.Queries
{
    public class DiscountFullDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public IEnumerable<DiscountImageDto> Images { get; set; } = null!;

        /// <summary>
        /// The date when this offer starts.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The date on which this offer expires.
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        public decimal? FixedPrice { get; set; }

        /// <summary>
        /// The percentage to subtract from the total price of a shopping cart.
        /// </summary>
        public double? DiscountRate { get; set; }

        /// <summary>
        /// The amount to be subtract from the total price of a shopping cart.
        /// </summary>
        public decimal? DiscountAmount { get; set; }

        /// <summary>
        /// The Campaign that this Offer is part of.
        /// </summary>
        public CampaignShortDto? Campaign { get; set; }

        /// <summary>
        /// The Person to which this offer has been assigned.
        /// </summary>
        public PersonShortDto? Person { get; set; }

        public ContactShortDto? Contact { get; set; }

        public int? Quantity { get; set; }

        /// <summary>
        /// The number of times this offer has been used.
        /// </summary>
        public int TimesUsed { get; set; }

        /// <summary>
        /// Max times this offer can be used.
        /// </summary>
        public int? MaxTimes { get; set; } = 1;

        /// <summary>
        /// Offer code for offers that are not assigned to a specific person.
        /// </summary>
        public string? OfferCode { get; set; }
    }
}
