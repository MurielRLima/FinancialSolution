using MediatR;
using System;

namespace FinancialDocument.Service.Commands
{
    public class ReceivingLocationDeleteCommand : IRequest<string>
    {
        public Guid Id { get; }

        public ReceivingLocationDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
