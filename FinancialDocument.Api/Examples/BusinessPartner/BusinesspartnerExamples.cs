using FinancialDocument.Service.Commands;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialDocument.Api.Examples.BusinessPartner
{
    public class BusinessPartnerUpdateCommandExample : IExamplesProvider<BusinessPartnerUpdateCommand>
    {
        public BusinessPartnerUpdateCommand GetExamples()
        {
            return new BusinessPartnerUpdateCommand() { 
                Id = Guid.NewGuid(),
                TradingName = "Bp name of company.",
                CorporateName = "Bp corporate name.",
                Address = "street name, number and another details of address",
                Telephone = "+55 11 47722855<",
                Celphone = "+55 11 998722855",
                Observation = "Some observation text",
                Active = true,
                IsCustomer = true,
                IsSupplier = false
            };
        }
    }
}
