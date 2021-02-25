using Microsoft.AspNetCore.Mvc;
using ProcessPayementWebAPI.Enum;
using ProcessPayementWebAPI.Interfaces;
using ProcessPayementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProcessPayementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;
        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }
        // POST api/<PaymentController>
        [HttpPost("ProcessPayment")]
        public async Task<ActionResult<ProcessPayment>>Post([FromBody] ProcessPayment request )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Request Invalid");
                var result = await _paymentServices.ProcessPayment(request);
                if (result.ProcessState.Equals(ProcessState.processed))
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }



        }


      
    }
}
