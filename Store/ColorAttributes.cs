using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintOrderManagement.Store
{
    public class ColorAttributes
    {
        //Singleton instance of ColorAttributes
        private static ColorAttributes _instance = new ColorAttributes();
        public static ColorAttributes Instance => _instance;

        public Dictionary<int, string> Colors = new();

        private ColorAttributes() {}


        /// <summary>
        /// Adds a color to the dictionary if it does not already exist.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void AddColor(int id, string name)
        {
            if (Colors.TryGetValue(id, out _)) //I don't care about the value here, just checking if the key exists
            {
                Console.WriteLine("Color already existed");
            }
            else
            {
                Colors.Add(id, name);
            }
        }
        /// <summary>
        /// Gets the name of a color by its ID.
        /// </summary>
        /// <param name="id"></param>
        public bool GetColorName(int id)
        {
            if (Colors.TryGetValue(id, out string? name))
            {
                Console.WriteLine($"Found color: Id-{id} Color-{name}");
                return true;
            }
            else
            {
                Console.WriteLine("Color not found.");
                return false;
            }
        }
        /// <summary>
        /// Method to remove a color from the dictionary by its ID.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveColor(int id)
        {
            Colors.Remove(id);
            Console.WriteLine($"Deleted color with Id-{id}");
        }

        /// <summary>
        /// Method to display all colors in the dictionary.
        /// </summary>
        public void DisplayColors()
        {
            foreach (var color in Colors)
            {
                Console.WriteLine($"Current Colors: ID-{color.Key},Color-{color.Value}");
            }
        }

    }
}
