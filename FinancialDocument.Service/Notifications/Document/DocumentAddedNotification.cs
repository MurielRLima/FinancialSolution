using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.Document
{
    public class DocumentAddedNotification : INotification
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
    }
}
