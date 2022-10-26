using AutoMapper;
using AutoMapper.QueryableExtensions;
using CMSAPI.SampleCA.Application.Common.Mappings;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SampleCA.Application.Common.Interfaces;
using SampleCA.Application.Common.Models.Pagination;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Application.Features.Transaction.Commands;
using SampleCA.Application.Features.Transaction.Queries;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;
using SampleCA.Infrastructure.Persistence.Persistence;

namespace SampleCA.Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly AESTrainingContext _context;

        public TransactionService(IMapper mapper, AESTrainingContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> AddTransactionAsync(TransactionCreateCommand transactionCommand)
        {
            try
            {
                var newtrasaction = new TransactionDatas
                {
                    TransID = transactionCommand.TransID,
                    TransTypeID = transactionCommand.TransTypeID,
                    TransType = transactionCommand.TransType,
                    PropertyType = transactionCommand.PropertyType,
                    PropertyCategoryID = transactionCommand.PropertyCategoryID,
                    PropertyCategory = transactionCommand.PropertyCategory,
                    PropertyModel = transactionCommand.PropertyModel,
                    KeyinDate = transactionCommand.KeyinDate,
                    SubDate = transactionCommand.SubDate,
                    SalesType = transactionCommand.SalesType,
                    ClosingAgtCEANo = transactionCommand.ClosingAgtCEANo,
                    ClosingAgtBizName = transactionCommand.ClosingAgtBizName,
                    OptionDate = transactionCommand.OptionDate,
                    HseNo = transactionCommand.HseNo,
                    StreetName = transactionCommand.StreetName,
                    ProjectName = transactionCommand.ProjectName,
                    TransactedPrice = transactionCommand.TransactedPrice,
                    TransactionComm = transactionCommand.TransactionComm,
                    CurrencyType = transactionCommand.CurrencyType,
                    CultureCode = transactionCommand.CultureCode,
                    LastUpdater = transactionCommand.LastUpdater
                };

                await _context.TransactionDatas.AddAsync(newtrasaction);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteTransactionAsync(int? id)
        {
            try
            {
                var deltrasaction = await _context.TransactionDatas.FirstAsync(k => k.TransID == id);
                if (deltrasaction != null)
                {
                    _context.Remove(deltrasaction);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<PagedResult<TransactionDatasDTO>> GetAllAsync(GetAllSelectionModeQuery request)
        {
            var pagedata = _context.TransactionDatas.
                Include(e => e.TransactionGCEDatas).
                Include(r => r.TransactionGCRDatas).
                AsNoTracking().
                Where(k => (request.TransID == default || k.TransID == request.TransID) &&
                (request.TransTypeID == default || k.TransTypeID == request.TransTypeID) &&
                (request.ClosingAgtCEANo == default || k.ClosingAgtCEANo.StartsWith(request.ClosingAgtCEANo)) &&
                (request.ClosingAgtBizName == default || k.ClosingAgtBizName.StartsWith(request.ClosingAgtBizName)) &&
                (request.ProjectName == default || k.ProjectName.StartsWith(request.ProjectName)) &&
                (request.OptionDate == default || k.OptionDate == request.OptionDate)).
                Select(d => new TransactionDatasDTO
                {
                    TransType = d.TransType,
                    PropertyType = d.PropertyType,
                    PropertyCategory = d.PropertyCategory,
                    PropertyModel = d.PropertyModel,
                    SalesType = d.SalesType,
                    ClosingAgtCEANo = d.ClosingAgtCEANo,
                    ClosingAgtBizName = d.ClosingAgtBizName,
                    StreetName = d.StreetName,
                    ProjectName = d.ProjectName,
                    TransactedPrice = d.TransactedPrice,
                    TransactionComm = d.TransactionComm,
                    CultureCode = d.CultureCode,
                    CurrencyType = d.CurrencyType,
                    TransactionGCEDatas = d.TransactionGCEDatas.Select(g => new TransactionGCEDatasDTO()
                    {
                        GrossValue = g.GrossValue,
                        AgtBizName = g.AgtBizName,
                        AgtCEANo = g.AgtCEANo,
                        CategoryDisplay = g.CategoryDisplay,
                        NetValue = g.NetValue,
                        RoleDisplay = g.RoleDisplay,
                        StatisticsRatio = g.StatisticsRatio
                    }).ToList(),
                    TransactionGCRDatas = d.TransactionGCRDatas.Select(q => new TransactionGCRDatasDTO()
                    {
                        AgtBizName = q.AgtBizName,
                        AgtCEANo = q.AgtCEANo,
                        CategoryDisplay = q.CategoryDisplay,
                        GrossValue = q.GrossValue,
                        NetValue = q.NetValue,
                        RcvDate = q.RcvDate,
                        RoleDisplay = q.RoleDisplay,
                        TransSource = q.TransSource
                    }).ToList()
                });
            return PagedResult<TransactionDatasDTO>.GetPaged(pagedata, request.PageNumber, request.PageSize);
        }

        public async Task<PagedResult<TransactionDatasDTO>> GetAllAsyncAutoMapper(GetAllAsyncAutoMapperQuery request)
        {
            var pagedata = _context.TransactionDatas.
                Include(e => e.TransactionGCEDatas).
                Include(r => r.TransactionGCRDatas).
                AsNoTracking().
                Where(k => (request.TransID == default || k.TransID == request.TransID) &&
                (request.TransTypeID == default || k.TransTypeID == request.TransTypeID) &&
                (request.ClosingAgtCEANo == default || k.ClosingAgtCEANo.StartsWith(request.ClosingAgtCEANo)) &&
                (request.ClosingAgtBizName == default || k.ClosingAgtBizName.StartsWith(request.ClosingAgtBizName)) &&
                (request.ProjectName == default || k.ProjectName.StartsWith(request.ProjectName)) &&
                (request.OptionDate == default || k.OptionDate == request.OptionDate)).
                ProjectTo<TransactionDatasDTO>(_mapper.ConfigurationProvider);
            return PagedResult<TransactionDatasDTO>.GetPaged(pagedata, request.PageNumber, request.PageSize);
        }

        public async Task<IList<TransactionDatasDTO>> GetAsync(GetTransactionQuery request)
        {
            var trasactionList = await _context.TransactionDatas.AsNoTracking().
                Where(k => (request.TransID == default || k.TransID == request.TransID) &&
                (request.TransTypeID == default || k.TransTypeID == request.TransTypeID) &&
                (request.ClosingAgtCEANo == default || k.ClosingAgtCEANo.StartsWith(request.ClosingAgtCEANo)) &&
                (request.ClosingAgtBizName == default || k.ClosingAgtBizName.StartsWith(request.ClosingAgtBizName)) &&
                (request.ProjectName == default || k.ProjectName.StartsWith(request.ProjectName)) &&
                (request.OptionDate == default || k.OptionDate == request.OptionDate))
                .OrderBy(t => t.TransTypeID)
                .ProjectTo<TransactionDatasDTO>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
            return trasactionList;
        }

        public async Task<TransactionDatasDTO> GetByIdAsync(int? id)
        {
            var transaction = await _context.TransactionDatas.AsNoTracking().FirstAsync(k => k.TransID == id);
            return _mapper.Map<TransactionDatasDTO>(transaction);
        }

        public async Task<PagedResult<StatisticTotalValueDTO>> GetValueOfGCE(GetValueOfGCEQuery request)
        {
            var pagedata = _context.TransactionDatas.
                Include(d => d.TransactionGCEDatas).
                AsNoTracking().
                Where(k => (request.ClosingAgtCEANo == default || k.ClosingAgtCEANo == request.ClosingAgtCEANo) &&
                (k.ClosingAgtBizName == request.ClosingAgtBizName) &&
                ((request.DateType == "SubDate") ?
                (k.SubDate >= request.Datefrom && k.SubDate <= request.DateTo && request.Datefrom <= request.DateTo) :
                (k.OptionDate >= request.Datefrom && k.OptionDate <= request.DateTo && request.Datefrom <= request.DateTo))
                ).
                Select(c => new StatisticTotalValueDTO
                {
                    TransID = c.TransID,
                    TransType = c.TransType,
                    HseNo = c.HseNo,
                    ClosingAgtBizName = c.ClosingAgtBizName,
                    ClosingAgtCEANo = c.ClosingAgtCEANo,
                    StreetName = c.StreetName,
                    ProjectName = c.ProjectName,
                    TotalGrossValue = c.TransactionGCEDatas.
                    Where(z => (z.AgtBizName == request.ClosingAgtBizName)
                    && (request.ClosingAgtCEANo == default || z.AgtCEANo == request.ClosingAgtCEANo)).
                    Sum(e => e.GrossValue),
                    TotalNetValue = c.TransactionGCEDatas.
                    Where(z => (z.AgtBizName == request.ClosingAgtBizName)
                    && (request.ClosingAgtCEANo == default || z.AgtCEANo == request.ClosingAgtCEANo)).
                    Sum(o => o.NetValue),
                });
            return PagedResult<StatisticTotalValueDTO>.GetPaged(pagedata, request.PageNumber, request.PageSize);
        }

        public async Task<bool> UpdateTransactionAsync(TransactionUpdateCommand transactionUpdateCommand)
        {
            try
            {
                var updatetransaction = await _context.TransactionDatas.FirstAsync(k => k.TransID == transactionUpdateCommand.TransID);
                if (updatetransaction != null)
                {
                    updatetransaction.TransTypeID = transactionUpdateCommand.TransTypeID;
                    updatetransaction.TransType = transactionUpdateCommand.TransType;
                    updatetransaction.PropertyType = transactionUpdateCommand.PropertyType;
                    updatetransaction.PropertyCategoryID = transactionUpdateCommand.PropertyCategoryID;
                    updatetransaction.PropertyCategory = transactionUpdateCommand.PropertyCategory;
                    updatetransaction.PropertyModel = transactionUpdateCommand.PropertyModel;
                    updatetransaction.KeyinDate = transactionUpdateCommand.KeyinDate;
                    updatetransaction.SubDate = transactionUpdateCommand.SubDate;
                    updatetransaction.SalesType = transactionUpdateCommand.SalesType;
                    updatetransaction.ClosingAgtCEANo = transactionUpdateCommand.ClosingAgtCEANo;
                    updatetransaction.ClosingAgtBizName = transactionUpdateCommand.ClosingAgtBizName;
                    updatetransaction.OptionDate = transactionUpdateCommand.OptionDate;
                    updatetransaction.HseNo = transactionUpdateCommand.HseNo;
                    updatetransaction.StreetName = transactionUpdateCommand.StreetName;
                    updatetransaction.ProjectName = transactionUpdateCommand.ProjectName;
                    updatetransaction.TransactedPrice = transactionUpdateCommand.TransactedPrice;
                    updatetransaction.TransactionComm = transactionUpdateCommand.TransactionComm;
                    updatetransaction.CurrencyType = transactionUpdateCommand.CurrencyType;
                    updatetransaction.CultureCode = transactionUpdateCommand.CultureCode;
                    updatetransaction.LastUpdater = transactionUpdateCommand.LastUpdater;
                    _context.Update(updatetransaction);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

    }
}
