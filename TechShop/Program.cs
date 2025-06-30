using System;
using TechShop.dao;
using TechShop.Models;
using TechShop.Mainmodule;
namespace TechShop
{
    public  class Program
    {
      public  static void Main(string[] args)
        {
            #region  1 question
            //    Console.WriteLine("Enter the loyal points:");
            //    decimal loyal_points = decimal.Parse(Console.ReadLine());
            //    Console.WriteLine("Enter the total purchase amount:");
            //    decimal purchase_amount = decimal.Parse(Console.ReadLine());

            //    if (loyal_points >= 100 && purchase_amount >= 1000)
            //    {
            //        Console.WriteLine("Eligible for  special discount");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Not eligible for discount");
            //    }
            //    Console.ReadLine();

            #endregion

            #region 2 question
            //Console.WriteLine("Enter the available stock:");
            //int stock = int.Parse(Console.ReadLine());
            //Console.WriteLine("Select one option:");
            //Console.WriteLine("1.Check the available stock");
            //Console.WriteLine("2.Buy Product");
            //Console.WriteLine("3.Return product");

            //Console.WriteLine("Enter the option:");
            //int options = int.Parse(Console.ReadLine());

            //switch (options) {
            //    case 1:
            //        {
            //            Console.WriteLine($"Available stock:{ stock}");
            //            break;
            //        }
            //    case 2:
            //        {
            //            Console.WriteLine("Provide the quantity of purchase:");
            //            int quantity = int.Parse(Console.ReadLine());


            //            if (quantity < 1)
            //            {
            //                Console.WriteLine("Enter value atleast 1");

            //            }
            //            else if (quantity > stock)
            //            {
            //                Console.WriteLine("Quantity is  not available to purchase");
            //            }

            //            else
            //            {
            //                stock = stock - quantity;
            //                Console.WriteLine("Purchase Successful");
            //                 Console.WriteLine($"Available stock{stock}");
            //            }
            //            break;
            //        }
            //    case 3:
            //        Console.WriteLine("Enter the quantity to return:");
            //        int count = int.Parse(Console.ReadLine());
            //        if (count < 1)
            //        {
            //            Console.WriteLine("Enter the correct quantity alteast greater than 1");
            //        }
            //        else
            //        {
            //            stock = stock + count;
            //            Console.WriteLine("Return successsful");
            //            Console.WriteLine($"Total available stock:{stock}");
            //        }
            //        break;
            //    default:
            //        Console.WriteLine("Invalid choice enter 1 to 3");
            //        break;
            //}
            #endregion

            #region -- 3  question --
            //Console.WriteLine("Enter the order_number:");
            //int order1 = 4521;
            //String status_order = "shipped";

            //int order2 = 4522;
            //String status_order2 = "pending";
            //int order_number = int.Parse(Console.ReadLine());
            //if (order_number == 4521)
            //{
            //    Console.WriteLine("Your order is shipped");
            //}

            //else if (order_number == 4522)
            //{
            //    Console.WriteLine("Your order is pending");
            //}
            //else
            //{
            //    Console.WriteLine("Your order is processed");
            //}
            //Console.ReadLine();
            #endregion

            #region -- 4 question
            //Console.WriteLine("Welcome to  TechShop");
            //Console.WriteLine("Enter the price:");
            //decimal price = decimal.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the total quantity");
            //int quantity = int.Parse(Console.ReadLine());
            //decimal total = price * quantity;
            //decimal gst_amount = Math.Round((total * 18) / 100, 2);
            //decimal total_amount = Math.Round(total + gst_amount, 2);

            //if (total_amount > 50000)
            //{
            //    decimal discount = Math.Round((total_amount * 10) / 100, 2);
            //    decimal final_amount = Math.Round(total_amount - discount, 2);
            //    Console.WriteLine($"The bill amount is " + final_amount);
            //}
            //else
            //{
            //    Console.WriteLine($"The bill amount is total_amount" + total_amount);
            //}
            #endregion


            TechShopManagementMenu module = new TechShopManagementMenu();
            module.Run();




        }

    }
}
