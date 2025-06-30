using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Models;

namespace TechShop.dao
{
    public  interface IOrderService
    {
        List<Orders> GetAllOrders();

        bool UpdateOrder(int orderId, string newStatus);
    }
}
