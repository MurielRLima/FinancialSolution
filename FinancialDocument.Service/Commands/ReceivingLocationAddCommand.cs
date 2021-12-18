using FinancialDocument.Domain.Entities;
using MediatR;
using System;

namespace FinancialDocument.Service.Commands
{
    public class ReceivingLocationAddCommand : IRequest<string>
    {
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }

        public static ReceivingLocation MapTo(ReceivingLocationAddCommand model)
        {
            return new ReceivingLocation()
            {
                Id = Guid.NewGuid(),
                Description = model.Description,
                Observation = model.Observation,
                Active = model.Active
            };
        }
    }
}
