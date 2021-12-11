using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using System;

namespace FinancialDocument.Domain.Core.Interfaces.Services
{
    public interface IBusinessPartnerService
    {
        IRepository<BusinessPartner> _repository { get; }

        Boolean Exists(Guid Id);
    }
}
