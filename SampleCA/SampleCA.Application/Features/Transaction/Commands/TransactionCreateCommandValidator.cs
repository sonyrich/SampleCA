using FluentValidation;
using SampleCA.Application.Common.Models.Transaction;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;

namespace SampleCA.Application.Features.Transaction.Commands
{
    public class TransactionCreateCommandValidator : AbstractValidator<TransactionCreateCommand>
    {
        public TransactionCreateCommandValidator()
        {
            RuleFor(t => t.TransID)
                .NotEmpty().WithMessage("TransID is required. It is currently null")
                .GreaterThan(0).WithMessage("No Lower than 0");
            RuleFor(t => t.TransTypeID)
                .NotEmpty().WithMessage("TransTypeID is required. It is currently null")
                .GreaterThan(0).WithMessage("No Lower than 0")
                .LessThan(4).WithMessage("No Greater than 4");
            RuleFor(t => t.TransType)
                .MaximumLength(50).WithMessage("TransType can contain at most 50 characters long");
            RuleFor(t => t.PropertyType)
                .MaximumLength(50).WithMessage("PropertyType can contain at most 50 characters long");
            RuleFor(t => t.PropertyCategoryID)
                .GreaterThan(0).WithMessage("No Lower than 0");
            RuleFor(t => t.PropertyCategory)
                .MaximumLength(50).WithMessage("PropertyCategory can contain at most 50 characters long");
            RuleFor(t => t.PropertyModel)
                .MaximumLength(100).WithMessage("PropertyModel can contain at most 100 characters long");
            RuleFor(t => t.KeyinDate)
                .LessThanOrEqualTo(t => DateTime.Now).WithMessage("KeyinDate no greather than now");
            RuleFor(t => t.SubDate)
                .LessThanOrEqualTo(t => DateTime.Now).WithMessage("SubDate no greather than now");
            RuleFor(t => t.SalesType)
                .MaximumLength(50).WithMessage("SalesType can contain at most 50 characters long");
            RuleFor(t => t.ClosingAgtCEANo)
                .MaximumLength(50).WithMessage("ClosingAgtCEANo can contain at most 50 characters long");
            RuleFor(t => t.ClosingAgtBizName)
                .MaximumLength(456).WithMessage("ClosingAgtBizName can contain at most 456 characters long");
            RuleFor(t => t.OptionDate)
                .LessThanOrEqualTo(t => DateTime.Now).WithMessage("OptionDate no greather than now");
            RuleFor(t => t.HseNo)
                .MaximumLength(100).WithMessage("ClosingAgtBizName can contain at most 100 characters long");
            RuleFor(t => t.StreetName)
                .MaximumLength(456).WithMessage("StreetName can contain at most 456 characters long");
            RuleFor(t => t.ProjectName)
                .MaximumLength(456).WithMessage("ProjectName can contain at most 456 characters long");
            RuleFor(t => t.TransactedPrice)
                .NotEmpty().WithMessage("TransactedPrice is required. It is currently null")
                .GreaterThan(0).WithMessage("No Lower than 0");
            RuleFor(t => t.TransactionComm)
                .NotEmpty().WithMessage("TransactionComm is required. It is currently null")
                .GreaterThan(0).WithMessage("No Lower than 0");
            RuleFor(t => t.CurrencyType)
                .MaximumLength(10).WithMessage("CurrencyType can contain at most 10 characters long");
            RuleFor(t => t.CultureCode)
                .MaximumLength(10).WithMessage("CultureCode can contain at most 10 characters long");
            RuleFor(t => t.LastUpdater)
                .MaximumLength(100).WithMessage("LastUpdater can contain at most 100 characters long");

        }
    }
}
