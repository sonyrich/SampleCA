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
    public class GetValueOfGCEQuery : IRequest<PagedResult<StatisticTotalValueDTO>>
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
        public string? ClosingAgtCEANo { get; set; }
        public string? ClosingAgtBizName { get; set; }
        public string DateType { get; set; }
        public DateTime Datefrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
