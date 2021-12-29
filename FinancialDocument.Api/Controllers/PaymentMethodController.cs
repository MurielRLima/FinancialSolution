using FinancialDocument.Service.Commands;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using FinancialDocument.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using FinancialDocument.Api.Examples.PaymentMethod;
using System.Net;
using Swashbuckle.AspNetCore.Filters;
using FinancialDocument.Api.Examples.JsonResponse;
using System.Collections.Generic;

namespace FinancialDocument.Api.Command.Controllers
{
    [Route("api/paymentmethod")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IRepository<PaymentMethod> _repository;
        private readonly IPaymentMethodService _service;
        private readonly ILogger<PaymentMethodController> _logger;

        public PaymentMethodController(IMediator mediator, IRepository<PaymentMethod> repository, IPaymentMethodService service, ILogger<PaymentMethodController> logger)
        {
            this._mediator = mediator;
            this._repository = repository;
            this._service = service;
            this._logger = logger;
        }

        /// <summary>
        /// Get all registers
        /// </summary>
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     GET api/paymentmethod/
        ///     
        /// </remarks>
        /// <returns>List of registers</returns>
        /// <response code="200">List of registers</response>
        [ProducesResponseType(200, Type = typeof(PaymentMethodGetAllResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(PaymentMethodGetAllResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [HttpGet]
        // GET: api/paymentmethod
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        /// <summary>
        /// Get one register by id
        /// </summary>
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     GET api/paymentmethod/13c6bf63-821d-427e-8baf-1d50482d521f
        ///     
        /// </remarks>
        /// <param name="id">13c6bf63-821d-427e-8baf-1d50482d521f</param>
        /// <returns>Register</returns>
        /// <response code="200">List of registers</response>
        [ProducesResponseType(200, Type = typeof(PaymentMethodGetResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(PaymentMethodGetResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        // GET api/paymentmethod/13c6bf63-821d-427e-8baf-1d50482d521f
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _repository.Get(id));
        }

        /// <summary>
        /// Get list of values of installments
        /// </summary>
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     GET api/paymentmethod/d819d8d6-a04a-4ce7-b290-143c79b9d625/installmentvalue/251.54
        ///     
        /// </remarks>
        /// <param name="id">d819d8d6-a04a-4ce7-b290-143c79b9d625</param>
        /// <param name="totalvalue">251.54</param>
        /// <returns>List of values</returns>
        /// <response code="200">List of values</response>
        [ProducesResponseType(200, Type = typeof(List<Double>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(List<Double>))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        // GET api/paymentmethod/d819d8d6-a04a-4ce7-b290-143c79b9d625/installmentvalue/251.54
        //[Route("{paymentmethodid}/installmentvalue/{value}")]
        [HttpGet("{id}/installmentvalue/{totalvalue}")]
        public async Task<IActionResult> GetInstallmentValue(string id, string totalvalue)
        {
            var paymentmethodid = Guid.Parse(id);
            var value = Double.Parse(totalvalue.Replace(".", ","));

            if (!_service.Exists(paymentmethodid))
            {
                _logger.LogWarning($"Register with id '{paymentmethodid.ToString()}' not found.");
                return BadRequest(JsonAppResponse.GetNotFound($"Register with id '{paymentmethodid.ToString()}' not found."));
            }

            var result = _service.GetInstallmentValue(paymentmethodid, value);
            return Ok(result);
        }

        /// <summary>
        /// Create a register
        /// </summary>
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     POST api/paymentmethod/
        ///     
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>Register created</returns>
        /// <response code="200">Register created</response>
        [ProducesResponseType(200, Type = typeof(PaymentMethodAddResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(PaymentMethodAddResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [SwaggerRequestExample(typeof(BusinessPartnerUpdateCommand), typeof(PaymentMethodAddCommandExample))]
        [HttpPost]
        // POST api/paymentmethod
        public async Task<IActionResult> Post(PaymentMethodAddCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Update a register
        /// </summary>
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     PUT api/paymentmethod/13c6bf63-821d-427e-8baf-1d50482d521f
        ///     
        /// </remarks>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <param name="value"></param>
        /// <returns>Register updated</returns>
        /// <response code="200">Register updated</response>
        /// <response code="400">Not found</response>
        [ProducesResponseType(200, Type = typeof(PaymentMethodUpdateResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(PaymentMethodUpdateResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [SwaggerRequestExample(typeof(BusinessPartnerUpdateCommand), typeof(PaymentMethodUpdateCommandExample))]
        [HttpPut("{id}")]
        // PUT api/paymentmethod/13c6bf63-821d-427e-8baf-1d50482d521f
        public async Task<IActionResult> Put(Guid id, [FromBody] PaymentMethodUpdateCommand command)
        {
            if (id.ToString() == "" || id == Guid.Empty)
            {
                _logger.LogWarning("Id parameter is null or invalid.");
                return BadRequest(JsonAppResponse.GetBadRequest("Id parameter is null or invalid."));
            }

            if (!_service.Exists(id))
            {
                _logger.LogWarning($"Register with id '{id.ToString()}' not found.");
                return BadRequest(JsonAppResponse.GetNotFound($"Register with id '{id.ToString()}' not found."));
            }

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Remove a register by id
        /// </summary>
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     DELETE api/paymentmethod/15241167-8bf8-41ea-a99f-0cd03acd0e65
        ///     
        /// </remarks>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <returns>Null</returns>
        /// <response code="200">Register updated</response>
        /// <response code="400">Not found</response>
        [ProducesResponseType(200, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(JsonAppResponseOkExample))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        // DELETE api/paymentmethod/15241167-8bf8-41ea-a99f-0cd03acd0e65
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id.ToString() == "" || id == Guid.Empty)
            {
                _logger.LogWarning("Id parameter is null or invalid.");
                return BadRequest(JsonAppResponse.GetBadRequest("Id parameter is null or invalid."));
            }

            if (!_service.Exists(id))
            {
                _logger.LogWarning($"Register with id '{id.ToString()}' not found.");
                return BadRequest(JsonAppResponse.GetNotFound($"Register with id '{id.ToString()}' not found."));
            }

            var command = new PaymentMethodDeleteCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
