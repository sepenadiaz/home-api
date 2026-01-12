using Home.Api.DTOs;
using Home.Api.Validators;
using FluentAssertions;
using Xunit;

namespace Home.Api.UnitTests
{
    public class CreditCardPostDTOValidatorTests
    {
        private readonly CreditCardPostDTOValidator validator = new CreditCardPostDTOValidator();

        [Fact]
        public void Validator_Allows_Valid_Model()
        {
            var dto = new CreditCardPostDTO
            {
                Bank = "Bank A",
                CardBrand = "Visa"
            };

            var result = validator.Validate(dto);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Validator_Rejects_Empty_Bank()
        {
            var dto = new CreditCardPostDTO
            {
                Bank = "",
                CardBrand = "Visa"
            };

            var result = validator.Validate(dto);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(e => e.PropertyName == "Bank");
        }
    }
}




