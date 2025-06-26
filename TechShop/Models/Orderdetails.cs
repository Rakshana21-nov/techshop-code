using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TechShop.Exceptions;
using TechShop.Models;

namespace TechShop.Models
{ 
    public class Orderdetails
        {
        private int orderDetailID;
        private Orders order;
        private Products product;
        private int quantity;

        public Orderdetails()
        {

        }
        public Orderdetails(int detailID, Orders order, Products product, int quantities)
        {
            orderDetailID = detailID;
            this.order = order;
            this.product = product;
            quantity = quantities;
        }

        public int GetOrderDetailID()
        {
            return orderDetailID;
        }

        public void SetOrderDetailID(int id)
        {
            orderDetailID = id;
        }

        
        public Orders GetOrder()
        {
            return order;
        }

        public void SetOrder(Orders orderObj)
        {
            order = orderObj;
        }

        
        public Products GetProduct()
        {
            return product;
        }

        public void SetProduct(Products productObj)
        {
            product = productObj;
        }

        // Getter and Setter for Quantity with Validation
        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int qty)
        {
            //if (qty <= 0)
            //    throw new ArgumentException("Quantity must be a positive integer.");
            quantity = qty;
        }


        public override string ToString()
        {
            return $"OrderDetailID: {orderDetailID}\n" +
                   $"Quantity: {quantity}\n" +
                   $"Product Info:\n{product}\n" +
                   $"Order Info:\n{order}";
        }
    }

}
    

