using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using System;

namespace FinancialDocument.Service.Services
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
