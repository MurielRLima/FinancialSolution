using FinancialDocument.Domain.Entities;
using FinancialDocument.Data.Context;

namespace FinancialDocument.Data.Repositories
{
    public class DocumentRepository : Repository<Document>
    {
        public DocumentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
