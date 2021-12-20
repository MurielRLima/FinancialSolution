using System;
using MediatR;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using FinancialDocument.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace FinancialDocument.Service.Commands
{
    public class ReceivingLocationAddCommand : IRequest<ReceivingLocationAddResponse>
    {
        /// <example>Union bank</example>
        [JsonProperty("description")]
        [SwaggerSchema(Title = "Description", Description = "Description of receiving location")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        [JsonRequired]
        public string Description { get; set; }

        /// <example>Some observation text</example>
        [JsonProperty("observation")]
        [SwaggerSchema(Title = "Observation", Description = "Observation of register")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        public string Observation { get; set; }
       
        /// <example>true</example>
        [JsonProperty("active")]
        [SwaggerSchema(Title = "Active", Description = "The register is active?")]
        [DataMember]
        public bool? Active { get; set; }

        public static ReceivingLocation MapTo(ReceivingLocationAddCommand model)
        {
            return new ReceivingLocation()
            {
                Id = Guid.NewGuid(),
                Description = model.Description,
                Observation = model.Observation,
                Active = model.Active
            };
        }
    }

    public class ReceivingLocationAddResponse
    {
        /// <example>15241167-8bf8-41ea-a99f-0cd03acd0e65</example>
        [JsonProperty("id")]
        [SwaggerSchema(Title = "Unique id", Description = "Unique id")]
        [StringLength(36, MinimumLength = 36, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        [JsonRequired]
        public Guid Id { get; set; }
        /// <example>Union bank</example>
        [JsonProperty("description")]
        [SwaggerSchema(Title = "Description", Description = "Description of receiving location")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        [JsonRequired]
        public string Description { get; set; }

        /// <example>Some observation text</example>
        [JsonProperty("observation")]
        [SwaggerSchema(Title = "Observation", Description = "Observation of register")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "{0} The field must be between {2} and {1} characters.")]
        [DataMember]
        public string Observation { get; set; }

        /// <example>true</example>
        [JsonProperty("active")]
        [SwaggerSchema(Title = "Active", Description = "The register is active?")]
        [DataMember]
        public bool? Active { get; set; }

        public static ReceivingLocationAddResponse MapTo(ReceivingLocation model)
        {
            return new ReceivingLocationAddResponse()
            {
                Id = model.Id,
                Description = model.Description,
                Observation = model.Observation,
                Active = model.Active
            };
        }
    }
}
