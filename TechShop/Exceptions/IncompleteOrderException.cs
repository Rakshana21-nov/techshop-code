using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    public class IncompleteOrderException: Exception
    {
        public IncompleteOrderException(string? message) : base(message)
        {
        }
    }

    public class Order
    {
        public void ValidateOrder(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                throw new IncompleteOrderException("Order must include a product reference.");
        }
    }
}
