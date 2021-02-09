using System.Collections.Generic;

namespace App1.Domain.Entities
{
    public class ProductAttributeDefinition
    {
        public ProductAttributeDefinition()
        {
            ProductAttributes = new HashSet<ProductAttribute>();
        }

        public int Id { get; set; }

        public ProductAttributeGroup? ProductAttributeGroup { get; set; }

        public ProductCategory? ProductCategory { get; set; }

        public Product? Product { get; set; }

        public ProductVariant? ProductVariant { get; set; }

        public string Name { get; set; } = null!;

        public DataType DataType { get; set; }

        public ICollection<ProductAttribute> ProductAttributes { get; set; }
    }

    public class ProductIntAttributeDefinition : ProductAttributeDefinition
    {
        public int MinValue { get; set; }

        public int MaxValue { get; set; }
    }

    public class ProductBoolAttributeDefinition : ProductAttributeDefinition
    {

    }

    public class ProductStringAttributeDefinition : ProductAttributeDefinition
    {

    }

    public class ProductEnumAttributeDefinition : ProductAttributeDefinition
    {
        public EnumList EnumList { get; set; } = null!;
    }
}
