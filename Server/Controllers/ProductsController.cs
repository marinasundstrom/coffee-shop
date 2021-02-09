using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Application.Products;
using App1.Application.Products.Queries;
using App1.Application.Products.Queries.GetAttributes;
using App1.Application.Products.Queries.GetProduct;
using App1.Application.Products.Queries.GetProducts;
using App1.Application.Products.Queries.GetProductVariants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ResponseCache(Duration = 60, VaryByQueryKeys = new[] { "categoryId" })]
        public async Task<IAsyncEnumerable<ProductDto>> GetProducts(int? categoryId = null)
        {
            return await mediator.Send(new GetProductsQuery(categoryId));
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 60, VaryByQueryKeys = new[] { "id" })]
        public async Task<ProductDto> GetProduct(int id)
        {
            return await mediator.Send(new GetProductQuery(id));
        }

        [HttpGet("{id}/Attributes")]
        [ResponseCache(Duration = 60, VaryByQueryKeys = new[] { "id" })]
        public async Task<IQueryable<ProductAttributeDto>> GetProductAttributes(int id)
        {
            return await mediator.Send(new GetAttributesQuery(id));
        }

        [HttpGet("{id}/Variants")]
        [ResponseCache(Duration = 60, VaryByQueryKeys = new[] { "id" })]
        public async Task<IQueryable<ProductVariantDto>> GetProductVariants(int id)
        {
            return await mediator.Send(new GetProductVariantsQuery(id));
        }
    }
}
