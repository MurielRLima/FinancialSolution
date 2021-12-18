using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.PaymentMethod
{
    public class PaymentMethodDeletedNotification : INotification
    {
        public Guid Id { get; set; }
    }
}
