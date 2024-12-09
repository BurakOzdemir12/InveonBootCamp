using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne
{
    internal class Isp
    {
        public interface IOnlinePayment
        {
            void OnlinePay(decimal amount);
        }
        public interface IMobilePayment
        {
            void MobilePay(decimal amount);

        }
        public interface IBankTransfer
        {
            void BankTransfer(decimal amount,string accountNumber);
        }

        public class CreditCardPayment : IOnlinePayment, IMobilePayment
        {
            public void MobilePay(decimal amount)
            {
                Console.WriteLine($"Credit Card Mobile Payment {amount} complited");
            }

            public void OnlinePay(decimal amount)
            {
                Console.WriteLine($"Credit Card Online Payment {amount} complited");
            }
        }
        public class BankTransferPayment : IBankTransfer
        {
            public void BankTransfer(decimal amount, string accountNumber)
            {
                Console.WriteLine($"EFT/IBAN Transfer Payment, {amount} send to this account {accountNumber}");
            }
        }
    }
}
