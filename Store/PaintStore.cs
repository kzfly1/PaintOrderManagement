using PaintOrderManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintOrderManagement.Store
{
    public class PaintStore
    {
        /// <summary>
        /// The PaintStore is product storage to display & manage (add, delete, etc.) the available items 
        /// </summary>

        private static readonly PaintStore instance = new PaintStore();
        public static PaintStore Instance => instance;

        private PaintStore(){}

        private Dictionary<int, StoreItem> _availableProducts = new();

        /// <summary>
        /// Method to display the current(latest) available products in the store
        /// </summary>
        public void DisplayInventory()
        {
            foreach (var item in _availableProducts)
            {
                Console.WriteLine("Our Inventory: ");
                Console.WriteLine($"ID:{item.Value.Product.Name}, Name:{item.Value.Product.Name}, Quantity:{item.Value.Quantity}");
            }
        }

        /// <summary>
        /// Method to add product to the store
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddProduct(PaintProduct product, int quantity)
        {
            try
            {
                if (_availableProducts.ContainsKey(product.Id))
                {
                    _availableProducts[product.Id].Quantity += quantity;
                }
                else
                {
                    _availableProducts[product.Id] = new StoreItem(product, quantity);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Method to remove product from the store by product ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>

        public void RemoveProductById(int id, int quantity)
        {
            try
            {
                if (_availableProducts.TryGetValue(id, out var item))
                {
                    if (item.Quantity > quantity)
                    {
                        item.Quantity -= quantity;
                    }
                    else
                    {
                        _availableProducts.Remove(id);
                    }
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Method to remove product from the store by product instance
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void RemoveProductByInstance(PaintProduct product, int quantity)
        {
            var matchedProduct = _availableProducts.Values.FirstOrDefault(p => p.Product == product);
            
            if (matchedProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            try
            {
                if (matchedProduct.Quantity > quantity)
                {
                    matchedProduct.Quantity -= quantity;
                }
                else
                {
                    _availableProducts.Remove(matchedProduct.Product.Id);
                }
            }
                
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// This method returns the most expensive paint product(s) in the store as a list.
        /// </summary>
        /// <returns></returns>
        public List<PaintProduct> GetMostExpensivePaintProduct()
        {
            if (_availableProducts.Count == 0)
            {
                return new List<PaintProduct>();
            }

            var topPrice = _availableProducts.Values.Max(p => p.Product.Price);
            return _availableProducts.Values
                .Where(p => p.Product.Price == topPrice)
                .Select(p => p.Product)
                .ToList();
        }

    }
}
