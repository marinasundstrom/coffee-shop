using App1.Data;
using App1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Application.Products
{
    public class DiscountService
    {
        private readonly ApplicationDataContext dataContext;

        public DiscountService(ApplicationDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IEnumerable<Discount>> GetGeneralOffersAsync()
        {
            Contact? contact = null;
            Person? person = null;

            var offers = await dataContext.Discounts
               .Include(x => x.Person)
               .Include(x => x.Contact)
               .Include("Category")
               .Where(o => (o.Person == null && o.Contact == null) || (o.Person == person || o.Contact == contact))
               .ToArrayAsync();

            return offers
                 .Where(x => x.Person == null & x.Contact == null)
                 .Where(o => o.Product == null && o.Category == null);
        }

        public async Task<IEnumerable<Discount>> GetOffersAsync(IEnumerable<ShoppingCartDiscount> shoppingCartDiscounts, Product product)
        {
            return shoppingCartDiscounts
               .Select(i => i.Discount)
               .Where(o => (o.Product != null && o.Product == product) || (o.Category != null && o.Category == product.Category));
        }

        public async Task<IEnumerable<Discount>> GetOffersAsync(IEnumerable<ShoppingCartDiscount> shoppingCartDiscounts, ProductVariant productVariant)
        {
            return shoppingCartDiscounts
               .Select(i => i.Discount)
               .Where(o => o.Product != null && o.ProductVariant == productVariant);
        }
    }
}