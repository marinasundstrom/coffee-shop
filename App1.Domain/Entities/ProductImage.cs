namespace App1.Domain.Entities
{

    public class ProductImage
    {
        public int Id { get; set; }

        public Product? Product { get; set; } = null!;

        public ProductVariant? ProductVariant { get; set; } = null!;

        public Image Image { get; set; } = null!;

        public string? Text { get; set; }
    }
}
