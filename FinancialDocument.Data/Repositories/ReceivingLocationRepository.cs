using FinancialDocument.Core.Entities;
using FinancialDocument.Data.Context;

namespace FinancialDocument.Data.Repositories
{
    public class ReceivingLocationRepository : Repository<ReceivingLocation>
    {
        public ReceivingLocationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
