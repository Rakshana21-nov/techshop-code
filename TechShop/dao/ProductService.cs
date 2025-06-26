using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.dao
{
     class ProductService:IProductService
    {
        private SqlCommand cmd;

        public ProductService()
        {
            cmd = new SqlCommand();
        }
    }
}
