using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintOrderManagement.Enums;
using PaintOrderManagement.Interfaces;

namespace PaintOrderManagement.Models
{
    public class PaintProduct: IBuyable
    {
        private readonly decimal _taxRate;
        private const decimal Discount = 0.05m; // 5% discount

        public string Name { get; set; }
        public PaintType Type { get; set; }
        public PaintSpecification Specification { get; set; }
        public decimal Price { get; set; }

        public PaintProduct(string name, PaintType type, PaintSpecification specification, decimal price, decimal taxRate = 0.2m)
        {
            Name = name;
            Type = type;
            Specification = specification;
            Price = price;
            _taxRate = taxRate;
        }

        // Method to calculate the product price after tax and discount
        public decimal GetFinalPrice() => Price * (1 + _taxRate - Discount);

        // Method to display product information
        public void DisplayInfo()
        {
            Specification.DisplaySpecification();
            Console.WriteLine($"Name: {Name}, Type: {Type}, Price: {Price:C}, Price (after tax and discount): {GetFinalPrice():C}");
        }
    }
}
