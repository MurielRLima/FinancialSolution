using FinancialDocument.Domain.Entities;
using System;

namespace FinancialDocument.Domain.Interfaces.Services
{
    public interface IReceivingLocationService
    {
        IRepository<ReceivingLocation> _repository { get; }

        Boolean Exists(Guid Id);
    }
}
