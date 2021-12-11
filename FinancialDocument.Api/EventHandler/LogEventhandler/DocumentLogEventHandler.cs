using FinancialDocument.Api.Notifications.Document;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Api.EventHandler.LogEventhandler
{
    public class DocumentLogEventHandler :
                            INotificationHandler<DocumentAddedNotification>,
                            INotificationHandler<DocumentUpdatedNotification>,
                            INotificationHandler<DocumentDeletedNotification>
    {
        public Task Handle(DocumentAddedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Document Added: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(DocumentUpdatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Document Updated: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(DocumentDeletedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Document Deleted: '{JsonConvert.SerializeObject(notification)}'");
            });
        }
    }
}
