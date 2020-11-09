using System;
using System.Collections.Generic;

namespace lab2
{
    public class AllShops
    {
        private readonly Dictionary<int, Shop> _shops = new Dictionary<int, Shop>();

        public void AddStore(Shop store)
        {
            _shops.Add(store.Id, store);
        }

        public Shop FindProductLowPrice(Product product)
        {
            Shop needfulShop = new Shop();
            int minPrice = 0;
            foreach (var store in _shops.Values)
            {
                if (store.Range.ContainsKey(product.Id) &&
                    (store.Range[product.Id].Price < minPrice || minPrice == 0))
                {
                    minPrice = store.Range[product.Id].Price;
                    needfulShop = store;
                }
            }

            return needfulShop;
        }

        public Shop FindBatchLowPrice(IEnumerable<InInfo> order)
        {
            Shop needfulShop = new Shop();
            int minPrice = 0;
            foreach (var store in _shops.Values)
            {
                int sumPrice;
                try
                { 
                    sumPrice = store.BuyBatch(order, false);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " " + store.Name);
                    continue;
                }
                if (minPrice == 0 || sumPrice < minPrice)
                {
                    minPrice = sumPrice;
                    needfulShop = store;
                }
            }

            return needfulShop;
        }

    }
}