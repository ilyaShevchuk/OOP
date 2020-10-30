using System;

namespace lab2
{
    public class Product
    {
        public string Name { get; }

        public int Id { get; }

        public Product(string name = "", int id = 0)
        {
            Name = name;
            Id = id;
        }
    }
}