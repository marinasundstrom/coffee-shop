namespace App1.Domain.Entities
{
    public class OfferImage
    {
        public int Id { get; set; }

        public Discount? Offer { get; set; } = null!;

        public Image Image { get; set; } = null!;

        public string? Text { get; set; }
    }
}
