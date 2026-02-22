using Home.Api.Model.BaseClasses;

namespace Home.Api.Model
{
    public class CreditCard : IdentifiableEntity
    {
        public string Bank { get; set; } = null!;
        public string CardBrand { get; set; } = null!;
        public string? LogoPath { get; set; }
        public string? Color { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }

        public CreditCard()
        {
            Purchases = new List<Purchase>();
        }
    }
}


