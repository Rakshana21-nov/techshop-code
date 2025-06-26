using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace TechShop.utility
{
    public static class DBConnUtil
    {
        public static SqlConnection GetConnectionObject()
        {
            string connectionString = DBPropertyUtil.GetConnectionString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
            return sqlConn;
        }
    }
}
