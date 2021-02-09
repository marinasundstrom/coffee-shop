using App1.Application.Common;

namespace App1.Application.Products.Queries
{
    public class ProductImageDto
    {
        public int Id { get; set; }

        public ImageDto Image { get; set; } = null!;

        public string? Text { get; set; } = null!;
    }
}