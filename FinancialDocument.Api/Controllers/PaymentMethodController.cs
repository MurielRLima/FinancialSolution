using FinancialSolution.Domain.Interfaces.Business;
using FinancialSolution.Domain.Model.Response;
using FinancialSolution.Domain.Model.Resquest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Swashbuckle.AspNetCore.Annotations;
//using Swashbuckle.AspNetCore.Examples;
using System;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialSolution.Api.Controllers
{

    //[Authorize]
    //[Route("v{version:apiVersion}/paymentmethod")]
    //[SwaggerTag("Api para forma de pagamento")]
    [Route("api/paymentmethod")]
    [Produces("application/json")]
    [ApiVersion("1")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodBusiness _paymentMethodBusiness;
        private readonly ILogger<PaymentMethodController> _logger;

        public PaymentMethodController(IPaymentMethodBusiness paymentMethodBusiness, ILogger<PaymentMethodController> logger)
        {
            _paymentMethodBusiness = paymentMethodBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os registros de forma de pagamento
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo:
        /// 
        ///     GET /paymentmethod
        ///     
        /// </remarks>
        /// <returns>Lista de registro</returns>
        /// <response code="200">Lista de forma de pagamento</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="500">Erro interno</response>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PaymentMethodResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(AppJsonResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(AppJsonResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(AppJsonResponse))]
        //[SwaggerResponseExample((int)HttpStatusCode.OK, typeof(PaymentMethodResponseExample))]
        //[SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(ConsultDocumentUnauthorizedExample))]
        //[SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(ConsultDocumentInternalServerErrorExample))]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _paymentMethodBusiness.Get();
            return Ok(result);
        }

        // GET api/<PaymentMethod>/164a0e3b-85e5-45be-821e-4445165ea35c
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _paymentMethodBusiness.Get(id);
            return Ok(result);
        }

        // POST api/<PaymentMethod>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentMethodRequest value)
        {
            await _paymentMethodBusiness.Post(value);
            return Ok();
        }

        // PUT api/<PaymentMethod>/164a0e3b-85e5-45be-821e-4445165ea35c
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PaymentMethodRequest value)
        {
            return Ok(_paymentMethodBusiness.Put(id, value));
        }

        // DELETE api/<PaymentMethod>/164a0e3b-85e5-45be-821e-4445165ea35c
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(_paymentMethodBusiness.Delete(id));
        }
    }
}
