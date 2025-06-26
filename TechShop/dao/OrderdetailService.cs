using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.dao
{
   class OrderdetailService:IOrderdetailService
    {
        private SqlCommand cmd;

        public OrderdetailService()
        {
            cmd = new SqlCommand();
        }
    }
}
