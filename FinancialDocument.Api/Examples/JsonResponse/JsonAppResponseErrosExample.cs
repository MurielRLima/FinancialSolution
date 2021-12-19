using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Response;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace FinancialDocument.Api.Examples.JsonResponse
{
    public class JsonAppResponseErrosExample : IMultipleExamplesProvider<IJsonAppResponse>
    {
        public IEnumerable<SwaggerExample<IJsonAppResponse>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "Bad request",
                JsonAppResponse.GetBadRequest($"Id parameter is null or invalid.")
            );

            yield return SwaggerExample.Create(
                "Invalid data",
                JsonAppResponse.GetBadRequest($"Some data is invalid.")
            );
        }
    }

    public class JsonAppResponseInternalExample : IExamplesProvider<IJsonAppResponse>
    {
        public IJsonAppResponse GetExamples()
        {
            return JsonAppResponse.GetInternalError();
        }
    }

    public class JsonAppResponseUnauthorizedExample : IExamplesProvider<IJsonAppResponse>
    {
        public IJsonAppResponse GetExamples()
        {
            return JsonAppResponse.GetUnauthorized();
        }
    }

    public class JsonAppResponseNotExample : IExamplesProvider<IJsonAppResponse>
    {
        public IJsonAppResponse GetExamples()
        {
            return JsonAppResponse.GetNotFound();
        }
    }

    public class JsonAppResponseOkExample : IExamplesProvider<IJsonAppResponse>
    {
        public IJsonAppResponse GetExamples()
        {
            return JsonAppResponse.CreateCustomResponse("success", "Ok");
        }
    }

}
