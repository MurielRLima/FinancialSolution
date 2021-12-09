using MediatR;
using System;

namespace FinancialDocument.Api.Notifications.ReceivingLocation
{
    public class ReceivingLocationAddedNotification : INotification
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
    }
}
