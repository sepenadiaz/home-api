using Home.Api.Model.BaseClasses;

namespace Home.Api.Model
{
    public class Payment : IdentifiableEntity
    {
        public int PaymentNumber { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}

