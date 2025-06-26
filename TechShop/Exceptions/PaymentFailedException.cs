using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    public class PaymentFailedException : Exception
    {
        public PaymentFailedException(string? message) : base(message)
        { 
            }
     }
    public class PaymentGateway
    {
        public void ProcessPayment(bool isPaymentSuccessful)
        {
            if (!isPaymentSuccessful)
                throw new PaymentFailedException("Payment was declined. Please try again.");
        }

       // Console.WriteLine("Payment successful");

   }


}
