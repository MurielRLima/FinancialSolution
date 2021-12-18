using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using System;

namespace FinancialDocument.Service.Services
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
