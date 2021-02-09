using System.ComponentModel.DataAnnotations;

namespace App1.Client.Admin.Categories
{
    public class CategoryViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
