using System;
using System.Collections.Generic;

namespace lab2
{
    public class Shop
    {
        private string _name, _address;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public Dictionary<int, ProductInfo> Range
        {
            get => _range;
            set => _range = value;
        }

        private int _id;
        private Dictionary<int, ProductInfo> _range;

        public Shop(int id = 0, string name = "", string address = "")
        {
            _name = name;
            _address = address;
            _id = id;
            _range = new Dictionary<int, ProductInfo>();
        }

        public void AddProduct(Product product, int count, int price)
        {
            if (_range.ContainsKey(product.Id))
            {
                _range[product.Id].Count += count;
                _range[product.Id].Price = price;
            }
            else
            {
                _range.Add(product.Id, new ProductInfo(product, count, price));
            }
        }

        public void AddProduct(ProductInfo productInfo)
        {
            if (_range.ContainsKey(productInfo.Product.Id))
            {
                _range[productInfo.Product.Id].Count += productInfo.Count;
                _range[productInfo.Product.Id].Price = productInfo.Price;
            }
            else
            {
                _range.Add(productInfo.Product.Id, productInfo);
            }
        }

        public List<OutInfo> HowMuchICanBuy(int amount)
        {
            string answer = "";
            List<OutInfo> outs = new List<OutInfo>();
            foreach (var product in _range.Values)
            {
                int maxNeed = amount / product.Price;
                if (maxNeed == 0)
                {
                    answer += "Can't buy one " + product.Product.Name + " or ";
                    outs.Add(new OutInfo(product.Product.Name, 0));
                }
                else
                {
                    answer += Math.Min(maxNeed, product.Count) + " " + product.Product.Name + " or ";
                    outs.Add(new OutInfo(product.Product.Name, Math.Min(maxNeed, product.Count)));
                }
            }

            if (answer.Length > 3)
            {
                answer = answer.Remove(answer.Length - 3);
            }

            return outs;
        }

        public int BuyBatch(IEnumerable<InInfo> order)
        {
            var priceSum = 0;
            foreach (var item in order) {
                if (!_range.ContainsKey(item.Id))
                    throw new InvalidId("No product with this id");
                if (_range[item.Id].Count < item.Count)
                    throw new NotEnough("Count Ex");
                priceSum += _range[item.Id].Price * item.Count;
            }

            return priceSum;
        }
    }
}