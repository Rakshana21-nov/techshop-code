
using TechShop.dao;
using TechShop.Exceptions;
using TechShop.Models;

namespace TechShop.Mainmodule
{

    public class TechShopManagementMenu
    {
        CustomerService customerService = new CustomerService();
        ProductService productService = new ProductService();
        OrderService orderService = new OrderService();
        OrderdetailService orderdetailService = new OrderdetailService();
        public void Run()
        {
            while (true)
            {

                Console.WriteLine("\n===== TECHSHOP MAIN MENU =====");
                Console.WriteLine("1. Customer Management");
                Console.WriteLine("2. Product Management");
                Console.WriteLine("3. Order Management");
                Console.WriteLine("4. Order Detail Management");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string mainChoice = Console.ReadLine();
                try
                {
                    switch (mainChoice)
                    {
                        case "1":
                            CustomerMenu();
                            break;
                        case "2":
                            ProductMenu();
                            break;
                        case "3":
                            OrderMenu();
                            break;
                        case "4":
                            OrderdetailsMenu();
                            break;
                        case "5":
                            Console.WriteLine("Exiting TechShop... Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
                catch (InvalidDataException ex)
                {
                    Console.WriteLine($"Data Error: {ex.Message}");
                }
            }
        }

        public void CustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Customer Management ---");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Update Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. Show Customers");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        RegisterCustomer();
                        break;
                    case "2":

                        UpdateCustomer();
                        break;
                    case "3":

                        DeleteCustomerById();
                        break;
                    case "4":

                        GetCustomerDetails();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public void ProductMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Product Management ---");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Show Products");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        AddProduct();
                        break;
                    case "2":

                        UpdateProduct();
                        break;
                    
                    case "3":

                        GetAllProducts();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public  void OrderMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Order Management ---");
                Console.WriteLine("1. Update Order");
                Console.WriteLine("2. Show Orders");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    
                    case "1":
                        
                        UpdateOrder();
                        break;
                   
                    case "2":
                        
                         GetAllOrders();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        public void OrderdetailsMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Order Management ---");
                Console.WriteLine("1. Update Orderdetail");
                Console.WriteLine("2. Show Order Details ");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                  
                    case "1":

                        UpdateOrderDetail();
                        break;
      
                    case "2":

                        GetAllOrderDetails();
                        break;

                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public void RegisterCustomer()
        {
            List<Customers> customers = new List<Customers>();
            Console.Write("Enter Customer ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter First Name: ");
            string fname = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lname = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new InvalidDataException("Invalid Email: '@' symbol is required.");
            }

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Customers newCustomer = new Customers(id, fname, lname, email, phone, address);
            customers.Add(newCustomer);

            Console.WriteLine("Customer registered successfully!");
        }
        public void UpdateCustomer()
        {
            Console.WriteLine("\n--- Update Customer ---");

            Console.Write("Enter Customer ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid Customer ID.");
                return;
            }

            Dictionary<string, object> updates = new Dictionary<string, object>();

