using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Features.Transaction.Commands
{
    public class TransactionDeleteCommand : IRequest<bool>
    {
        public int TransId { get; set; }
    }

}
