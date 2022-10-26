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
    public class GetTransactionByIdQuery : IRequest<TransactionDatasDTO>
    {
        public int TransId { get; set; }
    }
}
