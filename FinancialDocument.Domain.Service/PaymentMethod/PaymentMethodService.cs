using FinancialDocument.Core.Interfaces;
using FinancialDocument.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialDocument.Domain.Core.Interfaces.Services;

namespace FinancialDocument.Domain.Service.PaymentMethod
{
    public class PaymentMethodService: IPaymentMethodService
    {
        public IRepository<PaymentMethod> _repository { get; }

        public PaymentMethodService(IRepository<PaymentMethod> repository)
        {
            this._repository = repository;
        }
    }
}
