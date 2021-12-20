using FinancialDocument.Service.Commands;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace FinancialDocument.Api.Examples.PaymentMethod
{
    public class PaymentMethodGetAllResponseExample : IExamplesProvider<List<PaymentMethodAddResponse>>
    {
        public List<PaymentMethodAddResponse> GetExamples()
        {
            var r = new List<PaymentMethodAddResponse>();
            r.Add(new PaymentMethodAddResponse()
            {
                Id = Guid.NewGuid(),
                Description = "Debit card",
                Observation = "Some observation text",
                Active = true
            });

            r.Add(new PaymentMethodAddResponse()
            {
                Id = Guid.NewGuid(),
                Description = "Credit card",
                Observation = "Some observation text",
                Active = true
            });

            return r;
        }
    }

    public class PaymentMethodAddCommandExample : IExamplesProvider<PaymentMethodAddCommand>
    {
        public PaymentMethodAddCommand GetExamples()
        {
            return new PaymentMethodAddCommand()
            {
                //Id = Guid.NewGuid(),
                Description = "Credit card 8x",
                Observation = "Some observation text",
                Active = true
            };
        }
    }

    public class PaymentMethodAddResponseExample : IExamplesProvider<PaymentMethodAddResponse>
    {
        public PaymentMethodAddResponse GetExamples()
        {
            return new PaymentMethodAddResponse()
            {
                Id = Guid.NewGuid(),
                Description = "Credit card 8x",
                Observation = "Some observation text",
                Active = true
            };
        }
    }

    public class PaymentMethodGetResponseExample : IExamplesProvider<PaymentMethodAddResponse>
    {
        public PaymentMethodAddResponse GetExamples()
        {
            return new PaymentMethodAddResponse()
            {
                Id = Guid.Parse("13c6bf63-821d-427e-8baf-1d50482d521f"),
                Description = "Credit card 10x",
                Observation = "Some observation text",
                Active = true
            };
        }
    }


    public class PaymentMethodUpdateCommandExample : IExamplesProvider<PaymentMethodUpdateCommand>
    {
        public PaymentMethodUpdateCommand GetExamples()
        {
            return new PaymentMethodUpdateCommand()
            {
                Id = Guid.Parse("15241167-8bf8-41ea-a99f-0cd03acd0e65"),
                Description = "Credit card 10x",
                Observation = "Some observation text",
                Active = true
            };
        }
    }

    public class PaymentMethodUpdateResponseExample : IExamplesProvider<PaymentMethodUpdateResponse>
    {
        public PaymentMethodUpdateResponse GetExamples()
        {
            return new PaymentMethodUpdateResponse()
            {
                Id = Guid.Parse("15241167-8bf8-41ea-a99f-0cd03acd0e65"),
                Description = "Credit card 10x",
                Observation = "Some observation text",
                Active = true
            };
        }
    }
}
