using MediatR;
using System;

namespace FinancialDocument.Api.Commands
{
    public class BusinessPartnerDeleteCommand : IRequest<string>
    {
        public Guid Id { get; }

        public BusinessPartnerDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
