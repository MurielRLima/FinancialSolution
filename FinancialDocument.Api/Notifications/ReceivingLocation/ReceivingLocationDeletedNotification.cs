using MediatR;
using System;

namespace FinancialDocument.Api.Notifications.ReceivingLocation
{
    public class ReceivingLocationDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
