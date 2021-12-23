using FinancialDocument.Domain.Interfaces;
using System;

namespace FinancialDocument.Domain.Entities
{
    public class DocumentDetail : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public string OperationType { get; set; } // D = debit or C = credit
        public DateTime Date { get; set; }
        public Double Value { get; set; }
        public string Observation { get; set; }
        public bool Active { get; set; }

        public Document document { get; set; }

        public bool IsValid()
        {
            if (OperationType != "D" && OperationType != "C")
                throw new Exception("Tipo de operação inválida.");

            return true;
        }

        public bool IsValidDate(DateTime DocumentIssueDate)
        {
            return (Date >= DocumentIssueDate);
        }
    }
}
