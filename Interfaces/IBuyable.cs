using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Represents a buyable item in the paint order management system.
/// All buyable entities must implement this interface.
/// </summary>
namespace PaintOrderManagement.Interfaces
{
    public interface IBuyable
    {
        decimal GetFinalPrice();
    }
}
