using FinancialDocument.Domain.Entities;
using FinancialDocument.Data.Context;

namespace FinancialDocument.Data.Repositories
{
    public class DocumentDetailRepository : Repository<DocumentDetail>
    {
        public DocumentDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
