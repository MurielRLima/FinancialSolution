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
    public class ReceivingLocationAddCommandHandler : IRequestHandler<ReceivingLocationAddCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<ReceivingLocation> _repository;

        public ReceivingLocationAddCommandHandler(IMediator mediator, IRepository<ReceivingLocation> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(ReceivingLocationAddCommand request, CancellationToken cancellationToken)
        {
            ReceivingLocation data = ReceivingLocationAddCommand.MapTo(request);

            try
            {
                await _repository.Add(data);
                await _mediator.Publish(new ReceivingLocationAddedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = data.Active });
                return await Task.FromResult(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new ReceivingLocationAddedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = false });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Receiving location add command handler", Error = ex.Message, Message = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro ao criar o registro");
            }

        }
    }
}
