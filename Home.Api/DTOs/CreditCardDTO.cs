using Home.Api.Model.BaseClasses;

namespace Home.Api.DTOs
{
    public class CreditCardDTO : IdentifiableEntity
    {
        public string Bank { get; set; } = null!;
        public string CardBrand { get; set; } = null!;
        public string? LogoPath { get; set; }
    }
}


