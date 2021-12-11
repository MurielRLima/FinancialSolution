using FinancialDocument.Api.Commands;
using FinancialDocument.Api.Notifications;
using FinancialDocument.Api.Notifications.BusinessPartner;
using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using MediatR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Api.CommandHandlers
{
    public class BusinessPartnerAddCommandHandler : IRequestHandler<BusinessPartnerAddCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<BusinessPartner> _repository;

        public BusinessPartnerAddCommandHandler(IMediator mediator, IRepository<BusinessPartner> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(BusinessPartnerAddCommand request, CancellationToken cancellationToken)
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
                return await Task.FromResult(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new BusinessPartnerAddedNotification { Id = data.Id, TradingName = data.TradingName, CorporateName = data.CorporateName, Address = data.Address, Telephone = data.Telephone, Celphone = data.Celphone, Observation = data.Observation, Active = data.Active, IsSupplier = data.IsSupplier, IsCustomer = data.IsCustomer });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Business Partner add command handler", Error = ex.Message, Message = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro ao criar o registro");
            }

        }
    }
}
