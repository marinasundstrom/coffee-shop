using App1.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App1.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions options) : base(options)
        {
        }

#nullable disable
        public DbSet<Address2> Addresses { get; set; }

        public DbSet<Source> Sources { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<PersonDiscount> PersonDiscounts { get; set; }

        public DbSet<PersonProductFavorite> PersonProductFavorites { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Interaction> Interactions { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<EnumList> EnumLists { get; set; }

        public DbSet<EnumListValue> EnumListValues { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<OfferImage> OfferImages { get; set; }

        public DbSet<ProductAttributeGroup> ProductAttributeGroups { get; set; }

        public DbSet<ProductAttributeDefinition> ProductAttributeDefinitions { get; set; }

        public DbSet<ProductIntAttributeDefinition> ProductAttributeIntDefinitions { get; set; }

        public DbSet<ProductBoolAttributeDefinition> ProductAttributeBoolDefinitions { get; set; }

        public DbSet<ProductStringAttributeDefinition> ProductAttributeStringDefinitions { get; set; }

        public DbSet<ProductEnumAttributeDefinition> ProductAttributeEnumDefinitions { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public DbSet<ProductIntAttribute> ProductIntAttributes { get; set; }

        public DbSet<ProductBoolAttribute> ProductBoolAttributes { get; set; }

        public DbSet<ProductStringAttribute> ProductStringAttributes { get; set; }

        public DbSet<ProductEnumAttribute> ProductEnumAttributes { get; set; }

        public DbSet<ProductVariant> ProductVariants { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderStatus> OrderStatus { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<ShoppingCartDiscount> ShoppingCartOffers { get; set; }

        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<SubscriptionTerms> SubscriptionTerms { get; set; }

#nullable restore
    }
}
