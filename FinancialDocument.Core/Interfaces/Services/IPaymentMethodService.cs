using FinancialDocument.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialDocument.Domain.Interfaces.Services
{
    public interface IPaymentMethodService
    {
        IRepository<PaymentMethod> _repository { get; }
        List<Double> GetInstallmentValue(Guid PaymentMethodId, double value);
        Boolean Exists(Guid Id);
    }
}
