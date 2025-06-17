using PaintOrderManagement.Models;
using PaintOrderManagement.Utils;
namespace PaintOrderManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PaintProduct paint1 = new PaintProduct(
                "Giddy",
                Enums.PaintType.Matte,
                new PaintSpecification("Blue", 5),
                20.00m
            );

            PaintProduct paint2 = new PaintProduct(
                "Shiny",
                Enums.PaintType.Glossy,
                new PaintSpecification("White", 10),
                30.00m
            );

            PaintProduct paint3 = new PaintProduct(
                "Bright",
                Enums.PaintType.BaseCoat,
                new PaintSpecification("Black", 15),
                25.00m
            );

            ConsoleHelper.DisplayWithSeparator(paint1);
            ConsoleHelper.DisplayWithSeparator(paint2);
            ConsoleHelper.DisplayWithSeparator(paint3);

            Order order3 = new Order(paint1, 20);
            order3.DisplayOrder();

            Console.ReadKey();
        }
    }
}
