using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException(string message) : base(message) { }
    }

    public class Inventory
    {
        public void ProcessOrder(int availableStock, int quantity)
        {
            if (quantity > availableStock)
                throw new InsufficientStockException("Not enough stock available.");
        }
        //Console.WriteLine("Stock available");
    }
}