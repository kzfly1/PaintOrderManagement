using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintOrderManagement.Models
{
    public class Order
    {
        private readonly DateTime _orderDate;

        public PaintProduct Product;
        public int Quantity;
        public decimal TotalPrice;

        public Order(PaintProduct product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            TotalPrice = Product.GetFinalPrice() * Quantity;
        }

        /// Method to display order information
        public void DisplayOrder()
        {
            Console.WriteLine(@$"Order info: 
            Name -  {Product.Name} 
            Type -  {Product.Type} 
            Color - {Product.Specification.Color}
            Size - {Product.Specification.SizeInLiters} liters  
            Quantity - {Quantity}
            Total Price - {TotalPrice:C}");
        }
    }
}
