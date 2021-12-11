using MediatR;
using System;

namespace FinancialDocument.Api.Commands
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
