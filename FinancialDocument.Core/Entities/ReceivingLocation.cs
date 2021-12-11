using System;
using System.Collections.Generic;

namespace FinancialDocument.Core.Entities
{
    public class ReceivingLocation
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();
    }
}
