using System.ComponentModel.DataAnnotations.Schema;

namespace App1.Domain.Entities
{
    public abstract class ProductAttribute
    {
        public int Id { get; set; }

        public int ProductAttributeDefinition { get; set; }

        public Product? Product { get; set; }

        public ProductVariant? ProductVariant { get; set; }

    }

    public class ProductIntAttribute : ProductAttribute
    {
        [ForeignKey(nameof(ProductAttributeDefinition))]
        public ProductIntAttributeDefinition Definition { get; set; } = null!;

        [Column("IntValue")]
        public int Value { get; set; }
    }

    public class ProductBoolAttribute : ProductAttribute
    {
        [ForeignKey(nameof(ProductAttributeDefinition))]
        public ProductBoolAttributeDefinition Definition { get; set; } = null!;

        [Column("BoolValue")]
        public bool Value { get; set; }
    }

    public class ProductStringAttribute : ProductAttribute
    {
        [ForeignKey(nameof(ProductAttributeDefinition))]
        public ProductStringAttributeDefinition Definition { get; set; } = null!;

        [Column("StringValue")]
        public string Value { get; set; } = null!;
    }

    public class ProductEnumAttribute : ProductAttribute
    {
        [ForeignKey(nameof(ProductAttributeDefinition))]
        public ProductEnumAttributeDefinition Definition { get; set; } = null!;

        [ForeignKey("EnumListValueId")]
        public EnumListValue Value { get; set; } = null!;
    }
}
