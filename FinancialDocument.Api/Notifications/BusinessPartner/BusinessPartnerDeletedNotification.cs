using MediatR;
using System;

namespace FinancialDocument.Api.Notifications.BusinessPartner
{
    public class BusinessPartnerDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
