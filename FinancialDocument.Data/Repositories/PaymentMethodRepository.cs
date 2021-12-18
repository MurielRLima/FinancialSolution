using FinancialDocument.Domain.Entities;
using FinancialDocument.Data.Context;

namespace FinancialDocument.Data.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod>
    {
        public PaymentMethodRepository(AppDbContext context) : base(context)
        {
        }
    }
}
