using AutoMapper;
using FluentValidation;
using FluentValidation.Internal;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SampleCA.Application.Common.Interfaces;
using SampleCA.Application.Common.Models.Pagination;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Application.Features.Transaction.Commands;
using SampleCA.Application.Features.Transaction.Queries;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;
using SampleCA.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SampleCA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<TransactionCreateCommand> _validator;
        private readonly IValidator<TransactionUpdateCommand> _validatorUpdate;
        public TransactionController(IMediator mediator, IValidator<TransactionCreateCommand> validator, IValidator<TransactionUpdateCommand> validatorUpdate)
        {
            _mediator = mediator;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
        }
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetTransactionByIdQuery model)
        {
            var result = await _mediator.Send(model);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet] 
        [Route("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetTransactionQuery model)
        {

            var result = await _mediator.Send(model);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("create-transaction")]
        public async Task<IActionResult> CreateTransaction(TransactionCreateCommand transactionCreateCommand)
        {
            var validation = await _validator.ValidateAsync(transactionCreateCommand);
            if (validation.IsValid == true)
            {
                    var result = await _mediator.Send(transactionCreateCommand);
                    return Ok(result);
            }
            else
            {
                return BadRequest();
            }       
        }
        [HttpDelete]
        [Route("delete-transaction")]
        public async Task<IActionResult> DeleteTransaction(TransactionDeleteCommand transactionDeleteCommand)
        {
            var result = await _mediator.Send(transactionDeleteCommand);
            return Ok(result);
        }
        [HttpPut]
        [Route("update-transaction")]
        public async Task<IActionResult> UpdateTransaction(TransactionUpdateCommand transactionUpdateCommand)
        {
            var validation = await _validatorUpdate.ValidateAsync((IValidationContext)transactionUpdateCommand);
            if(validation.IsValid == true)
            {
                var result = await _mediator.Send(transactionUpdateCommand);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("get-all-selection")]
        public async Task<IActionResult> GetAllSelectionMode([FromQuery]GetAllSelectionModeQuery getAllSelectionMode)
        {
            var result = await _mediator.Send(getAllSelectionMode);
            return Ok(result);
        }
        [HttpGet]
        [Route("get-all-automapper")]
        public async Task<IActionResult> GetAllAutoMapper([FromQuery]GetAllAsyncAutoMapperQuery getAllAsyncAutoMapper)
        {
            var result = await _mediator.Send(getAllAsyncAutoMapper);
            return Ok(result);
        }
        [HttpGet]
        [Route("get-value-GCE")]
        public async Task<IActionResult> GetValueOfGCE([FromQuery]GetValueOfGCEQuery getValueOfGCEQuery)
        {
            var result = await _mediator.Send(getValueOfGCEQuery);
            return Ok(result);
        }
    }
}
