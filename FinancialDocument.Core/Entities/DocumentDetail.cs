using System;

namespace FinancialDocument.Domain.Entities
{
    public class DocumentDetail
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public string OperationType { get; set; } // D = debit or C = credit
        public DateTime Date { get; set; }
        public Double Value { get; set; }
        public string Observation { get; set; }
        public bool Active { get; set; }

        public Document document { get; set; }

        public bool ValidateDate(DateTime DocumentIssueDate)
        {
            return (Date >= DocumentIssueDate);
        }
    }
}
