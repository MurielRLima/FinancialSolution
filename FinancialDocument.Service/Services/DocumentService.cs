using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using System;

namespace FinancialDocument.Service.Services
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
