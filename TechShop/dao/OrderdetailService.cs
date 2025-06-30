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
   class OrderdetailService:IOrderdetailService
    {

        public List<Orderdetails> GetAllOrderDetails()
        {
            List<Orderdetails> details = new List<Orderdetails>();

            using (SqlConnection connection = DBConnUtil.GetConnectionObject())
            {
                connection.Open();
                string query = @"
                    SELECT od.OrderDetailID, o.OrderID, p.ProductID, od.Quantity
                    FROM OrderDetails od
                    JOIN Orders o ON od.OrderID = o.OrderID
                    JOIN Products p ON od.ProductID = p.ProductID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Orders order = new Orders
                        {
                            orderID = Convert.ToInt32(reader["OrderID"]) // Composition object
                        };

                        Products product = new Products
                        {
                            productId = Convert.ToInt32(reader["ProductID"])
                        };
                        Orderdetails od = new Orderdetails
                        {
                            orderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
                            order = order,
                            product = product,
                            quantity = Convert.ToInt32(reader["Quantity"])
                        };
                        details.Add(od);
                    }
                }
            }

            return details;
        }

        public bool UpdateQuantity(int orderDetailId, int newQuantity)
        {
            using (SqlConnection connection = DBConnUtil.GetConnectionObject())
            {
                connection.Open();

                // Step 1: Check if the OrderDetailID exists
                string checkQuery = "SELECT COUNT(*) FROM OrderDetails WHERE OrderDetailID = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@id", orderDetailId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        Console.WriteLine(" Order Detail ID not found. Cannot update.");
                        return false;
                    }
                }

                // Step 2: Proceed with updating the quantity
                string updateQuery = "UPDATE OrderDetails SET Quantity = @qty WHERE OrderDetailID = @id";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@qty", newQuantity);
                    cmd.Parameters.AddWithValue("@id", orderDetailId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}

