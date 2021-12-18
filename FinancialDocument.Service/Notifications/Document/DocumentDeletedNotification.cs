using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.Document
{
    public class DocumentDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
