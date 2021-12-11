using FinancialDocument.Api.Commands;
using FinancialDocument.Api.Notifications;
using FinancialDocument.Api.Notifications.Document;
using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Api.CommandHandlers
{
    public class DocumentUpdateCommandHandler : IRequestHandler<DocumentUpdateCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Document> _repository;

        public DocumentUpdateCommandHandler(IMediator mediator, IRepository<Document> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(DocumentUpdateCommand request, CancellationToken cancellationToken)
        {
            Document data = DocumentUpdateCommand.MapTo(request);

            try
            {
                await _repository.Edit(data);
                await _mediator.Publish(
                    new DocumentUpdatedNotification
                    {
                        Id = data.Id,
                        DocumentNumber = data.DocumentNumber,
                        BusinessPartnerId = data.BusinessPartnerId,
                        DocumentType = data.DocumentType,
                        IssueDate = data.IssueDate,
                        DueDate = data.DueDate,
                        Amount = data.Amount,
                        PaymentMethodId = data.PaymentMethodId,
                        ReceivingLocationId = data.ReceivingLocationId,
                        Observation = data.Observation,
                        Settled = data.Settled,
                        Active = data.Active
                    }
                );
                return await Task.FromResult(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new DocumentUpdatedNotification { Id = data.Id, TradingName = data.TradingName, CorporateName = data.CorporateName, Address = data.Address, Telephone = data.Telephone, Celphone = data.Celphone, Observation = data.Observation, Active = data.Active, IsSupplier = data.IsSupplier, IsCustomer = data.IsCustomer });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Document update command handler", Error = ex.Message, Message = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro ao atualizar o registro");
            }

        }
    }
}
