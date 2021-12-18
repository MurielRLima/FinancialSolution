using FinancialDocument.Domain.Entities;
using MediatR;
using System;

namespace FinancialDocument.Service.Commands
{
    public class BusinessPartnerUpdateCommand : IRequest<string>
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

        public static BusinessPartner MapTo(BusinessPartnerUpdateCommand model)
        {
            return new BusinessPartner()
            {
                Id = model.Id,
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
