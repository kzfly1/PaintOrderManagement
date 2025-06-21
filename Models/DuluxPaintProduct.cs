using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintOrderManagement.Enums;

namespace PaintOrderManagement.Models
{ 
    public class DuluxPaintProduct:PaintProduct
    {
        public string DuluxRefNumber { get; set; }
        public DuluxPaintSpecification DuluxPaintSpecification { get; set; }
        public DuluxPaintProduct(string duluxRefNumber, string name, string brand, PaintType type, DuluxPaintSpecification specification, decimal price, decimal taxRate = 0.2m) : base(name, brand, type, specification, price, taxRate)
        {
            DuluxPaintSpecification = specification;
            DuluxRefNumber = duluxRefNumber;
        }

        // Method to display Dulux paint product information
        public override void DisplayInfo()
        {
            Console.WriteLine($"Dulux Reference Number: {DuluxRefNumber}");
            DuluxPaintSpecification.DisplaySpecification();
            Console.WriteLine($"Id: {Id}, Name: {Name}, Brand: {Brand}, Type: {Type}, Price: {Price:C}, Price (after tax and discount): {GetFinalPrice():C}");
        }
    }
}
