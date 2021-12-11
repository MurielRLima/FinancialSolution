using MediatR;
using System;

namespace FinancialDocument.Api.Notifications.Document
{
    public class DocumentDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
