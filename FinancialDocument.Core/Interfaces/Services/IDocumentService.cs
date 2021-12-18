using FinancialDocument.Domain.Entities;
using System;

namespace FinancialDocument.Domain.Interfaces.Services
{
    public interface IDocumentService
    {
        IRepository<Document> _repository { get; }

        Boolean Exists(Guid Id);
    }
}
