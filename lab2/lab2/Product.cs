using System;

namespace lab2
{
    public class Product
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        private int _id;
        public Product(string name = "", int id = 0)
        {
            _name = name;
            _id = id;
        }
        
        
    }
}