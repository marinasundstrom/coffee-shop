using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace App1.Application.Products
{
    public class ProductListingService
    {
        private readonly ApplicationDataContext dataContext;
        private readonly IMapper mapper;

        public ProductListingService(ApplicationDataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async IAsyncEnumerable<ProductDto> GetProductsAsync(int? categoryId, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            // Get all the persons offers

            var shoppingCart = await dataContext.ShoppingCarts
                .Include(sc => sc.Discounts)
                .FirstOrDefaultAsync();

            Contact? contact = null;
            Person? person = null;

            // Iterate products and check for offer prices

            await foreach (var product in GetProductsCoreAsync(categoryId, cancellationToken))
            {
                yield return mapper.Map<ProductDto>(product);
            }
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var shoppingCart = await dataContext.ShoppingCarts
               .Include(sc => sc.Discounts)
               .FirstOrDefaultAsync();

            Contact? contact = null;
            Person? person = null;

            var product = await dataContext.Products
                .Include(p => p.Category)
                .Include(p => p.Variants)
                .Include("Images.Image")
                .FirstOrDefaultAsync(p => p.Id == id);

            return mapper.Map<ProductDto>(product);
        }

        private async IAsyncEnumerable<Product> GetProductsCoreAsync(int? categoryId, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (categoryId == null)
            {
                var products = dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Variants)
                    .Include("Images.Image")
                    .AsQueryable();

                foreach (var product in products)
                {
                    yield return product;
                }
            }
            else
            {
                var category = await dataContext.ProductCategories
                    .FirstOrDefaultAsync(c => c.Id == categoryId);

                if (category == null)
                {
                    throw new Exception();
                }

                await foreach (var product in GetProductsCore2Async(category))
                {
                    yield return product;
                }
            }
        }

        private async IAsyncEnumerable<Product> GetProductsCore2Async(ProductCategory category)
        {
            var products = dataContext.Products
                          .Include(p => p.Category)
                          .Include("Images.Image")
                          .Where(p => p.Category.Id == category.Id).AsQueryable();

            foreach (var product in products.AsQueryable())
            {
                yield return product;
            }

            await dataContext
                .Entry(category)
                .Collection(c => c.ChildCategories)
                .LoadAsync();

            foreach (var childCategory in category.ChildCategories)
            {
                await foreach (var productDto in GetProductsCore2Async(childCategory))
                {
                    yield return productDto;
                }
            }
        }
    }
}