using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintOrderManagement.Models
{
    public class DuluxPaintSpecification: PaintSpecification
    {
        public string DuluxFeature { get; set; }
        public DuluxPaintSpecification(string color, int sizeInLiters, string duluxFeature) : base(color, sizeInLiters)
        {
            DuluxFeature = duluxFeature;
        }
        // Method to display the Dulux paint specification
        public override void DisplaySpecification()
        {
            base.DisplaySpecification();
            Console.WriteLine($"-Dulux Feature: {DuluxFeature}");
        }

    }
}
