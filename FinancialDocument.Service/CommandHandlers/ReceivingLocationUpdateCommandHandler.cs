using FinancialDocument.Service.Commands;
using FinancialDocument.Service.Notifications;
using FinancialDocument.Service.Notifications.ReceivingLocation;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using MediatR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Service.CommandHandlers
{
    public class ReceivingLocationUpdateCommandHandler : IRequestHandler<ReceivingLocationUpdateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<ReceivingLocation> _repository;

        public ReceivingLocationUpdateCommandHandler(IMediator mediator, IRepository<ReceivingLocation> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(ReceivingLocationUpdateCommand request, CancellationToken cancellationToken)
        {
            ReceivingLocation data = ReceivingLocationUpdateCommand.MapTo(request);

            try
            {
                await _repository.Edit(data);
                await _mediator.Publish(new ReceivingLocationUpdatedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = data.Active });
                return await Task.FromResult(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new ReceivingLocationUpdatedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = false });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Receiving location update command handler", Error = ex.Message, Message = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro ao atualizar o registro");
            }

        }
    }
}
