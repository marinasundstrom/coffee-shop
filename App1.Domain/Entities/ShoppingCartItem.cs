namespace App1.Domain.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public ShoppingCart? ShoppingCart { get; set; }

        public int? ShoppingCartId { get; set; }

        public Product Product { get; set; } = null!;

        public ProductVariant? ProductVariant { get; set; }

        public Discount? Discount { get; set; }

        public int Quantity { get; set; }
    }
}