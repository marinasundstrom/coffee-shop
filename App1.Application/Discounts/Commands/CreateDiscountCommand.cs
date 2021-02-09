using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App1.Application.Discounts.Commands
{
    public class CreateDiscountCommand : IRequest
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime? StartDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? CampaignId { get; set; }

        public int? PersonId { get; set; }

        public int? ContactId { get; set; }

        public decimal? FixedPrice { get; set; }

        public bool IsDiscountPrice { get; set; }

        public double? DiscountRate { get; set; }

        public decimal? DiscountAmount { get; set; }

        public int? Quota { get; set; } = null;

        public int? QuotaPerPerson { get; set; } = 1;

        /// <summary>
        /// Offer code for discounts that are not assigned to a specific person.
        /// </summary>
        public string? OfferCode { get; set; }

        public int? ProductId { get; set; }

        public int? ProductVariantId { get; set; }

        public int? CategoryId { get; set; }

        public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public CreateDiscountCommandHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
            {
                Campaign? campaign = null;
                if (request.CampaignId != null)
                {
                    campaign = await applicationDataContext.Campaigns.FindAsync(request.CampaignId);

                    if (campaign == null)
                    {
                        throw new Exception();
                    }
                }

                Product? product = await applicationDataContext.Products
                    .AsQueryable()
                    .Include(p => p.Variants)
                    .FirstAsync(p => p.Id == request.ProductId);

                ProductVariant? productVariant = null;
                if (product == null)
                {
                    throw new Exception();
                }
                else
                {
                    if (request.ProductVariantId != null)
                    {
                        productVariant = await applicationDataContext.ProductVariants
                        .AsQueryable()
                        .FirstOrDefaultAsync(p => p.Id == request.ProductVariantId);

                        if (productVariant == null)
                        {
                            throw new Exception();
                        }
                    }
                }

                ProductCategory? productCategory = null;

                if (request.CategoryId != null)
                {
                    productCategory = await applicationDataContext.ProductCategories.FindAsync(request.CategoryId);

                    if (productCategory == null)
                    {
                        throw new Exception();
                    }
                }

                Person? person = null;
                Contact? contact = null;

                if (request.PersonId != null)
                {
                    person = await applicationDataContext.Persons.FindAsync(request.PersonId);

                    if (person == null)
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    if (request.ContactId != null)
                    {
                        contact = await applicationDataContext.Contacts.FindAsync(request.ContactId);

                        if (contact == null)
                        {
                            throw new Exception();
                        }
                    }
                }

                applicationDataContext.Discounts.Add(new Discount()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Campaign = campaign!,
                    StartDate = request.StartDate,
                    ExpirationDate = request.ExpirationDate,
                    Person = person,
                    Contact = contact,
                    Product = product,
                    ProductVariant = productVariant,
                    Category = productCategory,
                    FixedPrice = request.FixedPrice,
                    //DiscountAmount = request.DiscountAmount,
                    //DiscountRate = request.DiscountRate
                });

                await applicationDataContext.SaveChangesAsync();

                return await Unit.Task;
            }
        }
    }
}
