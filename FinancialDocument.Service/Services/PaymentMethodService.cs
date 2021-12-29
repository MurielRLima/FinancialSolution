using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public List<Double> GetInstallmentValue(Guid PaymentMethodId, double value)
        {
            var paymentMethod = _repository.Get(PaymentMethodId).Result;
            var r = paymentMethod.GetInstallmentsValue(value);
            return r;
        }
    }
}
