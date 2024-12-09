using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne.DIP
{
    internal class PaymentServiceFactory
    {
        private static IPaymentService _instance;

        public IPaymentService CreatePaymentService()
        {
            if (_instance == null)
            {
                _instance =new PaymentService(new PaymentRepository());
            }
            return _instance;
        }
    }
}
