using FinancialDocument.Api.Notifications.BusinessPartner;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Api.EventHandler.LogEventhandler
{
    public class BusinessPartnerLogEventHandler :
                            INotificationHandler<BusinessPartnerAddedNotification>,
                            INotificationHandler<BusinessPartnerUpdatedNotification>,
                            INotificationHandler<BusinessPartnerDeletedNotification>
    {
        public Task Handle(BusinessPartnerAddedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"BusinessPartner Added: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(BusinessPartnerUpdatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"BusinessPartner Updated: '{JsonConvert.SerializeObject(notification)}'");
            });
        }

        public Task Handle(BusinessPartnerDeletedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"BusinessPartner Deleted: '{JsonConvert.SerializeObject(notification)}'");
            });
        }
    }
}
