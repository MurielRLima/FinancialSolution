using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using System;

namespace FinancialDocument.Domain.Core.Interfaces.Services
{
    public interface IPaymentMethodService
    {
        IRepository<PaymentMethod> _repository { get; }

        Boolean Exists(Guid Id);
    }
}
