using FinancialDocument.Api.Commands;
using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using FinancialDocument.Domain.Core.Interfaces.Services;
using FinancialDocument.Domain.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FinancialSolution.Api.Controllers
{
    [Route("api/financialdocument")]
    [Produces("application/json")]
    [ApiController]
    public class FinancialDocumentController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IRepository<Document> _repository;
        private readonly IDocumentService _service;
        private readonly ILogger<FinancialDocumentController> _logger;

        public FinancialDocumentController(IMediator mediator, IRepository<Document> repository, IDocumentService service, ILogger<FinancialDocumentController> logger)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); 
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this._service = service ?? throw new ArgumentNullException(nameof(service));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all registers
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo:
        /// 
        ///     Get /financialdocument
        ///     
        /// </remarks>
        /// <returns>List of regtisters</returns>
        /// <response code="200">List of regtisters</response>
        /// <response code="401">Unathorized</response>
        // GET: api/financialdocument
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        /// <summary>
        /// Get register by id
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo:
        /// 
        ///     Get /financialdocument/13c6bf63-821d-427e-8baf-1d50482d521f
        ///     
        /// </remarks>
        /// <returns>One regtister</returns>
        /// <response code="200">Register</response>
        /// <response code="401">Unathorized</response>
        /// <returns></returns>
        // GET api/financialdocument/13c6bf63-821d-427e-8baf-1d50482d521f
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _repository.Get(id));
        }


        /// <summary>
        /// Create a register
        /// </summary>
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     Post /financialdocument
        ///     {
        ///       "documentNumber": "Doc.Test",
        ///       "businessPartnerId": "6d357424-cf26-4efc-8723-b92c4ed4ca1b",
        ///       "documentType": "D",
        ///       "issueDate": "2021-12-11T19:12:02.287Z",
        ///       "dueDate": "2021-12-11T19:12:02.287Z",
        ///       "amount": 1255.55,
        ///       "paymentMethodId": "d819d8d6-a04a-4ce7-b290-143c79b9d625",
        ///       "receivingLocationId": "efa1e8f7-3df9-45a3-855e-a904cd132ce7",
        ///       "observation": null,
        ///       "settled": false,
        ///       "active": true,
        ///       "documentDetails": [
        ///         {
        ///           "operationType": "C",
        ///           "date": "2021-12-11T19:12:02.287Z",
        ///           "value": 550,
        ///           "observation": "entrada",
        ///           "active": true
        ///         }
        ///       ]
        ///     }
        ///     
        /// </remarks>
        /// <returns>Register created</returns>
        /// <response code="200">Register created</response>
        /// <response code="401">Unathorized</response>
        /// <response code="500">Internal error</response>
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DocumentAddResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonResult))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
        [HttpPost]
        public async Task<IActionResult> Post(DocumentAddCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Edit a register
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo:
        /// 
        ///     Put /financialdocument/15241167-8bf8-41ea-a99f-0cd03acd0e65
        ///     
        /// </remarks>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <param name="value"></param>
        /// <returns>Register updated</returns>
        /// <response code="200">Register updated</response>
        /// <response code="401">Unathorized</response>
        // PUT api/financialdocument/13c6bf63-821d-427e-8baf-1d50482d521f
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
        /// <remarks>
        /// 
        /// Exemplo:
        /// 
        ///     Delete /financialdocument/15241167-8bf8-41ea-a99f-0cd03acd0e65
        ///     
        /// </remarks>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="401">Unathorized</response>
        // DELETE api/financialdocument/13c6bf63-821d-427e-8baf-1d50482d521f
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
