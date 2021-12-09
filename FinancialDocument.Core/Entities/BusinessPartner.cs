using System;

namespace FinancialDocument.Core.Entities
{
    public class BusinessPartner
    {
        public Guid Id { get; set; }
        public string TradingName { get; set; }
        public string CorporateName { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public bool? IsSupplier { get; set; }
        public bool? IsCustomer { get; set; }

    }
}
