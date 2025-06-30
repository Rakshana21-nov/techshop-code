
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;
using TechShop.dao;
using TechShop.Models;
using TechShop.utility;
using TechShop.Exceptions;

namespace TechShop.dao
{
    class CustomerService : ICustomerService
    {
        private SqlCommand cmd;

        public CustomerService()
        {
            cmd = new SqlCommand();
        }

        public List<Customers> GetCustomerDetails()
        {
            List<Customers> customers = new List<Customers>();

            try
            {
                using (SqlConnection sqlConnection = DBConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = "SELECT * FROM Customers";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string email = reader["Email"].ToString();
                            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                            {
                                // ❗ Validate external data (bad email in DB)
                                throw new InvalidDataException($"Invalid email found in database for customer: {reader["FirstName"]} {reader["LastName"]}");
                            }

                            Customers customer = new Customers
                            {
                                CustomerId = Convert.ToInt32(reader["CustomerID"]),
                                Firstname = reader["FirstName"].ToString(),
                                Lastname = reader["LastName"].ToString(),
                                email = email,
                                phone = reader["Phone"].ToString(),
                                address = reader["Address"].ToString()
                            };

                            customers.Add(customer);
                        }
                    }
                }
            }
            
            catch (InvalidDataExceptions ex)
            {
                Console.WriteLine($"Data Validation Error: {ex.Message}");
            }
            

            return customers;
        }


        public bool RegisterCustomer(Customers customer)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(customer.email) || !customer.email.Contains("@"))
                {
                    throw new InvalidDataExceptions("Invalid email format: '@' symbol is required.");
                }
            }

            catch (InvalidDataExceptions ex)
            {
                Console.WriteLine($" Data Validation Error: {ex.Message}");
            }


            using (SqlConnection sqlConnection = DBConnUtil.GetConnectionObject())
                {
                    cmd.CommandText = @"INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Address) 
                                    VALUES (@id, @fname, @lname, @email, @phone, @address)";
                    cmd.Connection = sqlConnection;

                    cmd.Parameters.Clear(); // Reset parameters
                    cmd.Parameters.AddWithValue("@id", customer.CustomerId);
                    cmd.Parameters.AddWithValue("@fname", customer.Firstname);
                    cmd.Parameters.AddWithValue("@lname", customer.Lastname);
                    cmd.Parameters.AddWithValue("@email", customer.email);
                    cmd.Parameters.AddWithValue("@phone", customer.phone);
                    cmd.Parameters.AddWithValue("@address", customer.address);

                    sqlConnection.Open();
                    int rowsInserted = cmd.ExecuteNonQuery();

                    return rowsInserted > 0;
                 }
            
            

           
        }


        public bool UpdateCustomer(int customerId, Dictionary<string, object> updates)
        {
            if (updates == null || updates.Count == 0)
                return false;

            using (SqlConnection sqlConnection = DBConnUtil.GetConnectionObject())
            {
                sqlConnection.Open();

                // Step 1: Check if customer exists
                string checkQuery = "SELECT COUNT(*) FROM customers WHERE CustomerID = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlConnection))
                {
                    checkCmd.Parameters.AddWithValue("@id", customerId);
                    int count = (int)checkCmd.ExecuteScalar();

                    try
                    {
                        if (count == 0)
                            throw new Exception($"Customer with ID {customerId} does not exist.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return false;
                    }
                }

                // Step 2: Build dynamic update query
                List<string> setClauses = new List<string>();
                foreach (var key in updates.Keys)
                {
                    setClauses.Add($"{key} = @{key}");
                }

                string setClause = string.Join(", ", setClauses);
                string query = $"UPDATE customers SET {setClause} WHERE CustomerID = @customerId";

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    // Add update values
                    foreach (var kvp in updates)
                    {
                        cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                    }

                    cmd.Parameters.AddWithValue("@customerId", customerId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool DeleteCustomer(int customerId)
        {
            
                using (SqlConnection connection = DBConnUtil.GetConnectionObject())
                {
                    connection.Open();

                    // Check if customer exists
                    cmd.CommandText = "SELECT COUNT(*) FROM Customers WHERE CustomerID = @id";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", customerId);
                    cmd.Connection = connection;

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                try
                {
                    if (count == 0)
                    {
                        throw new InvalidDataExceptions("Customer ID does not exist.");
                    }
                }
                catch(InvalidDataExceptions ex)
                {
                    Console.WriteLine(ex.Message);
                }

                    // Delete customer
                    cmd.CommandText = "DELETE FROM Customers WHERE CustomerID = @id";
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            
        



        public int CalculateTotalOrders(int customerId)
        {
            
            int totalOrders = 0;

            using (SqlConnection conn = DBConnUtil.GetConnectionObject())
            {
                string query = "SELECT COUNT(*) FROM Orders WHERE CustomerId = @CustomerId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        totalOrders = Convert.ToInt32(result);
                    }
                }
            }

            return totalOrders;
        }
        
    }
}
    
