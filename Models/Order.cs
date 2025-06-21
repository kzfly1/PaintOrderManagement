using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintOrderManagement.Utils;

namespace PaintOrderManagement.Models
{
    public class Order
    {
        private readonly DateTime _orderDate;

        public List<OrderItem> Items { get; private set; }
        

        public decimal TotalPrice => Items.Sum(item => item.Subtotal);

        public Order()
        {
            _orderDate = DateTime.Now;
            Items = new List<OrderItem>();
        }

        //add one product to the order
        public void AddProduct(PaintProduct product, int quantity)
        {
            Items.Add(new OrderItem(product, quantity));
            
        }

        //add multiple products to the order
        public void AddProducts(IEnumerable<(PaintProduct Product, int Quantity)> items)
        {
            foreach (var (product, quantity) in items)
            {
                AddProduct(product, quantity);
            }
        }

        public void DeleteSomeProduct(PaintProduct product, int quantity)
        {
            OrderItem? item = Items.FirstOrDefault(i => i.Product == product);
            if (item == null)
            {
                Console.WriteLine("Product not found in this order.");
                return;
            }

            try
            {
                item.DecreaseQuantity(quantity);
                if (item.isEmpty)
                {
                    Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed: {ex.Message}.");
            }
        }

        /// Method to display order information
        public void DisplayOrder()
        {
            Console.WriteLine($"--Order created at: {_orderDate}");
            foreach (var item in Items)
            {
                item.DisplayOrderItem();
            }

            Console.WriteLine($"Total Price: {TotalPrice:C}");
        }
    }
}
