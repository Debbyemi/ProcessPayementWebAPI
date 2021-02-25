using ProcessPayementWebAPI.Interfaces;
using ProcessPayementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPayementWebAPI.Services
{
    public class PremiumPaymentService : IPremiumPaymentService
    {
        public async Task<bool> InitializePayment(ProcessPayment request)
        {
            return true;
        }
    }
}
