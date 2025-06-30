using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Models;

namespace TechShop.dao
{
    public interface ICustomerService
    {
        bool RegisterCustomer(Customers customer);

        bool UpdateCustomer(int customerId, Dictionary<string, object> updates);

        int CalculateTotalOrders(int customerId);
        
        List<Customers> GetCustomerDetails();

        bool DeleteCustomer(int customerId);


    }
}
