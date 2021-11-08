using SumarioPedido.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SumarioPedido.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client  { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order ()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach(OrderItem item in Items)
            {
                sum = sum + item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Summary: ");
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm"));
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client :");
            sb.AppendLine(Client.Name + " (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") " + " - " + Client.Email);
            sb.AppendLine("Order items: ");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.Product.Name + ", Quantity: " + item.Quantity + ", Subtotal: " + item.SubTotal().ToString());
            }
            sb.Append("Total Price: ");
            sb.AppendLine("$" + Total());
            
            return sb.ToString();
        }
    }
}
