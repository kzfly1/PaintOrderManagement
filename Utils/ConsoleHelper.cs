using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PaintOrderManagement.Interfaces;
using PaintOrderManagement.Models;

/// <summary>
/// A utility class for displaying info with separators in the console.
/// </summary>
namespace PaintOrderManagement.Utils
{
    public static class ConsoleHelper
    {
        public static void PrintSeparator(char symbol = '-', int length = 30)
        {
            Console.WriteLine(new string(symbol, length));
        }
    }
}
