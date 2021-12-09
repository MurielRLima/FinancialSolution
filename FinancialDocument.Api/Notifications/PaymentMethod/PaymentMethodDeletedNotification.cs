using MediatR;
using System;

namespace FinancialDocument.Api.Notifications.PaymentMethod
{
    public class PaymentMethodDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
