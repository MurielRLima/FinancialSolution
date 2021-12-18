using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.DocumentDetail
{
    public class DocumentDetailUpdatedNotification : INotification
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public Double Value { get; set; }
        public string Observation { get; set; }
        public bool Active { get; set; }
    }
}
