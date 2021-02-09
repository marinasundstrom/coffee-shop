using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using NJsonSchema.Converters;

namespace App1.Application.Products.Queries
{
    [KnownType(typeof(ProductIntAttributeDto))]
    [KnownType(typeof(ProductBoolAttributeDto))]
    [KnownType(typeof(ProductStringAttributeDto))]
    [KnownType(typeof(ProductEnumAttributeDto))]
    [JsonConverter(typeof(JsonInheritanceConverter))]
    public class ProductAttributeDto
    {
        public int Id { get; set; }

        public int ProductAttributeDefinition { get; set; }

        public string Name { get; set; } = null!;
    }
}
