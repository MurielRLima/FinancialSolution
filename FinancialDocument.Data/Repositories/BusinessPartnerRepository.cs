using FinancialDocument.Core.Entities;
using FinancialDocument.Data.Context;

namespace FinancialDocument.Data.Repositories
{
    public class BusinessPartnerRepository : Repository<BusinessPartner>
    {
        public BusinessPartnerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
