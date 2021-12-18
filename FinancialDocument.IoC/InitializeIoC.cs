using FinancialDocument.Data.Repositories;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Domain.Interfaces.Services;
using FinancialDocument.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialDocument.IoC
{
    public static class InitializeIoC
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //Repositories
            services.AddTransient<IRepository<PaymentMethod>, PaymentMethodRepository>();
            services.AddTransient<IRepository<ReceivingLocation>, ReceivingLocationRepository>();
            services.AddTransient<IRepository<BusinessPartner>, BusinessPartnerRepository>();
            services.AddTransient<IRepository<Document>, DocumentRepository>();
            services.AddTransient<IRepository<DocumentDetail>, DocumentDetailRepository>();

            //Services
            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<IReceivingLocationService, ReceivingLocationService>();
            services.AddTransient<IBusinessPartnerService, BusinessPartnerService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IDocumentDetailService, DocumentDetailService>();
        }
    }
}
