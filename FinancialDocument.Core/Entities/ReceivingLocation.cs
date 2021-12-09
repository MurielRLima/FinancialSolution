using System;

namespace FinancialDocument.Core.Entities
{
    public class ReceivingLocation
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
    }
}
