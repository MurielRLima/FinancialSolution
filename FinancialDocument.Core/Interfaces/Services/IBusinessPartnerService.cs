using FinancialDocument.Domain.Entities;
using System;

namespace FinancialDocument.Domain.Interfaces.Services
{
    public interface IBusinessPartnerService
    {
        IRepository<BusinessPartner> _repository { get; }

        Boolean Exists(Guid Id);
    }
}
