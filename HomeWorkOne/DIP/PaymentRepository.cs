using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne.DIP
{
    internal class PaymentRepository :IPaymentRepository
    {
        public List<Payment> GetPayments()
        {
           return new List<Payment>()
                   {
                      new Payment() {type="Mobile Payment",amount=100},
                      new Payment() {type="EFT Transfer Payment",amount=2596},
                      new Payment() {type="Online Payment",amount = 8710},


                   };
        }
    }
}
