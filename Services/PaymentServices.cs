using ProcessPayementWebAPI.Interfaces;
using ProcessPayementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessPayementWebAPI.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IPremiumPaymentService _premiumPaymentService;
        public PaymentServices(ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway, IPremiumPaymentService premiumPaymentService)
        {
            _expensivePaymentGateway = expensivePaymentGateway;
            _cheapPaymentGateway = cheapPaymentGateway;
            _premiumPaymentService = premiumPaymentService;
        }
        public async Task<ProcessPayment> ProcessPayment(ProcessPayment request)
        {
            if (request.IsCheapPaymentGateway()) await _cheapPaymentGateway.InitializePayment(request);
            else if (request.IsExpensivePaymentGateway())
            {
                await _expensivePaymentGateway.InitializePayment(request);
            }
            else if (request.IsPremiumPaymentService())
            {
                await _premiumPaymentService.InitializePayment(request);
            }
            return new ProcessPayment { };
        }

    }
}
