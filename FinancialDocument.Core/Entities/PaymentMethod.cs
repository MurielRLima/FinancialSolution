using System;
using System.Collections.Generic;

namespace FinancialDocument.Domain.Entities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public int Installments { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();
    }
}