            while (true)
            {
                Console.Write("Enter field name to update (FirstName, LastName, Email, Phone, Address) or type 'done' to finish: ");
                string field = Console.ReadLine().Trim();

                if (field.Equals("done", StringComparison.OrdinalIgnoreCase))
                    break;

                // Validate allowed fields (case-insensitive)
                string[] allowedFields = { "FirstName", "LastName", "Email", "Phone", "Address" };
                if (!allowedFields.Any(f => f.Equals(field, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Invalid field. Allowed fields are: FirstName, LastName, Email, Phone, Address");
                    continue;
                }

                Console.Write($"Enter value for {field}: ");
                string value = Console.ReadLine();
                updates[field] = value;
            }

            if (updates.Count == 0)
            {
                Console.WriteLine("No fields provided for update.");
                return;
            }


            bool success = customerService.UpdateCustomer(customerId, updates);

            Console.WriteLine(success ? "Customer updated successfully." : "Failed to update customer. Please check the ID and inputs.");
        }

        public void DeleteCustomerById()
        {
            try
            {
                Console.Write("Enter Customer ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                bool deleted = customerService.DeleteCustomer(id);
                if (deleted)
                {
                    Console.WriteLine("Customer deleted successfully.");
                }
                else
                {
                    Console.WriteLine(" Customer could not be deleted.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(" Please enter a valid numeric ID.");
            }
        }

        public void GetCustomerDetails()

        {
            List<Customers> customerList = customerService.GetCustomerDetails();

            if (customerList.Count == 0)
            {
                Console.WriteLine(" No customers found in the database.");
                return;
            }

            Console.WriteLine("\n======= Customers in Database =======");
            foreach (var customer in customerList)
            {
                Console.WriteLine($"ID      : {customer.CustomerId}");
                Console.WriteLine($"Name    : {customer.Firstname} {customer.Lastname}");
                Console.WriteLine($"Email   : {customer.email}");
                Console.WriteLine($"Phone   : {customer.phone}");
                Console.WriteLine($"Address : {customer.address}");
               
            }
        }

        public void AddProduct()
        {
            Products newProduct = new Products();
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            newProduct.productName = Console.ReadLine();

            Console.WriteLine("Enter category: ");
            newProduct.category = Console.ReadLine();

            Console.Write("Enter Product Description: ");
            newProduct.description = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }
            newProduct.price = price;

            bool success = productService.AddProduct(newProduct);
            Console.WriteLine(success ? "Product added successfully!" : "Failed to add product.");
        }
        public void UpdateProduct()
        {
            Console.WriteLine("\n--- Update Product ---");

            Console.Write("Enter Product ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid Product ID.");
                return;
            }

            Dictionary<string, object> updates = new Dictionary<string, object>();

            while (true)
            {
                Console.Write("Enter field to update (ProductName, Description, Price, Category) or type 'done': ");
                string field = Console.ReadLine().Trim();

                if (field.Equals("done", StringComparison.OrdinalIgnoreCase))
                    break;

                string[] allowedFields = { "ProductName", "Description", "Price", "Category" };
                if (!allowedFields.Any(f => f.Equals(field, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Invalid field. Allowed: ProductName, Description, Price, Category");
                    continue;
                }

                Console.Write($"Enter value for {field}: ");
                string value = Console.ReadLine();

                if (field.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    if (decimal.TryParse(value, out decimal price))
                        updates[field] = price;
                    else
                    {
                        Console.WriteLine("Invalid price value.");
                        continue;
                    }
                }
                else
                {
                    updates[field] = value;
                }
            }

            if (updates.Count == 0)
            {
                Console.WriteLine("No updates provided.");
                return;
            }
            bool success = productService.UpdateProduct(productId, updates);

            Console.WriteLine(success ? "Product updated successfully." : "Failed to update product. Please check the ID and inputs.");
        }

        public void GetAllProducts()
        {
            List<Products> products = productService.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found in the database.");
                return;
            }

            Console.WriteLine("\n====== Product List ======");
            foreach (var product in products)
            {
                Console.WriteLine($"ID        : {product.productId}");
                Console.WriteLine($"Name      : {product.productName}");
                Console.WriteLine($"Category  : {product.category}");
                Console.WriteLine($"Price     : {product.price}");
                Console.WriteLine($"Description: {product.description}");
               
            }
        }
        public void GetAllOrders()
        {
            List<Orders> orderList = orderService.GetAllOrders();

            if (orderList.Count == 0)
            {
                Console.WriteLine(" No orders found in the database.");
                return;
            }

            Console.WriteLine("\n======= Orders in Database =======");

            foreach (var order in orderList)
            {
                Console.WriteLine($"Order ID     : {order.orderID}");
                Console.WriteLine($"Customer ID  : {order.customer.CustomerId}");
                Console.WriteLine($"Order Date   : {order.orderDate:yyyy-MM-dd}");
                Console.WriteLine($"Total Amount : {order.totalAmount}");
                Console.WriteLine($"Status       : {order.status}");

            }
        }
        public void UpdateOrder()
        {
            Console.WriteLine("\n--- Update Order Status ---");

            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid Order ID.");
                return;
            }

            Console.WriteLine("Enter new status (Pending / Processing / Shipped): ");
            string status = Console.ReadLine().Trim();


            bool updated = orderService.UpdateOrder(orderId, status);

            Console.WriteLine(updated ? "Order status updated successfully." : "Failed to update order status.");
        }

        public void GetAllOrderDetails()
        {
            Console.WriteLine("\n======= Order Details =======");

            List<Orderdetails> detailsList = orderdetailService.GetAllOrderDetails();

            if (detailsList == null || detailsList.Count == 0)
            {
                Console.WriteLine(" No order details found.");
                return;
            }

            foreach (var detail in detailsList)
            {
                Console.WriteLine($"Order Detail ID : {detail.orderDetailID}");
                Console.WriteLine($"Order ID        : {detail.order.orderID}");
                Console.WriteLine($"Product ID      : {detail.product.productId}");
                Console.WriteLine($"Quantity        : {detail.quantity}");
               
            }
        }

        public void UpdateOrderDetail()
        {
            Console.WriteLine("\n--- Update Quantity in Order Detail ---");

            Console.Write("Enter Order Detail ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int orderDetailId))
            {
                Console.WriteLine("Invalid ID format. Please enter a number.");
                return;
            }

            Console.Write("Enter new quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int newQuantity) || newQuantity < 1)
            {
                Console.WriteLine("Invalid quantity. Must be a positive number.");
                return;
            }

            bool updated = orderdetailService.UpdateQuantity(orderDetailId, newQuantity);
            Console.WriteLine(updated ? "Quantity updated successfully." : " Failed to update. Check if OrderDetail ID exists.");
        }
    }
}




