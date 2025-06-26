using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Models;
namespace TechShop.dao
{
   public  interface ITechShopService
    {
        // --- Customers ---
        void RegisterCustomer(Customers customer);
        void UpdateCustomerInfo(int customerId, string newEmail, string newPhone, string newAddress);
        Customers GetCustomerDetails(int customerId);
        int CalculateTotalOrders(int customerId);

        // --- Products ---

        void AddProduct(Products product);
        void UpdateProductInfo(int productId, string newDescription, decimal newPrice);
        Products GetProductDetails(int productId);
        bool IsProductInStock(int productId);


        //--- Orders ---

        void PlaceOrder(Orders order);
        void CancelOrder(int orderId);
        void UpdateOrderStatus(int orderId, string newStatus);
        Orders GetOrderDetails(int orderId);
        decimal CalculateTotalAmount(int orderId);

        // ---- OrderDetails ----

        void AddOrderDetail(Orderdetails orderDetail);
        void UpdateOrderDetailQuantity(int orderDetailId, int newQuantity);
        decimal CalculateSubtotal(int orderDetailId);
        string GetOrderDetailInfo(int orderDetailId);
        void AddDiscount(int orderDetailId, decimal discountPercent);


        //---Inventories----

        void AddToInventory(int productId, int quantity);
        void RemoveFromInventory(int productId, int quantity);
        void UpdateStockQuantity(int productId, int newQuantity);
        int GetQuantityInStock(int productId);
        bool IsProductAvailable(int productId, int quantityToCheck);
        decimal GetInventoryValue();
        List<Products> ListLowStockProducts(int threshold);
        List<Products> ListOutOfStockProducts();
        List<Products> ListAllProducts();
    }
}
