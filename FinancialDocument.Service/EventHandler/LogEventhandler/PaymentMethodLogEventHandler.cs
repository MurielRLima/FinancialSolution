using FinancialDocument.Service.Notifications.PaymentMethod;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Service.EventHandler.LogEventHandler
{
    public class PaymentMethodLogEventHandler :
                            INotificationHandler<PaymentMethodAddedNotification>,
                            INotificationHandler<PaymentMethodUpdatedNotification>,
                            INotificationHandler<PaymentMethodDeletedNotification>
    {
        public Task Handle(PaymentMethodAddedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"PaymentMethod Added: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(PaymentMethodUpdatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"PaymentMethod Updated: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(PaymentMethodDeletedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"PaymentMethod Deleted: '{JsonConvert.SerializeObject(notification)}'");
            });
        }
    }
}
