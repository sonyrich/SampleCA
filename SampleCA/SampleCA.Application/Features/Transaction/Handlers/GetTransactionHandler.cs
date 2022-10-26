using MediatR;
using SampleCA.Application.Common.Interfaces;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Application.Features.Transaction.Queries;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;

namespace SampleCA.Application.Features.Transaction.Handlers
{
    public class GetTransactionHandler : IRequestHandler<GetTransactionQuery, IList<TransactionDatasDTO>>
    {
        private readonly ITransactionService _transactionService;
 

        public GetTransactionHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<IList<TransactionDatasDTO>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {

            return await _transactionService.GetAsync(request);
        }
    }
}
