using MediatR;
using System;

namespace FinancialDocument.Service.Commands
{
    public class DocumentDeleteCommand : IRequest<string>
    {
        public Guid Id { get; }

        public DocumentDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
