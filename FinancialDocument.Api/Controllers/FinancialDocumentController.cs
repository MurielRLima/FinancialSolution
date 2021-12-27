using FinancialDocument.Service.Commands;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using FinancialDocument.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Filters;
using FinancialDocument.Api.Examples.Document;
using FinancialDocument.Api.Examples.JsonResponse;

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
        /// Example:
        /// 
        ///     GET api/financialdocument/
        ///     
        /// </remarks>
        /// <returns>List of registers</returns>
        /// <response code="200">List of registers</response>
        [ProducesResponseType(200, Type = typeof(DocumentGetAllResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(DocumentGetAllResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [HttpGet]
        // GET: api/financialdocument
        [HttpGet]
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
        ///     GET api/financialdocument/15241167-8bf8-41ea-a99f-0cd03acd0e65
        ///     
        /// </remarks>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <returns>Register</returns>
        /// <response code="200">List of registers</response>
        [ProducesResponseType(200, Type = typeof(DocumentGetResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(DocumentGetResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        // GET api/financialdocument/13c6bf63-821d-427e-8baf-1d50482d521f
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _repository.Get(id));
        }


        /// <summary>
        /// Create a register
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A newly created register</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /financialdocument
        ///     
        /// </remarks>
        /// <response code="200">Returns the newly created register</response>
        /// <response code="400">If the command is null</response>
        /// <response code="401">Unathorized</response>
        /// <response code="500">Internal error</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DocumentAddResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonResult))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(DocumentResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [SwaggerRequestExample(typeof(BusinessPartnerUpdateCommand), typeof(DocumentAddCommandExample))]

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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DocumentUpdateResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonResult))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonResult))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonResult))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(DocumentResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [SwaggerRequestExample(typeof(BusinessPartnerUpdateCommand), typeof(DocumentUpdateCommandExample))]
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
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
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
