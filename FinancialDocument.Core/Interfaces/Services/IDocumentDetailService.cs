using FinancialDocument.Domain.Entities;
using System;

namespace FinancialDocument.Domain.Interfaces.Services
{
    public interface IDocumentDetailService
    {
        IRepository<DocumentDetail> _repository { get; }

        Boolean Exists(Guid Id);
    }
}
