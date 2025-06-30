﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Models;

namespace TechShop.dao
{
    public interface IOrderdetailService
    {
        List<Orderdetails> GetAllOrderDetails();

        bool UpdateQuantity(int orderDetailId, int newQuantity);
    }
}
