using FinancialDocument.Domain.Core.Interfaces;

namespace FinancialDocument.Domain.Core.Response
{
    public class JsonAppResponse : IJsonAppResponse
    {
        public string code { get; set; }
        public string description { get; set; }

        public static IJsonAppResponse CreateCustomResponse(string cod, string message)
        {
            return new JsonAppResponse() { code = cod, description = message};
        }
        public static IJsonAppResponse GetBadRequest(string message = "Invalid request.")
        {
            return new JsonAppResponse() { code = "invalid_request", description = message };
        }
        public static IJsonAppResponse GetNotFound(string message = "Register not found")
        {
            return new JsonAppResponse() { code = "not_found", description = message };
        }
        public static IJsonAppResponse GetUnauthorized(string message = "Unauthorized")
        {
            return new JsonAppResponse() { code = "unauthorized", description = message };
        }
        public static IJsonAppResponse GetInternalError(string message = "Internal error")
        {
            return new JsonAppResponse() { code = "internal_error", description = message };
        }
    }
}
