using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using FinancialDocument.Service.Commands;
using FinancialDocument.Service.Notifications;
using FinancialDocument.Service.Notifications.BusinessPartner;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Service.CommandHandlers
{
    public class BusinessPartnerAddCommandHandler : IRequestHandler<BusinessPartnerAddCommand, BusinessPartnerAddResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<BusinessPartner> _repository;

        public BusinessPartnerAddCommandHandler(IMediator mediator, IRepository<BusinessPartner> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<BusinessPartnerAddResponse> Handle(BusinessPartnerAddCommand request, CancellationToken cancellationToken)
        {
            BusinessPartner data = BusinessPartnerAddCommand.MapTo(request);

            try
            {
                await _repository.Add(data);
                await _mediator.Publish(
                    new BusinessPartnerAddedNotification { 
                        Id = data.Id, 
                        TradingName = data.TradingName, 
                        CorporateName = data.CorporateName, 
                        Address = data.Address, 
                        Telephone = data.Telephone, 
                        Celphone = data.Celphone, 
                        Observation = data.Observation, 
                        Active = data.Active, 
                        IsSupplier = data.IsSupplier, 
                        IsCustomer = data.IsCustomer
                    }
                );
                return BusinessPartnerAddResponse.MapTo(data);
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new BusinessPartnerAddedNotification { Id = data.Id, TradingName = data.TradingName, CorporateName = data.CorporateName, Address = data.Address, Telephone = data.Telephone, Celphone = data.Celphone, Observation = data.Observation, Active = data.Active, IsSupplier = data.IsSupplier, IsCustomer = data.IsCustomer });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Business Partner add command handler", Error = ex.Message, Message = ex.StackTrace });
                throw new Exception("Ocorreu um erro ao criar o registro");
            }

        }
    }
}
