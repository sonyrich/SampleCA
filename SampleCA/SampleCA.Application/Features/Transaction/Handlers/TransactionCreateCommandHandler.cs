using MediatR;
using SampleCA.Application.Common.Extentions;
using SampleCA.Application.Common.Interfaces;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Application.Features.Transaction.Commands;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;

namespace SampleCA.Application.Features.Transaction.Handlers
{
    public class TransactionCreateCommandHandler : IRequestHandler<TransactionCreateCommand, bool>
    {
        private readonly ITransactionService _transactionService;

        public TransactionCreateCommandHandler (ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<bool> Handle(TransactionCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _transactionService.AddTransactionAsync(request);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
