using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using FinancialDocument.Domain.Core.Interfaces.Services;
using System;

namespace FinancialDocument.Domain.Core.Services
{
    public class DocumentService : IDocumentService
    {
        public IRepository<Document> _repository { get; }

        public DocumentService(IRepository<Document> repository)
        {
            _repository = repository;
        }

        public bool Exists(Guid Id)
        {
            return _repository.Exist(Id).Result;
        }
    }
}
