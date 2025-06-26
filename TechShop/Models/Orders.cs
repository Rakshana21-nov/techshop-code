using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Models
{
    public  class Orders
    {
        int orderID
        {
            get; set;

        }

        Customers customer // Composition: Has-A relationship
        {
            get; set;
        }
        DateTime orderDate
        {
            get; set;
        }
        decimal totalAmount
        {
            get; set;
        }

        public Orders()
        {

        }
        public Orders(int id, Customers cust, DateTime date, decimal amount)
        {
            orderID = id;
            customer = cust;
            orderDate = date;
            totalAmount = amount;
        }

        

        

        public override string ToString()
        {
            return $"OrderID: {orderID}\n" +
                $"Order Date: {orderDate.ToShortDateString()}\n" +
                $"Total Amount: ₹{totalAmount:F2}\n" +
                $"Customer Details:\n{customer}";
        }
    }
}

