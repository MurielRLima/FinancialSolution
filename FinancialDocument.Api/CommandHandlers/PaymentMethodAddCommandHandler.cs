using FinancialDocument.Api.Commands;
using FinancialDocument.Api.Notifications;
using FinancialDocument.Api.Notifications.PaymentMethod;
using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace FinancialDocument.Api.CommandHandlers
{
    public class PaymentMethodAddCommandHandler: IRequestHandler<PaymentMethodAddCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<PaymentMethod> _repository;

        public PaymentMethodAddCommandHandler(IMediator mediator, IRepository<PaymentMethod> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(PaymentMethodAddCommand request, CancellationToken cancellationToken)
        {
            PaymentMethod data = PaymentMethodAddCommand.MapTo(request);

            try
            {
                await _repository.Add(data);
                await _mediator.Publish(new PaymentMethodAddedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = data.Active, Installments = data.Installments });
                return await Task.FromResult(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new PaymentMethodAddedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = false, Installments = data.Installments });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Payment method add command handler", Error = ex.Message, Message = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro ao criar o registro");
            }

        }
    }
}
