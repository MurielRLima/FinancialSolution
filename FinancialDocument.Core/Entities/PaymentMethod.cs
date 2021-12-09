using System;

namespace FinancialDocument.Core.Entities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public int Installments { get; set; }

    }
}
