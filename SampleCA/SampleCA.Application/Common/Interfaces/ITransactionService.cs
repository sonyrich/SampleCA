using SampleCA.Application.Common.Models.Pagination;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Application.Features.Transaction.Commands;
using SampleCA.Application.Features.Transaction.Queries;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;

namespace SampleCA.Application.Common.Interfaces
{
    public interface ITransactionService
    {
        Task <TransactionDatasDTO> GetByIdAsync(int? id);
        Task<bool> AddTransactionAsync(TransactionCreateCommand transactionCommand);
        Task<bool> UpdateTransactionAsync(TransactionUpdateCommand transactionUpdateCommand);
        Task<bool> DeleteTransactionAsync(int? id);
        Task <IList<TransactionDatasDTO>> GetAsync(GetTransactionQuery request);
        Task<PagedResult<TransactionDatasDTO>> GetAllAsync(GetAllSelectionModeQuery request);
        Task<PagedResult<TransactionDatasDTO>> GetAllAsyncAutoMapper (GetAllAsyncAutoMapperQuery request);
        Task<PagedResult<StatisticTotalValueDTO>> GetValueOfGCE (GetValueOfGCEQuery request);
    } 
}
