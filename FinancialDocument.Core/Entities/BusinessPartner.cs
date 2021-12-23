using FinancialDocument.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace FinancialDocument.Domain.Entities
{
    public class BusinessPartner : IEntityBase
    {
        public Guid Id { get; set; }
        public string TradingName { get; set; }
        public string CorporateName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Celphone { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsCustomer { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(TradingName))
                throw new Exception("Preencha o campo 'TradingName'.");

            if (String.IsNullOrEmpty(CorporateName))
                throw new Exception("Preencha o campo 'CorporateName'.");

            if (String.IsNullOrEmpty(Address))
                throw new Exception("Preencha o campo 'Address'.");

            if (!IsSupplier && !IsCustomer)
                throw new Exception("Deve ser selecionada pelo menos um dos tipos: 'IsSupplier' ou 'IsCustomer'.");

            return true;
        }
    }
}
