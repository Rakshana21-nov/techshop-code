using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.dao
{
     class InventoryService:IInventoryService
    {
        private SqlCommand cmd;

        public InventoryService()
        {
            cmd = new SqlCommand();
        }
    }
}
