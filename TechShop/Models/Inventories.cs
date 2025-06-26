using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Models
{
    public class Inventories
    {
        int inventoryID
        {
            get; set;
        }
        Products product                // Composition
        {
            get; set;
        }
        int quantityInStock
        {
            get; set;
        }
        DateTime lastStockUpdate
        {
            get; set;
        }

        public Inventories()
        {

        }
        public Inventories(int id, Products prod, int qty, DateTime updateDate)
        {
            inventoryID = id;
            product = prod;
            quantityInStock = qty;
            lastStockUpdate = updateDate;
        }

        
        
        public override string ToString()
        {
            return $"InventoryID: {inventoryID}\n" +
                $"Quantity In Stock: {quantityInStock}\n" +
                $"Last Stock Update: {lastStockUpdate.ToShortDateString()}\n" +
                $"Product Info:\n{product}";
        }

    }
}