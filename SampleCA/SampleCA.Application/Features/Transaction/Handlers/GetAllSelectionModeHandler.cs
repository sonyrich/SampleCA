using MediatR;
using SampleCA.Application.Common.Interfaces;
using SampleCA.Application.Common.Models.Pagination;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Application.Features.Transaction.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Features.Transaction.Handlers
{
    public class GetAllSelectionModeHandler : IRequestHandler<GetAllSelectionModeQuery, PagedResult<TransactionDatasDTO>>
    {
        private readonly ITransactionService _transactionService;

        public GetAllSelectionModeHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<PagedResult<TransactionDatasDTO>> Handle(GetAllSelectionModeQuery request, CancellationToken cancellationToken)
        {
            return await _transactionService.GetAllAsync(request);
        }
    }
}
