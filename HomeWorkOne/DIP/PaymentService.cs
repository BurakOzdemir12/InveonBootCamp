using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne.DIP
{
    internal class PaymentService: IPaymentService
    {
        IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public List <Payment> GetPayments()
        { 

            var paymentList = _paymentRepository.GetPayments();

            foreach (var payment in paymentList) 
            {
                payment.amount = payment.amount - (payment.amount * 0.08m); 
            }

            return paymentList;
        }
    }
}
