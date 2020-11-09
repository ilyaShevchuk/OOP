namespace lab2
{
    public class ProductInfo
    {
        public Product Product { get; }
        public int Count { get; set; }
        public int Price { get; set; }

        public ProductInfo(Product product, int count = 0, int price = 0)
        {
            Count = count;
            Product = product;
            Price = price;
        }

    }
}