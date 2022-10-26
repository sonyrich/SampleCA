using MediatR;
using SampleCA.Application.Common.Models.Pagination;
using SampleCA.Application.Common.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Features.Transaction.Queries
{
    public class GetAllAsyncAutoMapperQuery : IRequest<PagedResult<TransactionDatasDTO>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public int TransID { get; set; }
        public int TransTypeID { get; set; }
        public string? ClosingAgtCEANo { get; set; }
        public string? ClosingAgtBizName { get; set; }
        public string? ProjectName { get; set; }
        public DateTime OptionDate { get; set; }
    }
}
