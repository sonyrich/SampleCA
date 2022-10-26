using MediatR;
using SampleCA.Application.Common.Interfaces;
using SampleCA.Application.Features.Transaction.Commands;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Features.Transaction.Handlers
{
    public class TransactionDeleteCommandHandler : IRequestHandler<TransactionDeleteCommand, bool>
    {
        private readonly ITransactionService _transactionService;
        public TransactionDeleteCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<bool> Handle(TransactionDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _transactionService.DeleteTransactionAsync(request.TransId);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
