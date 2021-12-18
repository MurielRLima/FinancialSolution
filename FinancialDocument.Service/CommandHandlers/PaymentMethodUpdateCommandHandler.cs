using FinancialDocument.Service.Commands;
using FinancialDocument.Service.Notifications;
using FinancialDocument.Service.Notifications.PaymentMethod;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using MediatR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Service.CommandHandlers
{
    public class PaymentMethodUpdateCommandHandler : IRequestHandler<PaymentMethodUpdateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<PaymentMethod> _repository;

        public PaymentMethodUpdateCommandHandler(IMediator mediator, IRepository<PaymentMethod> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(PaymentMethodUpdateCommand request, CancellationToken cancellationToken)
        {
            PaymentMethod data = PaymentMethodUpdateCommand.MapTo(request);

            try
            {
                await _repository.Edit(data);
                await _mediator.Publish(new PaymentMethodUpdatedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = data.Active, Installments = data.Installments });
                return await Task.FromResult(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new PaymentMethodUpdatedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = false, Installments = data.Installments });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Payment method update command handler", Error = ex.Message, Message = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro ao atualizar o registro");
            }

        }
    }
}
