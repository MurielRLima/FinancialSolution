﻿using FinancialDocument.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FinancialDocument.Service.Commands
{
    [DataContract]
    public class BusinessPartnerUpdateCommand : IRequest<BusinessPartnerUpdateResponse>
    {
        /// <example>15241167-8bf8-41ea-a99f-0cd03acd0e65</example>
        [JsonProperty("id")]
        [SwaggerSchema(Title = "Unique id", Description = "Unique id")]
        [StringLength(36, MinimumLength = 36, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        [JsonRequired]
        public Guid Id { get; set; }

        /// <example>Bp name of company.</example>
        [JsonProperty("tranding_name")]
        [SwaggerSchema(Title = "Trading name", Description = "Trading name of company")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        [JsonRequired]
        public string TradingName { get; set; }

        /// <example>Bp corporate name.</example>
        [JsonProperty("corporate_name")]
        [SwaggerSchema(Title = "Corporate name", Description = "Corporate name")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        [JsonRequired]
        public string CorporateName { get; set; }

        /// <example>street name, number and another details of address</example>
        [JsonProperty("address")]
        [SwaggerSchema(Title = "Address", Description = "Address details")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        [JsonRequired]
        public string Address { get; set; }

        /// <example>+55 11 47722855</example>
        [JsonProperty("telephone")]
        [SwaggerSchema(Title = "Telephone", Description = "Telephone")]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        public string Telephone { get; set; }

        /// <example>+55 11 998722855</example>
        [JsonProperty("celphone")]
        [SwaggerSchema(Title = "Celphone", Description = "Celphone")]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        public string Celphone { get; set; }

        /// <example>Some observation text</example>
        [JsonProperty("observation")]
        [SwaggerSchema(Title = "Observation", Description = "Observation of bp")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        public string Observation { get; set; }

        /// <example>true</example>
        [JsonProperty("active")]
        [SwaggerSchema(Title = "Active", Description = "The bp is active?")]
        [DataMember]
        public bool? Active { get; set; }

        /// <example>true</example>
        [JsonProperty("is_supplier")]
        [SwaggerSchema(Title = "Is Supplier", Description = "The bp is a supplier?")]
        [DataMember]
        public bool IsSupplier { get; set; }

        /// <example>true</example>
        [JsonProperty("is_customer")]
        [SwaggerSchema(Title = "Is customer", Description = "The bp is a customer?")]
        [DataMember]
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

    public class BusinessPartnerUpdateResponse 
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

        public static BusinessPartnerUpdateResponse MapTo(BusinessPartner model)
        {
            return new BusinessPartnerUpdateResponse()
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
