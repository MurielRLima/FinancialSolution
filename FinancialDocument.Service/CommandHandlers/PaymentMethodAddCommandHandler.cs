using FinancialDocument.Service.Commands;
using FinancialDocument.Service.Notifications;
using FinancialDocument.Service.Notifications.PaymentMethod;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialDocument.Domain.Exceptions;

namespace FinancialDocument.Service.CommandHandlers
{
    public class PaymentMethodAddCommandHandler: IRequestHandler<PaymentMethodAddCommand, PaymentMethodAddResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<PaymentMethod> _repository;

        public PaymentMethodAddCommandHandler(IMediator mediator, IRepository<PaymentMethod> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<PaymentMethodAddResponse> Handle(PaymentMethodAddCommand request, CancellationToken cancellationToken)
        {
            PaymentMethod data = PaymentMethodAddCommand.MapTo(request);

            try
            {
                await _repository.Add(data);
                await _mediator.Publish(new PaymentMethodAddedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = data.Active, Installments = data.Installments });
                return PaymentMethodAddResponse.MapTo(data);
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new PaymentMethodAddedNotification { Id = data.Id, Description = data.Description, Observation = data.Observation, Active = false, Installments = data.Installments });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Payment method add command handler", Error = ex.Message, Message = ex.StackTrace });
                throw new FinancialInternalException("Ocorreu um erro ao criar o registro", ex);
            }

        }
    }
}
