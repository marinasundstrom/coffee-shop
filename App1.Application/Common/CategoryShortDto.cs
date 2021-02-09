namespace App1.Application.Common
{
    public class CategoryShortDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public CategoryShortDto? Parent { get; set; }
    }
}
