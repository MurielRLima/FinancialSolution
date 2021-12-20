using FinancialDocument.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FinancialDocument.Service.Commands
{
    public class ReceivingLocationUpdateCommand : IRequest<ReceivingLocationUpdateResponse>
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
        public bool Active { get; set; }

        public static ReceivingLocation MapTo(ReceivingLocationUpdateCommand model)
        {
            return new ReceivingLocation()
            {
                Id = model.Id,
                Description = model.Description,
                Observation = model.Observation,
                Active = model.Active
            };
        }
    }

    public class ReceivingLocationUpdateResponse
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

        public static ReceivingLocationUpdateResponse MapTo(ReceivingLocation model)
        {
            return new ReceivingLocationUpdateResponse()
            {
                Id = model.Id,
                Description = model.Description,
                Observation = model.Observation,
                Active = model.Active
            };
        }
    }
}
