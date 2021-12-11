using FinancialDocument.Api.Commands;
using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using FinancialDocument.Domain.Core.Interfaces.Services;
using FinancialDocument.Domain.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FinancialSolution.Api.Controllers
{
    [Route("api/businesspartner")]
    [ApiController]
    public class BusinessPartnerController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IRepository<BusinessPartner> _repository;
        private readonly IBusinessPartnerService _service;
        private readonly ILogger<BusinessPartnerController> _logger;

        public BusinessPartnerController(IMediator mediator, IRepository<BusinessPartner> repository, IBusinessPartnerService service, ILogger<BusinessPartnerController> logger)
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
        // GET: api/<BusinessPartnerController>
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
        // GET api/<BusinessPartnerController>/13c6bf63-821d-427e-8baf-1d50482d521f
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
        // POST api/<BusinessPartnerController>
        [HttpPost]
        public async Task<IActionResult> Post(BusinessPartnerAddCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Edit a register
        /// </summary>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <param name="value"></param>
        // PUT api/<BusinessPartnerController>/13c6bf63-821d-427e-8baf-1d50482d521f
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] BusinessPartnerUpdateCommand command)
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
        // DELETE api/<BusinessPartnerController>/13c6bf63-821d-427e-8baf-1d50482d521f
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

            var command = new BusinessPartnerDeleteCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
