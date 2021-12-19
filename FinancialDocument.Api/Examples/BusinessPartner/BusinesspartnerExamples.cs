using FinancialDocument.Service.Commands;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;

namespace FinancialDocument.Api.Examples.BusinessPartner
{
    public class BusinessPartnerUpdateCommandExample : IMultipleExamplesProvider<BusinessPartnerUpdateCommand>
    {
        public IEnumerable<SwaggerExample<BusinessPartnerUpdateCommand>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "Business partner - Customer and supplier",
                new BusinessPartnerUpdateCommand()
                {
                    Id = Guid.NewGuid(),
                    TradingName = "Business partner name of company.",
                    CorporateName = "Business partner corporate name.",
                    Address = "street name, number and another details of address",
                    Telephone = "+55 11 47722855",
                    Celphone = "+55 11 998722855",
                    Observation = "Some observation text",
                    Active = true,
                    IsCustomer = true,
                    IsSupplier = true
                }
            );

            yield return SwaggerExample.Create(
                "Business partner - customer",
                new BusinessPartnerUpdateCommand()
                {
                    Id = Guid.NewGuid(),
                    TradingName = "Customer name of company.",
                    CorporateName = "Customer corporate name.",
                    Address = "street name, number and another details of address",
                    Telephone = "+55 11 47722855",
                    Celphone = "+55 11 998722855",
                    Observation = "Some observation text",
                    Active = true,
                    IsCustomer = true,
                    IsSupplier = false
                }
            );

            yield return SwaggerExample.Create(
                "Business partner - Supllier",
                new BusinessPartnerUpdateCommand()
                {
                    Id = Guid.NewGuid(),
                    TradingName = "Supplier name of company.",
                    CorporateName = "Supplier corporate name.",
                    Address = "street name, number and another details of address",
                    Telephone = "+55 11 47722855",
                    Celphone = "+55 11 998722855",
                    Observation = "Some observation text",
                    Active = true,
                    IsCustomer = false,
                    IsSupplier = true
                }
            );
        }
    }


    public class BusinessPartnerAddCommandExample : IMultipleExamplesProvider<BusinessPartnerAddCommand>
    {
        public IEnumerable<SwaggerExample<BusinessPartnerAddCommand>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "Business partner - Customer and supplier",
                new BusinessPartnerAddCommand()
                {
                    TradingName = "Business partner name of company.",
                    CorporateName = "Business partner corporate name.",
                    Address = "street name, number and another details of address",
                    Telephone = "+55 11 47722855",
                    Celphone = "+55 11 998722855",
                    Observation = "Some observation text",
                    Active = true,
                    IsCustomer = true,
                    IsSupplier = true
                }
            );

            yield return SwaggerExample.Create(
                "Business partner - customer",
                new BusinessPartnerAddCommand()
                {
                    TradingName = "Customer name of company.",
                    CorporateName = "Customer corporate name.",
                    Address = "street name, number and another details of address",
                    Telephone = "+55 11 47722855",
                    Celphone = "+55 11 998722855",
                    Observation = "Some observation text",
                    Active = true,
                    IsCustomer = true,
                    IsSupplier = false
                }
            );

            yield return SwaggerExample.Create(
                "Business partner - Supllier",
                new BusinessPartnerAddCommand()
                {
                    TradingName = "Supplier name of company.",
                    CorporateName = "Supplier corporate name.",
                    Address = "street name, number and another details of address",
                    Telephone = "+55 11 47722855",
                    Celphone = "+55 11 998722855",
                    Observation = "Some observation text",
                    Active = true,
                    IsCustomer = false,
                    IsSupplier = true
                }
            );
        }
    }

    public class BusinessPartnerResponseExample : IExamplesProvider<BusinessPartnerAddResponse>
    {
        public BusinessPartnerAddResponse GetExamples()
        {
            return new BusinessPartnerAddResponse()
            {
                Id = Guid.NewGuid(),
                TradingName = "Business partner name of company.",
                CorporateName = "Business partner corporate name.",
                Address = "street name, number and another details of address",
                Telephone = "+55 11 47722855",
                Celphone = "+55 11 998722855",
                Observation = "Some observation text",
                Active = true,
                IsCustomer = true,
                IsSupplier = true
            };
        }
    }
}
