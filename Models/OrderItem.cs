using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintOrderManagement.Models
{
    public class OrderItem
    {
        public PaintProduct Product { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => Product.GetFinalPrice() * Quantity;
        public bool isEmpty => Quantity == 0;
        public OrderItem(PaintProduct product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            if (quantity < 0) throw new ArgumentException("Quantity must be greater than zero.");
            if (quantity > Quantity) throw new InvalidOperationException("No enough items to remove");

            Quantity -= quantity;
        }

        public void DisplayOrderItem()
        {
            Product.DisplayInfo();
            Console.WriteLine($"Quantity: {Quantity}, Total Price: {Subtotal:C}");
        }
    }
}
