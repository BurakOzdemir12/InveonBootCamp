﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne.DIP
{
    internal interface IPaymentRepository
    {
         List<Payment> GetPayments();
    }
}