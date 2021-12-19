using FinancialDocument.Domain.Exceptions;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace FinancialDocument.Api.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment env;

        ILogger Logger;

        public HttpGlobalExceptionFilter(
            ILoggerFactory loggerFactory,
            IWebHostEnvironment env)
        {
            Logger = loggerFactory.CreateLogger<HttpGlobalExceptionFilter>();
            this.env = env;
        }

        public void OnException(ExceptionContext context)
        {
            Logger.LogError("-- FinancialDocument.Error Type: {Type} Error: {Error}",
                            context.Exception.GetType(),
                            context.Exception.Message);

            IJsonAppResponse json = null;

            if (context.Exception.GetType() == typeof(FinancialValidationException))
            {
                json = JsonAppResponse.GetBadRequest(context.Exception.Message);
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if ((context.Exception.GetType() == typeof(FinancialNotFoundException)) || (context.Exception.GetType() == typeof(FormatException)))
            {
                json = JsonAppResponse.GetBadRequest(context.Exception.Message);
                context.Result = new NotFoundObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception.GetType() == typeof(FinancialInternalException))
            {
                json = JsonAppResponse.GetInternalError(context.Exception.Message);
                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                json = JsonAppResponse.GetInternalError($"An error occur. {context.Exception}");
                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.ExceptionHandled = true;
        }
    }

    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error) : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
