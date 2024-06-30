using System;
using System.Text;
using System.Collections.Generic;
using ExercícioSessa9.Entities.Status;

namespace ExercícioSessa9.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<Product> products { get; private set; } = new List<Product>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach (Product product in products)
            {
                sum += product.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Console.Write("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.Write("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.AppendLine($"Client: {Client}");
            sb.AppendLine($"Order item:");
            foreach(Product product in products)
            {
                sb.AppendLine(product.ToString());  
            }
            sb.AppendLine($"Total price: $ {Total().ToString("f:2")}");
            return sb.ToString();
        }
    }
}
