using MediatR;
using System;

namespace FinancialDocument.Service.Notifications.BusinessPartner
{
    public class BusinessPartnerUpdatedNotification : INotification
    {
        public Guid Id { get; set; }
        public string TradingName { get; set; }
        public string CorporateName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Celphone { get; set; }
        public string Observation { get; set; }
        public bool? Active { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsCustomer { get; set; }
    }
}
