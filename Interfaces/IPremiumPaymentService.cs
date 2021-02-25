﻿using ProcessPayementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPayementWebAPI.Interfaces
{
    public interface IPremiumPaymentService
    {

        Task<bool> InitializePayment(ProcessPayment request);
    }
}
