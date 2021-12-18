using FinancialDocument.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace FinancialDocument.Service.Commands
{
    public class DocumentAddCommand : IRequest<DocumentAddResponse>
    {
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

        public static Document MapTo(DocumentAddCommand document)
        {
            var newId = Guid.NewGuid();
            return new Document()
            {
                Id = newId,
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
                documentDetails = DocumentDetailAddCommand.MapTo(newId, document.documentDetails)
            };
        }
        public List<DocumentDetailAddCommand> documentDetails { get; set; } = new List<DocumentDetailAddCommand>();
    }

    public class DocumentDetailAddCommand : IRequest<string>
    {
        public Guid DocumentId { get; set; }
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public Double Value { get; set; }
        public string Observation { get; set; }
        public bool Active { get; set; }
        public static DocumentDetail MapTo(Guid docid, DocumentDetailAddCommand detail)
        {
            return new DocumentDetail()
            {
                Id = Guid.NewGuid(),
                DocumentId = docid,
                OperationType = detail.OperationType,
                Date = detail.Date,
                Value = detail.Value,
                Observation = detail.Observation,
                Active = detail.Active
            };
        }

        public static List<DocumentDetail> MapTo(Guid docid, List<DocumentDetailAddCommand> detailList)
        {
            var r = new List<DocumentDetail>();

            foreach (var detail in detailList)
            {
                r.Add(new DocumentDetail()
                {
                    Id = Guid.NewGuid(),
                    DocumentId = docid,
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

    public class DocumentAddResponse
    {
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

        public static DocumentAddResponse MapTo(Document document)
        {
            return new DocumentAddResponse()
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
                documentDetails = DocumentDetailAddResponse.MapTo(document.documentDetails)
            };
        }
        public List<DocumentDetailAddResponse> documentDetails { get; set; } = new List<DocumentDetailAddResponse>();
    }

    public class DocumentDetailAddResponse : IRequest<string>
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public Double Value { get; set; }
        public string Observation { get; set; }
        public bool Active { get; set; }
        public static DocumentDetailAddResponse MapTo( DocumentDetail detail)
        {
            return new DocumentDetailAddResponse()
            {
                Id = detail.Id,
                DocumentId = detail.DocumentId,
                OperationType = detail.OperationType,
                Date = detail.Date,
                Value = detail.Value,
                Observation = detail.Observation,
                Active = detail.Active
            };
        }

        public static List<DocumentDetailAddResponse> MapTo(List<DocumentDetail> detailList)
        {
            var r = new List<DocumentDetailAddResponse>();

            foreach (var detail in detailList)
            {
                r.Add(new DocumentDetailAddResponse()
                {
                    Id = detail.Id,
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
