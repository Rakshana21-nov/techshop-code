using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.dao
{
    class OrderService:IOrderService
    {
        private SqlCommand cmd;

        public OrderService()
        {
            cmd = new SqlCommand();
        }
    }
}
