namespace App1.Client.Products
{
    public class ProductViewModel
    {
        public Product Product { get; set; } = null!;

        public int? SelectedVariantId { get; set; }
    }
}
