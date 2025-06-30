using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Models
{
    public  class Orders
    {
       public int orderID
        {
            get; set;

        }

      public  Customers customer // Composition: Has-A relationship
        {
            get; set;
        }
       public DateTime orderDate
        {
            get; set;
        }
       public decimal totalAmount
        {
            get; set;
        }
        public string status
        {
            get;set;
        }

        public Orders()
        {

        }
        public Orders(int id, Customers cust, DateTime date, decimal amount,string order_status)
        {
            orderID = id;
            customer = cust;
            orderDate = date;
            totalAmount = amount;
            status = order_status;
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

