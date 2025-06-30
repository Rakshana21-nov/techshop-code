using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Models;
using TechShop.utility;

namespace TechShop.dao
{

    class OrderService : IOrderService
    {
        private SqlCommand cmd;

        public OrderService()
        {
            cmd = new SqlCommand();
        }
        public List<Orders> GetAllOrders()
        {
            List<Orders> orders = new List<Orders>();

            using (SqlConnection connection = DBConnUtil.GetConnectionObject())
            {
                connection.Open();

                string query = @"
            SELECT o.OrderID, o.OrderDate, o.TotalAmount, o.CustomerID,o.order_status
            FROM Orders o";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customers customer = new Customers
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerID"])
                        };

                        Orders order = new Orders
                        {
                            orderID = Convert.ToInt32(reader["OrderID"]),
                            orderDate = Convert.ToDateTime(reader["OrderDate"]),
                            totalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                            customer = customer,
                            status = Convert.ToString(reader["order_status"]),
                        };

                        orders.Add(order);
                    }
                }
            }

            return orders;
        }

        public bool UpdateOrder(int orderId, string newStatus)
        {
            using (SqlConnection connection = DBConnUtil.GetConnectionObject())
            {
                connection.Open();

                // Check if order exists
                string checkQuery = "SELECT COUNT(*) FROM Orders WHERE OrderID = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@id", orderId);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        Console.WriteLine("Order not found.");
                        return false;
                    }
                }

                // Update status
                string updateQuery = "UPDATE Orders SET order_status = @status WHERE OrderID = @id";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@id", orderId);

                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }

        }
    }
}

