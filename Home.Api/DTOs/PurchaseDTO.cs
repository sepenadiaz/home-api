using Home.Api.Model.BaseClasses;

namespace Home.Api.DTOs
{
    public class PurchaseDTO : IdentifiableEntity
    {
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CreditCardId { get; set; }
        public int NumberOfPayments { get; set; }
        public decimal Amount { get; set; }
        public string CreditCardName { get; set; } = null!;
    }
}



