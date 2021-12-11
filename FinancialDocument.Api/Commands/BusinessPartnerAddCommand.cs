using FinancialDocument.Core.Entities;
using MediatR;
using System;

namespace FinancialDocument.Api.Commands
{
    public class BusinessPartnerAddCommand : IRequest<string>
    {
        public string TradingName { get; set; }
        public string CorporateName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Celphone { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsCustomer { get; set; }

        public static BusinessPartner MapTo(BusinessPartnerAddCommand model)
        {
            return new BusinessPartner()
            {
                Id = Guid.NewGuid(),
                TradingName = model.TradingName,
                CorporateName = model.CorporateName,
                Address = model.Address,
                Telephone = model.Telephone,
                Celphone = model.Celphone,
                Observation = model.Observation,
                Active = model.Active,
                IsSupplier = model.IsSupplier,
                IsCustomer = model.IsCustomer
            };
        }
    }
}
