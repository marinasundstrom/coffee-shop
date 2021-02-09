namespace App1.Application.Categories.Queries
{
    public class ParentCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}