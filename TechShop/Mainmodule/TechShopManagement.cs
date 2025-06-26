
using TechShop.dao;
using TechShop.Exceptions;
using TechShop.Models;

public class TechShopMainMenu
{
    CustomerService customerService = new CustomerService();
    public void Run()
    {
        while (true)
        {
            
            Console.WriteLine("\n===== TECHSHOP MAIN MENU =====");
            Console.WriteLine("1. Customer Management");
            Console.WriteLine("2. Product Management");
            Console.WriteLine("3. Order Management");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string mainChoice = Console.ReadLine();

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
                    Console.WriteLine("Exiting TechShop... Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    private void CustomerMenu()
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
                    Console.WriteLine("Calling AddCustomer()...");
                    RegisterCustomer();
                    break;
                case "2":
                    Console.WriteLine("Calling UpdateCustomer()...");
                    // UpdateCustomer();
                    break;
                case "3":
                    Console.WriteLine("Calling DeleteCustomer()...");
                    DeleteCustomerById();
                    break;
                case "4":
                    Console.WriteLine("Calling ShowCustomers()...");
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

    private void ProductMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Product Management ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Show Products");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Calling AddProduct()...");
                    // AddProduct();
                    break;
                case "2":
                    Console.WriteLine("Calling UpdateProduct()...");
                    // UpdateProduct();
                    break;
                case "3":
                    Console.WriteLine("Calling DeleteProduct()...");
                    // DeleteProduct();
                    break;
                case "4":
                    Console.WriteLine("Calling ShowProducts()...");
                    // ShowProducts();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void OrderMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Order Management ---");
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Update Order");
            Console.WriteLine("3. Delete Order");
            Console.WriteLine("4. Show Orders");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Calling AddOrder()...");
                    // AddOrder();
                    break;
                case "2":
                    Console.WriteLine("Calling UpdateOrder()...");
                    // UpdateOrder();
                    break;
                case "3":
                    Console.WriteLine("Calling DeleteOrder()...");
                    // DeleteOrder();
                    break;
                case "4":
                    Console.WriteLine("Calling ShowOrders()...");
                    // ShowOrders();
                    break;
                case "5":
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
            Console.WriteLine("❗ No customers found in the database.");
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
            Console.WriteLine("--------------------------------------");
        }
    }



}




