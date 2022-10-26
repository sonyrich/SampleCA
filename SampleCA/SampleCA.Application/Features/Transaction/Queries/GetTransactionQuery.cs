using MediatR;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Features.Transaction.Queries
{
    public class GetTransactionQuery : IRequest<IList<TransactionDatasDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public string? OrderBy { get; set; }

        public int TransID { get; set; }
        public int TransTypeID { get; set; }
        public string? ClosingAgtCEANo { get; set; }
        public string? ClosingAgtBizName { get; set; }
        public string? ProjectName { get; set; }
        public DateTime OptionDate { get; set; }
    }
}
