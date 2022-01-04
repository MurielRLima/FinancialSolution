using FinancialDocument.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FinancialDocument.Domain.Entities
{
    public class BusinessPartner : IEntityBase
    {
        private string _telephone;
        private string _celphone;

        public Guid Id { get; set; }
        public string TradingName { get; set; }
        public string CorporateName { get; set; }
        public string Address { get; set; }
        public string Telephone
        {
            get => _telephone;
            set
            {
                _telephone = GetOnlyNumbers(value);
            }
        }
        public string Celphone
        {
            get => _celphone;
            set
            {
                _celphone = GetOnlyNumbers(value);
            }
        }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsCustomer { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();

        private string GetOnlyNumbers(string value)
        {
            string result = "";
            Regex reg = new Regex(@"\d");
            if (!String.IsNullOrEmpty(value))
            {
                var regular = reg.Matches(value.Replace(" ", ""));
                foreach (Match m in regular)
                    result += m.ToString();
            }
            return result;
        }

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
