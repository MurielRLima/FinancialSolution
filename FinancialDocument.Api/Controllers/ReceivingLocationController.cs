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
using FinancialDocument.Api.Examples.ReceivingLocation;
using System.Net;
using Swashbuckle.AspNetCore.Filters;
using FinancialDocument.Api.Examples.JsonResponse;

namespace FinancialSolution.Api.Controllers
{
    [Route("api/receivinglocation")]
    [ApiController]
    public class ReceivingLocationController: ControllerBase
    {
        readonly IMediator _mediator;
        private readonly IRepository<ReceivingLocation> _repository;
        private readonly IReceivingLocationService _service;
        private readonly ILogger<ReceivingLocationController> _logger;

        public ReceivingLocationController(IMediator mediator, IRepository<ReceivingLocation> repository, IReceivingLocationService service, ILogger<ReceivingLocationController> logger)
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
        ///     GET api/receivinglocation/
        ///     
        /// </remarks>
        /// <returns>List of registers</returns>
        /// <response code="200">List of registers</response>
        [ProducesResponseType(200, Type = typeof(ReceivingLocationGetAllResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ReceivingLocationGetAllResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [HttpGet]
        // GET: api/receivinglocation
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
        ///     GET api/receivinglocation/13c6bf63-821d-427e-8baf-1d50482d521f
        ///     
        /// </remarks>
        /// <param name="id">13c6bf63-821d-427e-8baf-1d50482d521f</param>
        /// <returns>Register</returns>
        /// <response code="200">List of registers</response>
        [ProducesResponseType(200, Type = typeof(ReceivingLocationGetResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ReceivingLocationGetResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        // GET api/receivinglocation/13c6bf63-821d-427e-8baf-1d50482d521f
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
        ///     POST api/receivinglocation/
        ///     
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>Register created</returns>
        /// <response code="200">Register created</response>
        [ProducesResponseType(200, Type = typeof(ReceivingLocationAddResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ReceivingLocationAddResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [SwaggerRequestExample(typeof(BusinessPartnerUpdateCommand), typeof(ReceivingLocationAddCommandExample))]
        [HttpPost]
        public async Task<IActionResult> Post(ReceivingLocationAddCommand command)
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
        ///     PUT api/receivinglocation/15241167-8bf8-41ea-a99f-0cd03acd0e65
        ///     
        /// </remarks>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <param name="value"></param>
        /// <returns>Register updated</returns>
        /// <response code="200">Register updated</response>
        /// <response code="400">Not found</response>
        [ProducesResponseType(200, Type = typeof(ReceivingLocationUpdateResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(ReceivingLocationUpdateResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [SwaggerRequestExample(typeof(BusinessPartnerUpdateCommand), typeof(ReceivingLocationUpdateCommandExample))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ReceivingLocationUpdateCommand command)
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
        ///     DELETE api/receivinglocation/15241167-8bf8-41ea-a99f-0cd03acd0e65
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
        // DELETE api/receivinglocation/15241167-8bf8-41ea-a99f-0cd03acd0e65
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

            var command = new ReceivingLocationDeleteCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
