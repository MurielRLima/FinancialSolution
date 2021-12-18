using FinancialDocument.Domain.Entities;
using System;

namespace FinancialDocument.Domain.Interfaces.Services
{
    public interface IPaymentMethodService
    {
        IRepository<PaymentMethod> _repository { get; }

        Boolean Exists(Guid Id);
    }
}
