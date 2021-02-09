using App1.Application.Common;
using App1.Application.Products.Queries;

namespace App1.Application.ShoppingCart.Queries
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }

        public ProductShortDto? Product { get; set; }

        public ProductVariantDto? ProductVariant { get; set; }

        public DiscountShortDto? Discount { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}