using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.ReceivingLocation
{
    public class ReceivingLocationDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
