using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintOrderManagement.Models
{
    /// <summary>
    /// StoreItem Class is used for the PaintStore Dictionary, offering better flexibility and maintainability.
    /// </summary>
    public class StoreItem
    {
        public PaintProduct Product { get; set; }
        public int Quantity { get; set; }

        public StoreItem(PaintProduct product, int quantity)
            {
                Product = product;
                Quantity = quantity;
            }
        // Method to display the store item information
        public void DisplayItemInfo()
        {
            Console.WriteLine($"Product: {Product.Name}, Quantity: {Quantity}");
        }
    }
}
