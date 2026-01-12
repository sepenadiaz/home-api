using Home.Api.Model.BaseClasses;

namespace Home.Api.DTOs
{
    public class PaymentDTO : IdentifiableEntity
    {
        public string Payment { get; set; } = null!;
        public int Year { get; set; }
        public int Month { get; set; }
        public int PurchaseId { get; set; }
        public string? PurchaseDescription { get; set; } = null;
        public decimal Amount { get; set; }
    }
}



