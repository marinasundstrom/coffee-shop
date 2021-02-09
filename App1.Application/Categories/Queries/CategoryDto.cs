using System.Collections.Generic;

namespace App1.Application.Categories.Queries
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public ParentCategoryDto? Parent { get; set; }

        public IEnumerable<CategoryDto>? ChildCategories { get; set; }
    }
}