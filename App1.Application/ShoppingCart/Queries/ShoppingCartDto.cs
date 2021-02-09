using System.Collections;
using System.Collections.Generic;

namespace App1.Application.ShoppingCart.Queries
{
    public class ShoppingCartDto
    {
        public IEnumerable<ShoppingCartItemDto> Items { get; set; } = null!;

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }
    }
}