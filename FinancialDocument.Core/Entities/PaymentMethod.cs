using FinancialDocument.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancialDocument.Domain.Entities
{
    public class PaymentMethod : IEntityBase
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public int Installments { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Description))
                throw new Exception("Preencha o campo 'Description'.");

            if (Installments <= 0)
                throw new Exception("O campo 'Installments' deve ser maior que 0.");

            return true;
        }

        public List<Double> GetInstallmentsValue(int installmentNumer, Double totalDocumentValue)
        {
            var result = new List<Double>();

            if (installmentNumer == 1)
                return new List<Double>() { totalDocumentValue };

            Double mValue = (totalDocumentValue / installmentNumer);
            mValue = Math.Round(mValue, 2);

            for (int i = 1; i <= installmentNumer; i++)
                result.Add(mValue);

            Double Sum = Math.Round(result.Sum(), 2, MidpointRounding.AwayFromZero);

            if (Sum != totalDocumentValue)
            {
                var diff = Math.Round((totalDocumentValue - Sum), 2, MidpointRounding.AwayFromZero);
                var last = Math.Round(result.Last() + diff, 2, MidpointRounding.AwayFromZero);
                result[result.Count - 1] = last;
            }

            return result;
        }
    }
}
