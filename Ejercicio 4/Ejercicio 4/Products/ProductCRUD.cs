using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository;

namespace Products
{
    public class ProductCRUD
    {
        private List<Product> productsList = new List<Product>();
        
        public ProductCRUD()
        {
            LoadProduct();
        }

        private void LoadProduct()
        {
            productsList = Repository<Product>.ObtenerTodos("orders");
        }

        private void SaveProduct()
        {
            Repository<Product>.GuardarLista("orders", productsList);
        }

        public void LoadProducts()
        {
            string input;

            do
            {
                Console.WriteLine("------- LOAD PRODUCT LIST -------");
                Console.Write("\nProduct ID: ");
                int id;

                while (!int.TryParse(Console.ReadLine(), out id) && id <= 0)
                {
                    Console.WriteLine("\n[ALERT] The ID must greater than zero.");
                    Console.Write("Enter ID: ");
                    id = int.Parse(Console.ReadLine());

                    bool idExist = productsList.Any(p=> p.Id == id);
                    if (!idExist)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n[ALERT] This ID already exists. Please enter a different ID.");
                        Console.Write("Enter ID: ");
                        id = int.Parse(Console.ReadLine());
                    }
                }

                Console.Write("Product Name: ");
                string name = Console.ReadLine();

                while (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("\n[ALERT] The field must not be empty.");
                    Console.Write("Enter a Name: ");
                    name = Console.ReadLine();
                }

                Console.Write("Price: ");
                double price;

                while (!double.TryParse(Console.ReadLine(), out price) && price <= 0)
                {
                    Console.WriteLine("\n[ALERT] The price must greater than zero.");
                    Console.Write("Enter a valid Price: ");
                    id = int.Parse(Console.ReadLine());
                }

                Console.Write("Stock: ");
                int stock;

                while (!int.TryParse(Console.ReadLine(), out stock) && stock < 0)
                {
                    Console.WriteLine("\n[ALERT] The stock must greater than zero.");
                    Console.Write("Enter a valid Stock: ");
                    id = int.Parse(Console.ReadLine());
                }

                productsList.Add(new Product(id, name, price, stock));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n¡Product loaded successfully!");
                Console.ResetColor();
                Console.Write("\n¿Add more product? (y/n): ");
                input = Console.ReadLine().ToLower();

            } while (input == "y");

            SaveProduct();
        }

        public void ViewProductList()
        {
            if (productsList.Count == 0 || productsList == null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("\n[ALERT] Empty product list.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("==== PRODUCT LIST ====");
                foreach (var p in productsList)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n------------------------------------------------------------------");
                    Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Price: {p.Price} | Stock: {p.Stock}");
                    Console.WriteLine("------------------------------------------------------------------");
                }
            }
            Console.ResetColor();
            Console.ReadKey();
            return;
        }

        public void DeleteProduct()
        {
            ViewProductList();
            Console.WriteLine("---- Enter the ID of the product you want to delete ----");
            Console.Write("\nID: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("\n[ALERT] Invalid data.");
                Console.Write("Enter ID: ");
                id = int.Parse(Console.ReadLine());

                bool idExist = productsList.Any(p => p.Id == id);
                if (idExist)
                {
                    productsList.RemoveAt(id);
                    Console.WriteLine("\n¡Product successfully removed!.");
                    SaveProduct();
                }
                else
                {
                    Console.WriteLine("\n[ALERT] There is no product with that ID.");
                }
            }

            Console.ReadKey();
        }

        public void UpdateProduct()
        {
            ViewProductList();
            Console.WriteLine("---- Enter the ID of the product you want to delete ----");
            Console.Write("\nID: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("\n[ALERT] Invalid data.");
                Console.Write("Enter ID: ");
                id = int.Parse(Console.ReadLine());

                bool idExist = productsList.Any(p => p.Id == id);
                if (idExist)
                {
                    Console.Write("New Product Name: ");
                    string name = Console.ReadLine();

                    while (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("\n[ALERT] The field must not be empty.");
                        Console.Write("Enter a Name: ");
                        name = Console.ReadLine();
                    }

                    Console.Write("Price: ");
                    double price;

                    while (!double.TryParse(Console.ReadLine(), out price) && price <= 0)
                    {
                        Console.WriteLine("\n[ALERT] The price must greater than zero.");
                        Console.Write("Enter a valid Price: ");
                        id = int.Parse(Console.ReadLine());
                    }

                    Console.Write("Stock: ");
                    int stock;

                    while (!int.TryParse(Console.ReadLine(), out stock) && stock < 0)
                    {
                        Console.WriteLine("\n[ALERT] The stock must greater than zero.");
                        Console.Write("Enter a valid Stock: ");
                        id = int.Parse(Console.ReadLine());
                    }

                    productsList.Add(new Product(id, name, price, stock));

                    SaveProduct();
                }
                else
                {
                    Console.WriteLine("\n[ALERT] There is no product with that ID.");
                }
            }

            Console.ReadKey();
            return;
        }
    }
}
