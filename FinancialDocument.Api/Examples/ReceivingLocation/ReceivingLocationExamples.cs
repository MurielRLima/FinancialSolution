using FinancialDocument.Service.Commands;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace FinancialDocument.Api.Examples.ReceivingLocation
{
    public class ReceivingLocationGetAllResponseExample : IExamplesProvider<List<ReceivingLocationAddResponse>>
    {
        public List<ReceivingLocationAddResponse> GetExamples()
        {
            var r = new List<ReceivingLocationAddResponse>();
            r.Add(new ReceivingLocationAddResponse()
            {
                Id = Guid.NewGuid(),
                Description = "PDV 1",
                Observation = "Some observation text",
                Active = true
            });

            r.Add(new ReceivingLocationAddResponse()
            {
                Id = Guid.NewGuid(),
                Description = "Union bank",
                Observation = "Some observation text",
                Active = true
            });

            return r;
        }
    }

    public class ReceivingLocationAddCommandExample : IExamplesProvider<ReceivingLocationAddCommand>
    {
        public ReceivingLocationAddCommand GetExamples()
        {
            return new ReceivingLocationAddCommand()
            {
                //Id = Guid.NewGuid(),
                Description = "PDV 1",
                Observation = "Some observation text",
                Active = true
            };
        }
    }

    public class ReceivingLocationAddResponseExample : IExamplesProvider<ReceivingLocationAddResponse>
    {
        public ReceivingLocationAddResponse GetExamples()
        {
            return new ReceivingLocationAddResponse()
            {
                Id = Guid.NewGuid(),
                Description = "PDV 1",
                Observation = "Some observation text",
                Active = true
            };
        }
    }

    public class ReceivingLocationGetResponseExample : IExamplesProvider<ReceivingLocationAddResponse>
    {
        public ReceivingLocationAddResponse GetExamples()
        {
            return new ReceivingLocationAddResponse()
            {
                Id = Guid.Parse("13c6bf63-821d-427e-8baf-1d50482d521f"),
                Description = "PDV 1",
                Observation = "Some observation text",
                Active = true
            };
        }
    }


    public class ReceivingLocationUpdateCommandExample : IExamplesProvider<ReceivingLocationUpdateCommand>
    {
        public ReceivingLocationUpdateCommand GetExamples()
        {
            return new ReceivingLocationUpdateCommand()
            {
                Id = Guid.Parse("15241167-8bf8-41ea-a99f-0cd03acd0e65"),
                Description = "PDV 1",
                Observation = "Some observation text",
                Active = true
            };
        }
    }

    public class ReceivingLocationUpdateResponseExample : IExamplesProvider<ReceivingLocationUpdateResponse>
    {
        public ReceivingLocationUpdateResponse GetExamples()
        {
            return new ReceivingLocationUpdateResponse()
            {
                Id = Guid.Parse("15241167-8bf8-41ea-a99f-0cd03acd0e65"),
                Description = "PDV 1",
                Observation = "Some observation text",
                Active = true
            };
        }
    }
}
