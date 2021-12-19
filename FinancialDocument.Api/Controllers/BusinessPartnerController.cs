using FinancialDocument.Api.Examples.BusinessPartner;
using FinancialDocument.Api.Examples.JsonResponse;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using FinancialDocument.Domain.Response;
using FinancialDocument.Service.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Net;
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
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     GET api/businesspartner/
        ///     
        /// </remarks>
        /// <returns>List of registers</returns>
        /// <response code="200">List of registers</response>
        [ProducesResponseType(200, Type = typeof(BusinessPartnerGetAllResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(BusinessPartnerGetAllResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [HttpGet]
        // GET: api/businesspartner
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
        ///     GET api/businesspartner/15241167-8bf8-41ea-a99f-0cd03acd0e65
        ///     
        /// </remarks>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <returns>Register</returns>
        /// <response code="200">List of registers</response>
        [ProducesResponseType(200, Type = typeof(BusinessPartnerGetResponseExample))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(BusinessPartnerGetResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [HttpGet("{id}")]
        // GET api/businesspartner/15241167-8bf8-41ea-a99f-0cd03acd0e65
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
        ///     POST api/businesspartner/
        ///     
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>Register created</returns>
        /// <response code="200">Register created</response>
        [ProducesResponseType(200, Type = typeof(BusinessPartnerAddResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(BusinessPartnerResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [SwaggerRequestExample(typeof(BusinessPartnerUpdateCommand), typeof(BusinessPartnerAddCommandExample))]
        [HttpPost]
        public async Task<IActionResult> Post(BusinessPartnerAddCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }



        /// <summary>
        /// Edit a register
        /// </summary>
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     PUT api/businesspartner/15241167-8bf8-41ea-a99f-0cd03acd0e65
        ///     
        /// </remarks>
        /// <param name="id">15241167-8bf8-41ea-a99f-0cd03acd0e65</param>
        /// <param name="value"></param>
        /// <returns>Register updated</returns>
        /// <response code="200">Register updated</response>
        /// <response code="400">Not found</response>
        [ProducesResponseType(200, Type = typeof(BusinessPartnerUpdateResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(JsonAppResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(JsonAppResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(BusinessPartnerResponseExample))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(JsonAppResponseErrosExample))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(JsonAppResponseNotExample))]
        [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(JsonAppResponseUnauthorizedExample))]
        [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(JsonAppResponseInternalExample))]
        [SwaggerRequestExample(typeof(BusinessPartnerUpdateCommand), typeof(BusinessPartnerUpdateCommandExample))]
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
        /// <remarks>
        /// 
        /// Example:
        /// 
        ///     DELETE api/businesspartner/15241167-8bf8-41ea-a99f-0cd03acd0e65
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
        // DELETE api/businesspartner/15241167-8bf8-41ea-a99f-0cd03acd0e65
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
