using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Models
{
    public  class Customers
    {
      public  int CustomerId
        {
            get; set;
        }
      public  string? Firstname
        {
            get; set;
        }
     public   string? Lastname
        {
            get; set;
        }
      public  string? email
        {
            get; set;
        }
       public string? phone
        {
            get; set;
        }
       public string? address
        {
            get; set;
        }
      
        

        public Customers()
        {

        }
        public Customers(int  c_id,string f_name,string l_name,string emp_email,string emp_phone,string emp_address) { 
            CustomerId = c_id;
            Firstname = f_name;
            Lastname = l_name;
            email = emp_email;
            phone = emp_phone;
            address = emp_address;
            
        }

        
        public override string ToString()
        {
            return $"Customer ID: {CustomerId}\n" +
                   $"Name: {Firstname} {Lastname}\n" +
                   $"Email: {email}\n" +
                   $"Phone: {phone}\n" +
                   $"Address: {address}";
                   


        }
    }
}
