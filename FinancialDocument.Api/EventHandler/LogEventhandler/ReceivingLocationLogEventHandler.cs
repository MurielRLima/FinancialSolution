using FinancialDocument.Api.Notifications.ReceivingLocation;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Api.EventHandler.LogEventhandler
{
    public class ReceivingLocationLogEventHandler :
                            INotificationHandler<ReceivingLocationAddedNotification>,
                            INotificationHandler<ReceivingLocationUpdatedNotification>,
                            INotificationHandler<ReceivingLocationDeletedNotification>
    {
        public Task Handle(ReceivingLocationAddedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ReceivingLocation Added: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(ReceivingLocationUpdatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ReceivingLocation Updated: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(ReceivingLocationDeletedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ReceivingLocation Deleted: '{JsonConvert.SerializeObject(notification)}'");
            });
        }
    }
}
