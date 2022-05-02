using System;
using static System.Console;
using System.Globalization;
using Exercixe_ItensPerOrder.Entities;
using Exercixe_ItensPerOrder.Enums;

namespace Exercixe_ItensPerOrder
{
    class Program
    {
        static void Main(string[] args)
        {            
            WriteLine("Enter cliente data: " + DateTime.Now);
            Write("Name: ");
            string name = ReadLine();
            Write("Email: ");
            string email = ReadLine();
            Write("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(ReadLine());
            WriteLine("Enter order data: ");
            Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(ReadLine());
            
            Client client = new Client(name, email, date);
            Order order = new Order(DateTime.Now, status, client);

            Write("How many items to this order? ");
            int n = int.Parse(ReadLine());
            for (int i = 1; i <= n; i++)
            {
                WriteLine($"Enter #{i} item data:");
                Write("Product name: ");
                string productName = ReadLine();
                Write("Product price: ");
                double price = double.Parse(ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);
                Write("Quantity: ");
                int quantity = int.Parse(ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
            }

            WriteLine();
            WriteLine("ORDER SUMARY:");
            WriteLine(order);
        }
    }
}
