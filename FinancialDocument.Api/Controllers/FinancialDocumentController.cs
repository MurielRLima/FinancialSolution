using FinancialDocument.Api.Commands;
using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using FinancialDocument.Domain.Core.Interfaces.Services;
using FinancialDocument.Domain.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialSolution.Api.Controllers
{
    [Route("api/financialdocument")]
    [ApiController]
    public class FinancialDocumentController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Document> _repository;
        private readonly IDocumentService _service;
        private readonly ILogger<FinancialDocumentController> _logger;

        public FinancialDocumentController(IMediator mediator, IRepository<Document> repository, IDocumentService service, ILogger<FinancialDocumentController> logger)
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
        // GET: api/<FinancialDocumentController>
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
        // GET api/<FinancialDocumentController>/13c6bf63-821d-427e-8baf-1d50482d521f
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
        // POST api/<FinancialDocumentController>
        [HttpPost]
        public async Task<IActionResult> Post(DocumentAddCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Edit a register
        /// </summary>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <param name="value"></param>
        // PUT api/<FinancialDocumentController>/13c6bf63-821d-427e-8baf-1d50482d521f
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] DocumentUpdateCommand command)
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
        // DELETE api/<FinancialDocumentController>/13c6bf63-821d-427e-8baf-1d50482d521f
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

            var command = new DocumentDeleteCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
