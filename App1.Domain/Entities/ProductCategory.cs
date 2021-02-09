using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            ChildCategories = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
            ProductAttributeGroups = new HashSet<ProductAttributeGroup>();
            ProductAttributeDefinition = new HashSet<ProductAttributeDefinition>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public ProductCategory? Parent { get; set; } = null!;

        public ICollection<ProductCategory> ChildCategories { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<ProductAttributeGroup> ProductAttributeGroups { get; set; }

        public ICollection<ProductAttributeDefinition> ProductAttributeDefinition { get; set; }
    }
}
