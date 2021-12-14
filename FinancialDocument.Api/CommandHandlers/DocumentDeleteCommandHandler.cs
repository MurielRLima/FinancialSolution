using FinancialDocument.Api.Commands;
using FinancialDocument.Api.Notifications;
using FinancialDocument.Api.Notifications.Document;
using FinancialDocument.Core.Entities;
using FinancialDocument.Core.Interfaces;
using MediatR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialDocument.Api.CommandHandlers
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
                return await Task.FromResult("Ocorreu um erro ao remover o registro");
            }

        }
    }
}
