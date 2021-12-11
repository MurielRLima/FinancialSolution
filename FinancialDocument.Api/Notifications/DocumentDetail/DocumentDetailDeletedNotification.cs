using MediatR;
using System;

namespace FinancialDocument.Api.Notifications.DocumentDetail
{
    public class DocumentDetailDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
