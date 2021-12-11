using FinancialDocument.Api.Notifications.DocumentDetail;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Api.EventHandler.LogEventhandler
{
    public class DocumentDetailLogEventHandler :
                            INotificationHandler<DocumentDetailAddedNotification>,
                            INotificationHandler<DocumentDetailUpdatedNotification>,
                            INotificationHandler<DocumentDetailDeletedNotification>
    {
        public Task Handle(DocumentDetailAddedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Document Added: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(DocumentDetailUpdatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Document Updated: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(DocumentDetailDeletedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Document Deleted: '{JsonConvert.SerializeObject(notification)}'");
            });
        }
    }
}
