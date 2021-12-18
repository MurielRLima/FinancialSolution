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
        /// <returns></returns>
        // GET: api/<PaymentMethodController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        /// <summary>
        /// Get register by id
        /// </summary>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <returns></returns>
        // GET api/<PaymentMethodController>/13c6bf63-821d-427e-8baf-1d50482d521f
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _repository.Get(id));
        }

        /// <summary>
        /// Register a Payment method 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        // POST api/<PaymentMethodController>
        [HttpPost]
        public async Task<IActionResult> Post(PaymentMethodAddCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Edit a register
        /// </summary>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <param name="value"></param>
        // PUT api/<PaymentMethodController>/13c6bf63-821d-427e-8baf-1d50482d521f
        [HttpPut("{id}")]
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
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        // DELETE api/<PaymentMethodController>/13c6bf63-821d-427e-8baf-1d50482d521f
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
