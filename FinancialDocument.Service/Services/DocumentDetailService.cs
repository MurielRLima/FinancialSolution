using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using System;

namespace FinancialDocument.Service.Services
{
    public class DocumentDetailService: IDocumentDetailService
    {
        public IRepository<DocumentDetail> _repository { get; }

        public DocumentDetailService(IRepository<DocumentDetail> repository)
        {
            _repository = repository;
        }

        public bool Exists(Guid Id)
        {
            return _repository.Exist(Id).Result;
        }
    }
}
