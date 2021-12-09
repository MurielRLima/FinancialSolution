using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using FinancialDocument.Domain.Core.Interfaces.Services;
using System;

namespace FinancialDocument.Domain.Core.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        public IRepository<PaymentMethod> _repository { get; }

        public PaymentMethodService(IRepository<PaymentMethod> repository)
        {
            _repository = repository;
        }

        public bool Exists(Guid Id)
        {
            return _repository.Exist(Id).Result;
        }
    }
}
