using MediatR;
using System;

namespace FinancialDocument.Api.Commands
{
    public class PaymentMethodDeleteCommand : IRequest<string>
    {
        public Guid Id { get; }

        public PaymentMethodDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
