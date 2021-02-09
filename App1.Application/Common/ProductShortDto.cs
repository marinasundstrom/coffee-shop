namespace App1.Application.Common
{
    public class ProductShortDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal? CompareAtPrice { get; set; }
    }
}
