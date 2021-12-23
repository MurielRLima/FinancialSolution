using FinancialDocument.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancialDocument.Domain.Entities
{
    public class Document: IEntityBase
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

        public bool IsValid()
        {
            if (!ValidateIssueAndDueDate())
                throw new Exception("A data de vencimento deve ser maior que a emissão.");

            if (!ValidateAmount())
                throw new Exception("A o valor do documento deve ser maior que zero.");

            if ((!IsAmountSettled()) && (!Settled))
                throw new Exception("A soma do total das baixas é maior que o total do documento, marque a opção 'quitado'.");

            if (DocumentType != "D" && DocumentType != "C")
                throw new Exception("Tipo de operação inválido.");

            if (documentDetails.Where(t => t.OperationType != "D" && t.OperationType != "C").Any())
                throw new Exception("Tipo de operação inválido no detalhe do documento.");

            return true;
        }

        private bool ValidateIssueAndDueDate()
        {
            return (DueDate >= IssueDate);
        }

        private bool ValidateAmount()
        {
            return (Amount > 0);
        }

        private bool IsAmountSettled()
        {
            return (GetDetailTotal() >= Amount);
        }

        private Double GetDetailTotal()
        {
            var dTotal = documentDetails.Where(t => t.OperationType == "D").Sum(x => x.Value);
            var cTotal = documentDetails.Where(t => t.OperationType == "C").Sum(x => x.Value);
            return (cTotal - dTotal);
        }

    }
}
