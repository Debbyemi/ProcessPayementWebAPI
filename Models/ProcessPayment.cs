using ProcessPayementWebAPI.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProcessPayementWebAPI.Models
{
    public class ProcessPayment
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "CreditCardNumber is mandatory")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "CardHolder is mandatory")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "ExpirationDate is mandatory")]
        public DateTime ExpirationDate { get; set; }

        [StringLength(3, ErrorMessage = "Security Code must be 3 digits")]

        [MinLength(3, ErrorMessage = "Security Code must be 3 digits")]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage = "Amount is mandatory")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public decimal Amount { get; set; }

        [JsonIgnore]
        public ProcessState ProcessState { get; set; }

        public string Message { get; set; }

        private bool IsExpiryDateValid()
        { 
            return DateTime.Now >= ExpirationDate ? true : false;
        }

        private bool IsCreditCardNumberValid()
        {
            return true;
        }

        internal bool IsCheapPaymentGateway()
        {
            return Amount <= 20 ? true : false;
        }
        internal bool IsExpensivePaymentGateway()
        {
            if (Amount >= 21 && Amount <= 500)
                return true;
            else
               return false;
           //return Enumerable.Range(25, 500).Contains(Amount)? true : false;
        }
        internal bool IsPremiumPaymentService()
        {
            return Amount > 500 ? true : false;
        }
    }

   
}
