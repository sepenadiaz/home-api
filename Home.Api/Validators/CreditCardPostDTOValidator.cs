using Home.Api.DTOs;
using FluentValidation;

namespace Home.Api.Validators
{
    public class CreditCardPostDTOValidator : AbstractValidator<CreditCardPostDTO>
    {
        public CreditCardPostDTOValidator()
        {
            RuleFor(x => x.Bank)
                .NotEmpty().WithMessage("Bank is required.")
                .MaximumLength(50).WithMessage("Bank must be at most 50 characters.");

            RuleFor(x => x.CardBrand)
                .NotEmpty().WithMessage("CardBrand is required.")
                .MaximumLength(50).WithMessage("CardBrand must be at most 50 characters.");
        }
    }
}


