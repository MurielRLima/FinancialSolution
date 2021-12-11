using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using FinancialDocument.Domain.Core.Interfaces.Services;
using System;

namespace FinancialDocument.Domain.Core.Services
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
