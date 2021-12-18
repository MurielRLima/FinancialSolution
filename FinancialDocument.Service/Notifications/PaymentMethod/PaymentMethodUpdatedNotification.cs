using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.PaymentMethod
{
    public class PaymentMethodUpdatedNotification: INotification
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public int Installments { get; set; }
    }
}
