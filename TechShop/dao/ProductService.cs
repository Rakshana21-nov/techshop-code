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
     class ProductService:IProductService
{

    public bool AddProduct(Products product)
 {

            if (product.price == null || product.price <= 0)
            {
                throw new InvalidDataException("Invalid Price: Price must be greater than zero and not null.");
            }
            using (SqlConnection connection = DBConnUtil.GetConnectionObject())
        {
            connection.Open();
            string query = @"INSERT INTO products (ProductID,ProductName, Category,Description, Price)
                             VALUES (@id,@name,@category, @desc, @price)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                    cmd.Parameters.AddWithValue("@id", product.productId);
                cmd.Parameters.AddWithValue("@name", product.productName);
                cmd.Parameters.AddWithValue("@category", product.category);
                cmd.Parameters.AddWithValue("@desc", product.description);
                cmd.Parameters.AddWithValue("@price", product.price);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }

        public bool UpdateProduct(int productId, Dictionary<string, object> updates)
        {
            if (updates == null || updates.Count == 0)
                return false;

            using (SqlConnection connection = DBConnUtil.GetConnectionObject())
            {
                connection.Open();

                // Step 1: Check if the product exists
                string checkQuery = "SELECT COUNT(*) FROM products WHERE ProductID = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@id", productId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        throw new InvalidDataException($"Product with ID {productId} does not exist.");
                    }
                }

                // Step 2: Build dynamic update query
                List<string> setClauses = new List<string>();
                foreach (var key in updates.Keys)
                {
                    setClauses.Add($"{key} = @{key}");
                }

                string setClause = string.Join(", ", setClauses);
                string query = $"UPDATE products SET {setClause} WHERE ProductID = @productId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    foreach (var kvp in updates)
                    {
                        cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                    }

                    cmd.Parameters.AddWithValue("@productId", productId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public List<Products> GetAllProducts()
        {
            List<Products> productList = new List<Products>();

            using (SqlConnection connection = DBConnUtil.GetConnectionObject())
            {
                connection.Open();
                string query = "SELECT ProductID, ProductName, Category, Description, Price FROM products";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products product = new Products
                        {
                            productId = Convert.ToInt32(reader["ProductID"]),
                            productName = reader["ProductName"].ToString(),
                            category = reader["Category"].ToString(),
                            description = reader["Description"].ToString(),
                            price = Convert.ToDecimal(reader["Price"])
                        };

                        productList.Add(product);
                    }
                }
            }

            return productList;
        }
    }
    }

