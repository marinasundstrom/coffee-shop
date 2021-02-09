namespace App1.Domain.Entities
{
    public class ShoppingCartDiscount
    {
        public int Id { get; set; }

        public ShoppingCart ShoppingCart { get; set; } = null!;

        public Discount Discount { get; set; } = null!;
    }
}