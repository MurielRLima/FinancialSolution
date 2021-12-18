using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.DocumentDetail
{
    public class DocumentDetailDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
