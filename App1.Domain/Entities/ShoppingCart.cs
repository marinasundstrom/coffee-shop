using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Items = new HashSet<ShoppingCartItem>();
            Discounts = new HashSet<ShoppingCartDiscount>();
        }

        public int Id { get; set; }

        public Session? Session { get; set; }

        public ICollection<ShoppingCartItem> Items { get; set; } = null!;

        public ICollection<ShoppingCartDiscount> Discounts { get; set; } = null!;
    }
}