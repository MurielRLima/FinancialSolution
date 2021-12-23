using FinancialDocument.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace FinancialDocument.Domain.Entities
{
    public class ReceivingLocation : IEntityBase
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Description))
                throw new Exception("Preencha o campo 'Description'.");

            return true;
        }
    }
}
