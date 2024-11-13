using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2_
{
    using System;

    class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }

    class Question2

    {
        static void Main(string[] args)
        {

            Products[] p = new Products[10];


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Enter details for Product {i + 1}:");
                Console.Write("Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());


                p[i] = new Products { ProductId = productId, ProductName = productName, Price = price };
            }


            Array.Sort(p, (x, y) => x.Price.CompareTo(y.Price));


            Console.WriteLine("\nSorted Products based on Price:");
            foreach (var product in p)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Price: {product.Price}");
            }

            Console.ReadLine();
        }
    }
}