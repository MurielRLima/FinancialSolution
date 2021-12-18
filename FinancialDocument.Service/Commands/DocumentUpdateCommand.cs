using FinancialDocument.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FinancialDocument.Service.Commands
{
    public class DocumentUpdateCommand : IRequest<string>
    {
        [DataMember]
        [Required]
        [MaxLength(36)]
        [MinLength(36)]
        //[SwaggerSchema(Title = "Id", Description = "Id único do documento")]
        //[JsonProperty("id", Required = Required.DisallowNull)] 
        public Guid Id { get; set; }
        public string DocumentNumber { get; set; }
        public Guid BusinessPartnerId { get; set; }
        public string DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public Double Amount { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid ReceivingLocationId { get; set; }
        public string Observation { get; set; }
        public bool Settled { get; set; }
        public bool Active { get; set; }

        public static Document MapTo(DocumentUpdateCommand document)
        {
            return new Document()
            {
                Id = document.Id,
                DocumentNumber = document.DocumentNumber,
                BusinessPartnerId = document.BusinessPartnerId,
                DocumentType = document.DocumentType,
                IssueDate = document.IssueDate,
                DueDate = document.DueDate,
                Amount = document.Amount,
                PaymentMethodId = document.PaymentMethodId,
                ReceivingLocationId = document.ReceivingLocationId,
                Observation = document.Observation,
                Active = document.Active,
                documentDetails = DocumentDetailUpdate.MapTo(document.documentDetails)
            };
        }
        public List<DocumentDetailUpdate> documentDetails { get; set; } = new List<DocumentDetailUpdate>();
    }

    public class DocumentDetailUpdate
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public Double Value { get; set; }
        public string Observation { get; set; }
        public bool Active { get; set; }
        public static DocumentDetail MapTo(DocumentDetailUpdate detail)
        {
            return new DocumentDetail()
            {
                Id = (detail.Id == Guid.Empty ? Guid.NewGuid() : detail.Id),
                DocumentId = detail.DocumentId,
                OperationType = detail.OperationType,
                Date = detail.Date,
                Value = detail.Value,
                Observation = detail.Observation,
                Active = detail.Active
            };
        }

        public static List<DocumentDetail> MapTo(List<DocumentDetailUpdate> detailList)
        {
            var r = new List<DocumentDetail>();

            foreach (var detail in detailList)
            {
                r.Add(new DocumentDetail()
                {
                    Id = (detail.Id == Guid.Empty ? Guid.NewGuid() : detail.Id),
                    DocumentId = detail.DocumentId,
                    OperationType = detail.OperationType,
                    Date = detail.Date,
                    Value = detail.Value,
                    Observation = detail.Observation,
                    Active = detail.Active
                });
            }
            return r;
        }
    }
}
