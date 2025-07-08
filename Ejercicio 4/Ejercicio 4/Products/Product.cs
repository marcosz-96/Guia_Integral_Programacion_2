using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product(int id, string name, double price, int stock)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
        }

        public Product() { }

        public double FinalPrice() => Price * 1.21;
    }
}
