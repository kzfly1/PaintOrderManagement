using System.Globalization;
using PaintOrderManagement.Models;
using PaintOrderManagement.Store;
using PaintOrderManagement.Utils;
namespace PaintOrderManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Week1 assessment & Challenge
            // Week 1 assessment and challenge
            PaintProduct paint1 = new PaintProduct(
                "Giddy",
                "Nico",
                Enums.PaintType.Matte,
                new PaintSpecification("Blue", 5),
                20.00m
            );

            PaintProduct paint2 = new PaintProduct(
                "Shiny",
                "Lumos",
                Enums.PaintType.Glossy,
                new PaintSpecification("White", 10),
                50.00m
            );

            PaintProduct paint3 = new PaintProduct(
                "Bright",
                "BigMom",
                Enums.PaintType.BaseCoat,
                new PaintSpecification("Black", 15),
                50.00m
            );

            // Display product information
            paint1.DisplayInfo();
            ConsoleHelper.PrintSeparator();
            paint2.DisplayInfo();
            ConsoleHelper.PrintSeparator();
            paint3.DisplayInfo();
            ConsoleHelper.PrintSeparator();

            // Create an order
            Order order1 = new Order();
            //order1.AddProduct(paint1, 2);

            //add multiple products to the order
            order1.AddProducts(new List<(PaintProduct, int)>
            {
                (paint1, 2),
                (paint2, 4),
            });
            //display order information
            order1.DisplayOrder();

            //delete some products from the order
            order1.DeleteSomeProduct(paint1, 1);

            //display order information again
            ConsoleHelper.PrintSeparator();
            order1.DisplayOrder();

            //try to delete paint1 to 0 quantity, see if the order item is completely removed
            order1.DeleteSomeProduct(paint1, 1);
            ConsoleHelper.PrintSeparator();
            order1.DisplayOrder();

            //Singleton store created 
            ConsoleHelper.PrintSeparator();
            PaintStore store = PaintStore.Instance;

            //add products to the store
            store.AddProduct(paint2, 30);
            store.AddProduct(paint3, quantity: 30);
            //remove product by instance
            //store.RemoveProductByInstance(paint1, 10);

            //remove product by id (注意：这里的id是创建时自动生成的)
            //store.RemoveProductById(3, 5);
            //store.DisplayInventory();

            ConsoleHelper.PrintSeparator();
            #endregion


            #region Week2 assessment & Challenge
            // Create a singleton instance of ColorAttributes
            ColorAttributes colors = ColorAttributes.Instance;

            //add some colors
            colors.AddColor(1,"red");
            colors.AddColor(2,"blue");
            // get color names by id and display them
            colors.GetColorName(1);
            colors.GetColorName(2);

            //remove a color by id
            Console.WriteLine("Enter color id to remove color:");
            // Read user input and parse it to an integer
            string input = Console.ReadLine() ?? string.Empty;
            bool isValid = int.TryParse(input, out int id);

            // Check if the input is valid and if the color exists
            if (isValid && colors.GetColorName(id))
            {
                colors.RemoveColor(id);
            }

            else
            {
                Console.WriteLine("No color found with the ID. Nothing removed.");
            }

            colors.DisplayColors();

            ConsoleHelper.PrintSeparator();
            // find the most expensive product in the store
            List<PaintProduct> expPaints = store.GetMostExpensivePaintProduct();
            Console.WriteLine("Most expensive products: ");
            foreach (var product in expPaints)
            {
                Console.WriteLine($"Brand:{product.Brand}, Name: {product.Name}, Price: {product.Price}");
            }

            Console.ReadKey();
            #endregion
        }
    }
}
