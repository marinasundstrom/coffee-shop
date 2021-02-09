using System;

namespace App1.Client
{
    public class AppState
    {
        private int noOfItemsInShoppingCart = -1;

        public int NoOfItemsInShoppingCart
        {
            get => noOfItemsInShoppingCart;
            set
            {
                noOfItemsInShoppingCart = value;
                ShoppingCartUpdated?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? ShoppingCartUpdated;
    }
}
