using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using FinancialDocument.Domain.Core.Interfaces.Services;
using System;

namespace FinancialDocument.Domain.Core.Services
{
    public class BusinessPartnerService: IBusinessPartnerService
    {
        public IRepository<BusinessPartner> _repository { get; }

        public BusinessPartnerService(IRepository<BusinessPartner> repository)
        {
            _repository = repository;
        }

        public bool Exists(Guid Id)
        {
            return _repository.Exist(Id).Result;
        }
    }
}
