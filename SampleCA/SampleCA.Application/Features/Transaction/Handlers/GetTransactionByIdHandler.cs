using MediatR;
using SampleCA.Application.Common.Interfaces;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Application.Features.Transaction.Queries;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;

namespace SampleCA.Application.Features.Transaction.Handlers
{
    public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDatasDTO>
    {
        private readonly ITransactionService _transactionService;
        public GetTransactionByIdHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<TransactionDatasDTO> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        => await _transactionService.GetByIdAsync(request.TransId);
    }
}
