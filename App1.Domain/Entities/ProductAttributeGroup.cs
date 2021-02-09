using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class ProductAttributeGroup
    {
        public ProductAttributeGroup()
        {
            ProductAttributeDefinitions = new HashSet<ProductAttributeDefinition>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<ProductAttributeDefinition> ProductAttributeDefinitions { get; set; }
    }
}