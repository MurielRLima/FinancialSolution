using FinancialDocument.Service.Commands;
using FinancialDocument.Service.Notifications;
using FinancialDocument.Service.Notifications.BusinessPartner;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using MediatR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Service.CommandHandlers
{
    public class BusinessPartnerDeleteCommandHandler : IRequestHandler<BusinessPartnerDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<BusinessPartner> _repository;

        public BusinessPartnerDeleteCommandHandler(IMediator mediator, IRepository<BusinessPartner> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(BusinessPartnerDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);
                await _mediator.Publish(new BusinessPartnerDeletedNotification { Id = request.Id });
                return await Task.FromResult(JsonSerializer.Serialize(request));
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new BusinessPartnerDeletedNotification { Id = request.Id });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Business partner delete command handler", Error = ex.Message, Message = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro ao remover o registro");
            }

        }
    }
}
