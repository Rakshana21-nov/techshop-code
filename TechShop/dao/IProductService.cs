using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Models;

namespace TechShop.dao
{
    public  interface IProductService
    {
        bool AddProduct(Products product);

        bool UpdateProduct(int productId, Dictionary<string, object> updates);


        List<Products> GetAllProducts();
    }
}
