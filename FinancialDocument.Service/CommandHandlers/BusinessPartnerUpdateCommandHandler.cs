using FinancialDocument.Service.Commands;
using FinancialDocument.Service.Notifications;
using FinancialDocument.Service.Notifications.BusinessPartner;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialDocument.Domain.Exceptions;

namespace FinancialDocument.Service.CommandHandlers
{
    public class BusinessPartnerUpdateCommandHandler : IRequestHandler<BusinessPartnerUpdateCommand, BusinessPartnerUpdateResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<BusinessPartner> _repository;

        public BusinessPartnerUpdateCommandHandler(IMediator mediator, IRepository<BusinessPartner> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<BusinessPartnerUpdateResponse> Handle(BusinessPartnerUpdateCommand request, CancellationToken cancellationToken)
        {
            BusinessPartner data = BusinessPartnerUpdateCommand.MapTo(request);

            try
            {
                await _repository.Edit(data);
                await _mediator.Publish(
                    new BusinessPartnerUpdatedNotification {
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
                return BusinessPartnerUpdateResponse.MapTo(data);
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new BusinessPartnerUpdatedNotification { Id = data.Id, TradingName = data.TradingName, CorporateName = data.CorporateName, Address = data.Address, Telephone = data.Telephone, Celphone = data.Celphone, Observation = data.Observation, Active = data.Active, IsSupplier = data.IsSupplier, IsCustomer = data.IsCustomer });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Business partner update command handler", Error = ex.Message, Message = ex.StackTrace });
                throw new FinancialInternalException("Ocorreu um erro ao atualizar o registro", ex);
            }

        }
    }
}
