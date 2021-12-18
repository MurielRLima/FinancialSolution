using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.BusinessPartner
{
    public class BusinessPartnerDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
