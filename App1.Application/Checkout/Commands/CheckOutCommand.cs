using App1.Application.Common;
using App1.Data;
using App1.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App1.Application.Checkout.Commands
{
    public class CheckOutCommand : IRequest
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string SSN { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public AddressDto BillingAddress { get; set; } = null!;

        public AddressDto ShippingAddress { get; set; } = null!;

        public class CheckoutCommandHandler : IRequestHandler<CheckOutCommand>
        {
            private readonly ApplicationDataContext applicationDataContext;
            private readonly IMapper mapper;

            public CheckoutCommandHandler(ApplicationDataContext applicationDataContext, IMapper mapper)
            {
                this.applicationDataContext = applicationDataContext;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(CheckOutCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.ShoppingCart? shoppingCart = await applicationDataContext
                    .ShoppingCarts
                    .Include(sc => sc.Items)
                    .ThenInclude(sci => sci.Product)
                    .Include(sci => sci.Items)
                    .ThenInclude(sci => sci.ProductVariant)
                    .FirstAsync();

                Person? person = await applicationDataContext.Persons
                    .Include(sc => sc.UsedDiscounts)
                    .FirstAsync();

                Order? order = new Order
                {
                    OrderDate = DateTime.Now,
                    Status = await applicationDataContext.OrderStatus.FirstAsync()
                };

                order = mapper.Map(request, order);

                order.Person = person;

                applicationDataContext.Orders.Add(order);

                foreach (ShoppingCartItem item in shoppingCart.Items)
                {
                    OrderItem? orderItem = new OrderItem
                    {
                        Product = item.Product,
                        ProductVariant = item.ProductVariant,

                        Name = item.ProductVariant?.Name ?? item!.Product.Name,
                        Description = item.ProductVariant?.Description ?? item!.Product.Description,

                        Quantity = item.Quantity
                    };

                    order.OrderItems.Add(orderItem);

                    if (item.Discount != null)
                    {
                        person.UsedDiscounts.Add(new PersonDiscount()
                        {
                            Person = person,
                            Discount = item.Discount,
                            DateUsed = DateTime.Now
                        });
                    }
                }

                await applicationDataContext.SaveChangesAsync();

                shoppingCart = await applicationDataContext
                  .ShoppingCarts
                  .Include(sc => sc.Items)
                  .FirstAsync();

                foreach (ShoppingCartItem? item in shoppingCart.Items.ToArray())
                {
                    applicationDataContext.ShoppingCartItems.Remove(item);
                }

                await applicationDataContext.SaveChangesAsync();

                return await Unit.Task;
            }
        }
    }
}
