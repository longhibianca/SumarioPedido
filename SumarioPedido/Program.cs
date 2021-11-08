using SumarioPedido.Entities;
using SumarioPedido.Entities.Enums;
using System;
using System.Globalization;

namespace SumarioPedido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            
            Client client = new Client(name, email, birthDate);
          

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            string s = Console.ReadLine();
            OrderStatus status =System.Enum.Parse<OrderStatus>(s);

            Console.WriteLine("How many items to order? ");
            int quantity = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);
            for(int i=1; i<=quantity; i++)
            {
                Console.WriteLine($"Enter {i} item data:");
                Console.Write("Product Name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, price);
                OrderItem item = new OrderItem(productQuantity, price, product);
                order.AddItem(item);

            }

            Console.Write(order.ToString());
        }
    }
}
