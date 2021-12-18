using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.ReceivingLocation
{
    public class ReceivingLocationUpdatedNotification : INotification
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
    }
}
