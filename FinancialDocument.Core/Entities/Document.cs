using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancialDocument.Domain.Entities
{
    public class Document
    {
        public Document()
        {
            IssueDate = DateTime.Now;
            DueDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string DocumentNumber { get; set; }
        public Guid BusinessPartnerId { get; set; }
        public string DocumentType { get; set; } // P = payable / R = receivable
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public Double Amount { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid ReceivingLocationId { get; set; }
        public string Observation { get; set; }
        public bool Settled { get; set; }        
        public bool Active { get; set; }

        public virtual BusinessPartner businessPartner { get; set; }
        public virtual PaymentMethod paymentMethod { get; set; }
        public virtual ReceivingLocation receivinglocation { get; set; }

        public List<DocumentDetail> documentDetails { get; set; } = new List<DocumentDetail>();

        public bool ValidateIssueAndDueDate()
        {
            return (DueDate >= IssueDate);
        }

        public bool ValidateAmount()
        {
            return (Amount > 0);
        }

        public bool IsAmountSettled()
        {
            var dTotal = documentDetails.Where(t => t.OperationType == "D").Sum(x => x.Value);
            var cTotal = documentDetails.Where(t => t.OperationType == "C").Sum(x => x.Value);
            return ((cTotal- dTotal) >= Amount);
        }

        public Double GetDetailTotal()
        {
            var dTotal = documentDetails.Where(t => t.OperationType == "D").Sum(x => x.Value);
            var cTotal = documentDetails.Where(t => t.OperationType == "C").Sum(x => x.Value);
            return (cTotal - dTotal);
        }

    }
}
