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
    public class DocumentDeleteCommandHandler : IRequestHandler<DocumentDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Document> _repository;
        private readonly IRepository<DocumentDetail> _detailRepository;

        public DocumentDeleteCommandHandler(IMediator mediator, IRepository<Document> repository, IRepository<DocumentDetail> detailRepository)
        {
            this._mediator = mediator;
            this._repository = repository;
            this._detailRepository = detailRepository;
        }

        public async Task<string> Handle(DocumentDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repository.Get(request.Id);

                foreach (var detail in data.documentDetails)
                {
                    if (detail.Id != Guid.Empty)
                        await _detailRepository.Delete(detail.Id);
                }

                await _repository.Delete(request.Id);

                await _mediator.Publish(new DocumentDeletedNotification { Id = request.Id });
                return await Task.FromResult(JsonSerializer.Serialize(request));
            }
            catch (Exception ex)
            {
                //await _mediator.Publish(new DocumentDeletedNotification { Id = request.Id });
                await _mediator.Publish(new ErroNotification { InternalMessage = "Document delete command handler", Error = ex.Message, Message = ex.StackTrace });
                throw new FinancialInternalException("Ocorreu um erro ao remover o registro", ex);
            }

        }
    }
}
