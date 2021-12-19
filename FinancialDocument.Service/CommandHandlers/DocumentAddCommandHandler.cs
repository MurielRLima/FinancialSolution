using FinancialDocument.Service.Commands;
using FinancialDocument.Service.Notifications;
using FinancialDocument.Service.Notifications.Document;
using FinancialDocument.Domain.Entities;
using FinancialDocument.Domain.Interfaces;
using MediatR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FinancialDocument.Domain.Exceptions;

namespace FinancialDocument.Service.CommandHandlers
{
    public class DocumentAddCommandHandler : IRequestHandler<DocumentAddCommand, DocumentAddResponse>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Document> _repository;
        private readonly IRepository<DocumentDetail> _detailRepository;

        public DocumentAddCommandHandler(IMediator mediator, IRepository<Document> repository, IRepository<DocumentDetail> detailRepository)
        {
            this._mediator = mediator;
            this._repository = repository;
            this._detailRepository = detailRepository;
        }

        public async Task<DocumentAddResponse> Handle(DocumentAddCommand request, CancellationToken cancellationToken)
        {
            Document data = DocumentAddCommand.MapTo(request);

            try
            {
                await _repository.Add(data);
                //await _detailRepository.Add(data.documentDetails);

                await _mediator.Publish(
                    new DocumentAddedNotification
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
                return DocumentAddResponse.MapTo(data);
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new BusinessPartnerAddedNotification { Id = data.Id, TradingName = data.TradingName, CorporateName = data.CorporateName, Address = data.Address, Telephone = data.Telephone, Celphone = data.Celphone, Observation = data.Observation, Active = data.Active, IsSupplier = data.IsSupplier, IsCustomer = data.IsCustomer });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Document add command handler", Error = ex.Message, Message = ex.StackTrace });
                throw new FinancialInternalException("Ocorreu um erro ao criar o registro", ex);
            }

        }
    }
}
