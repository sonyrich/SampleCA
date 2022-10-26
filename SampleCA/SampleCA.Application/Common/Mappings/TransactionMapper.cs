using AutoMapper;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Application.Features.Transaction.Commands;
using SampleCA.Application.Features.Transaction.Queries;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;

namespace SampleCA.Application.Common.Mappings
{
    public class TransactionMapper : Profile
    {
        public TransactionMapper()
        {
            CreateMap<TransactionDatas, TransactionDatasDTO>().ReverseMap();

            CreateMap<TransactionDatasDTO, TransactionDatas>().ReverseMap();

            CreateMap<TransactionGCEDatas, TransactionGCEDatasDTO>().ReverseMap();

            CreateMap<TransactionGCEDatasDTO, TransactionGCEDatas>().ReverseMap();

            CreateMap<TransactionGCRDatas, TransactionGCRDatasDTO>().ReverseMap();

            CreateMap<TransactionGCRDatasDTO, TransactionGCRDatas>().ReverseMap();

        }
    }
}
