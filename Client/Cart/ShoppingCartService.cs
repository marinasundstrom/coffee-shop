using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Client.Cart
{
    public class ShoppingCartService
    {
        private readonly IShoppingCartClient shoppingCartClient;
        private readonly List<ShoppingCartItem> items = new List<ShoppingCartItem>();

        public ShoppingCartService(IShoppingCartClient ShoppingCartClient)
        {
            shoppingCartClient = ShoppingCartClient;
        }

        public IEnumerable<ShoppingCartItem> Items => items;

        public async Task InitializeAsync()
        {
            ShoppingCart? cart = await shoppingCartClient.GetShoppingCartAsync();

            items.Clear();

            foreach (ShoppingCartItem? item in cart.Items)
            {
                items.Add(item);
            }

            CartUpdated?.Invoke(this, EventArgs.Empty);
        }

        public async Task AddItemAsync(int? productId, int? productVariantId, int? offerId, int? priceId, int quantity = 1)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            ShoppingCartItem? item = await shoppingCartClient.AddShoppingCartItemAsync(productId, productVariantId, offerId, priceId, quantity);

            ShoppingCartItem? item2 = items.FirstOrDefault(i => i.Id == item.Id);
            if (item2 == null)
            {
                items.Add(item);
            }
            else
            {
                int index = items.TakeWhile(i => i.Id != item.Id).Count();
                items[index] = item;
            }

            CartUpdated?.Invoke(this, EventArgs.Empty);
        }

        public async Task UpdateItemQuantityAsync(int itemId, int quantity)
        {
            await shoppingCartClient.UpdateItemQuantityAsync(itemId, quantity);

            ShoppingCartItem? item = items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                if (quantity == 0)
                {
                    items.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
            }

            CartUpdated?.Invoke(this, EventArgs.Empty);
        }

        public async Task RemoveItemAsync(int itemId)
        {
            await shoppingCartClient.RemoveShoppingCartItemAsync(itemId);

            ShoppingCartItem? item = items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                items.Remove(item);
            }

            CartUpdated?.Invoke(this, EventArgs.Empty);
        }

        public async Task<(decimal total, decimal subTotal)> GetPriceAsync()
        {
            ShoppingCartPrice? item = await shoppingCartClient.GetPriceAsync();

            return (item.Total, item.SubTotal);
        }

        public async Task ClearAsync()
        {
            await shoppingCartClient.ClearShoppingCartAsync();
            items.Clear();
            CartUpdated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler? CartUpdated;
    }
}
