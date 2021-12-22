using FinancialDocument.Service.Commands;
using FinancialDocument.Service.Notifications;
using FinancialDocument.Service.Notifications.Document;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using FinancialDocument.Domain.Exceptions;

namespace FinancialDocument.Service.CommandHandlers
{
    public class DocumentUpdateCommandHandler : IRequestHandler<DocumentUpdateCommand, DocumentUpdateResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Document> _repository;
        private readonly IRepository<DocumentDetail> _detailRepository;

        public DocumentUpdateCommandHandler(IMediator mediator, IRepository<Document> repository, IRepository<DocumentDetail> detailRepository)
        {
            this._mediator = mediator;
            this._repository = repository;
            this._detailRepository = detailRepository;
        }

        public async Task<DocumentUpdateResponse> Handle(DocumentUpdateCommand request, CancellationToken cancellationToken)
        {
            Document data = DocumentUpdateCommand.MapTo(request);

            try
            {
                if (!data.ValidateIssueAndDueDate())
                    throw new Exception("A data de vencimento deve ser maior que a emissão.");

                if (!data.ValidateAmount())
                    throw new Exception("A o valor do documento deve ser maior que zero.");

                if ((!data.IsAmountSettled()) && (!data.Settled))
                    throw new Exception("A soma do total das baixas é maior que o total do documento, marque a opção 'quitado'.");

                await _repository.Edit(data);

                foreach (var detail in data.documentDetails)
                {
                    if (detail.Id != Guid.Empty)
                        await _detailRepository.Delete(detail.Id);
                }

                await _detailRepository.Add(data.documentDetails);

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
                return DocumentUpdateResponse.MapTo(data);
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new DocumentUpdatedNotification { Id = data.Id, TradingName = data.TradingName, CorporateName = data.CorporateName, Address = data.Address, Telephone = data.Telephone, Celphone = data.Celphone, Observation = data.Observation, Active = data.Active, IsSupplier = data.IsSupplier, IsCustomer = data.IsCustomer });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Document update command handler", Error = ex.Message, Message = ex.StackTrace });
                throw new FinancialInternalException("Ocorreu um erro ao atualizar o registro", ex);
            }

        }
    }    
}
