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
    public class GetValueOfGCEQueryHandler : IRequestHandler<GetValueOfGCEQuery, PagedResult<StatisticTotalValueDTO>>
    {
        private readonly ITransactionService _transactionService;

        public GetValueOfGCEQueryHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<PagedResult<StatisticTotalValueDTO>> Handle(GetValueOfGCEQuery request, CancellationToken cancellationToken)
        {
            return await _transactionService.GetValueOfGCE(request);
        }
    }
}
