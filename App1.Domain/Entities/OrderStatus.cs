namespace App1.Domain.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}