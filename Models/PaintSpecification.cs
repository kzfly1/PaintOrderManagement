using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintOrderManagement.Models
{
    public class PaintSpecification
    {
        public string Color { get; set; }
        public int SizeInLiters { get; set; }

        public PaintSpecification(string color, int sizeInLiters)
        {
            Color = color;
            SizeInLiters = sizeInLiters;
        }
        // Method to display the paint specification
        public virtual void DisplaySpecification()
        {
            Console.WriteLine($"-Color: {Color}, Size: {SizeInLiters} liters");
        }

    }
}
