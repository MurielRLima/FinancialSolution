using FinancialDocument.Core.Entities;
using MediatR;
using System;

namespace FinancialDocument.Api.Commands
{
    public class PaymentMethodAddCommand: IRequest<string>
    {
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public int Installments { get; set; }

        public static PaymentMethod MapTo(PaymentMethodAddCommand model)
        {
            return new PaymentMethod() {
                Id = Guid.NewGuid(),
                Description = model.Description,
                Observation = model.Observation,
                Active = model.Active,
                Installments = model.Installments
            };
        }
    }
}
