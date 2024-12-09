using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne.DIP
{
    internal class PaymentsController
    {
        private IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public List<Payment> GetPayments()
        {
            return _paymentService.GetPayments();
        }
    }
}
