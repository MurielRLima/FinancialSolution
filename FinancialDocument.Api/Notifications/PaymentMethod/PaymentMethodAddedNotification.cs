using MediatR;
using System;

namespace FinancialDocument.Api.Notifications.PaymentMethod
{
    public class PaymentMethodAddedNotification: INotification
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public int Installments { get; set; }
    }
}
