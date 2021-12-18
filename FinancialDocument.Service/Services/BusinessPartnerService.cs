using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using System;

namespace FinancialDocument.Service.Services
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
