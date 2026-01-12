using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Repositories.IRepositories;
using FluentValidation;

namespace Home.Api.Validators
{
    public class PurchasePostDTOValidator : AbstractValidator<PurchasePostDTO>
    {
        public PurchasePostDTOValidator(ICreditCardRepository creditCardRepository)
        {
            RuleFor(dto => dto.Description).NotEmpty().MaximumLength(50);
            RuleFor(dto => dto.Date).NotEmpty();
            RuleFor(dto => dto.CreditCardId)
            .NotEmpty()
            .Must((dto, creditCardId) => creditCardRepository.ExistsByFilter(new CreditCardFilter { Id = dto.CreditCardId }).Result)
            .WithMessage("Credit card ID does not exist.");
            RuleFor(dto => dto.NumberOfPayments).NotEmpty();
            RuleFor(dto => dto.FirstPaymentMonth).NotEmpty();
            RuleFor(dto => dto.Amount).NotEmpty();            
        }
    }
}


