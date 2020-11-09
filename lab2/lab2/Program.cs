using System;
using System.Collections.Generic;

namespace lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {   
            Product p1 = new Product("apple", 123);
            Product p2 = new Product("orange", 123);
            Product p3 = new Product("mango", 125);
            Product p4 = new Product("bread", 126);
            Product p5 = new Product("water", 127);
            
            ProductInfo pi1 = new ProductInfo(p1, 10, 100);
            ProductInfo pi2 = new ProductInfo(p2, 3, 12);
            ProductInfo pi3 = new ProductInfo(p3, 100, 450);

            Shop s1 = new Shop(12, "Main Shop", "address # 1");
            Shop s2 = new Shop(13, "Second Shop");
            Shop s3 = new Shop(14, "Third Shop");

            s1.AddProduct(pi1);
            s1.AddProduct(pi2);
            s1.AddProduct(pi3);
            s1.AddProduct(p4, 412, 18);
            
            s2.AddProduct(p3, 12, 200);
            s2.AddProduct(p4, 300, 20);
            
            s3.AddProduct(p4, 14, 25);
            s3.AddProduct(p3, 12, 350);

            s1.HowMuchICanBuy(200).Print();

            try {
                var k = s1.BuyBatch(new[] {
                    new InInfo(124, 3),
                    new InInfo(123, 4)
                });
                Console.WriteLine(k);
            } catch (NotEnough e) {
                Console.WriteLine(e.Message);
            } catch (InvalidId e)  {
                Console.WriteLine(e.Message);
            }
            
            AllShops shops = new AllShops();
            shops.AddStore(s1);
            shops.AddStore(s2);
            shops.AddStore(s3);

            Shop ans = shops.FindProductLowPrice(p4);
            Console.WriteLine(ans.Name);

            Shop ans2 = shops.FindBatchLowPrice(new[] {
                new InInfo(125, 2),
                new InInfo(126, 2)
            });
            Console.WriteLine(ans2.Name);

        }
    }
}