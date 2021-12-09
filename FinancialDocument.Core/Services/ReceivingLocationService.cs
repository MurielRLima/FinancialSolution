using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using FinancialDocument.Domain.Core.Interfaces.Services;
using System;

namespace FinancialDocument.Domain.Core.Services
{
    public class ReceivingLocationService : IReceivingLocationService
    {
        public IRepository<ReceivingLocation> _repository { get; }

        public ReceivingLocationService(IRepository<ReceivingLocation> repository)
        {
            _repository = repository;
        }

        public bool Exists(Guid Id)
        {
            return _repository.Exist(Id).Result; 
        }
    }
}
