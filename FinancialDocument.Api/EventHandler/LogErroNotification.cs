using FinancialDocument.Api.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Api.EventHandler
{
    public class LogErroNotification :
                            INotificationHandler<ErroNotification>
    {
        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Error: '{notification.Error} \n {notification.Message}' \n Internal message: '{notification.InternalMessage}'");
            });
        }
    }
}
