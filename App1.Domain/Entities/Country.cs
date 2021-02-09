namespace App1.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string NativeName { get; set; } = null!;
    }
}