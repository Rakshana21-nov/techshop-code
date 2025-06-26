using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechShop.Exceptions;
namespace TechShop.Models
{
    public  class Products
    {
        int productId;
        string productName;
        string description;
        decimal price;


        public Products()
        {

        }

        public Products(int p_id, string p_name, string p_description, decimal p_price)
        {
            productId = p_id;
            productName = p_name;
            description = p_description;
            price = p_price;


        }
        public int GetProductId()
        {
            return productId;
        }
        public void SetProductId(int p_id)
        {
            productId = p_id;
        }
        public string GetProductName()
        {
            return productName;
        }
        public void SetProductName(string p_name)
        {
            productName = p_name;
        }

        public string GetDescription()
        {
            return description;
        }
        public void SetDescription(string p_description)
        {
            description = p_description; ;
        }

        public decimal Getprice()
        {
            return price;
        }
        public void Setprice(decimal p_price)
        {
            //if (p_price < 0)
            //    throw new InvaliDataException("Price cannot be negative.");
            price = p_price;
        }

        

        
        public override string ToString()
        {
            return $"Product ID: {productId}\n" +
                   $"Product Name: {productName}\n" +
                   $"Description: {description}\n" +
                   $"Price: {price:F2}";
        }
    }
}
