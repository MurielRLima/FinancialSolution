using FinancialDocument.Domain.Entities;
using MediatR;
using System;

namespace FinancialDocument.Service.Commands
{
    public class ReceivingLocationUpdateCommand : IRequest<ReceivingLocationUpdateResponse>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool Active { get; set; }

        public static ReceivingLocation MapTo(ReceivingLocationUpdateCommand model)
        {
            return new ReceivingLocation()
            {
                Id = model.Id,
                Description = model.Description,
                Observation = model.Observation,
                Active = model.Active
            };
        }
    }

    public class ReceivingLocationUpdateResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }

        public static ReceivingLocationUpdateResponse MapTo(ReceivingLocation model)
        {
            return new ReceivingLocationUpdateResponse()
            {
                Id = model.Id,
                Description = model.Description,
                Observation = model.Observation,
                Active = model.Active
            };
        }
    }
}
