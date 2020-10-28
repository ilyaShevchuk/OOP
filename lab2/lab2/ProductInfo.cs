namespace lab2
{
    public class ProductInfo
    {
        private Product _product;
        private int _count, _price;
        
        public Product Product
        {
            get => _product;
            set => _product = value;
        }

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public ProductInfo(Product product, int count = 0, int price = 0)
        {
            _count = count;
            _product = product;
            _price = price;
        }
        
        
    }
}