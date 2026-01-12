namespace Home.Api.DTOs
{
    public class PaymentSummaryCardDTO
    {
        public int CreditCardId { get; set; }
        public string CreditCardName { get; set; } = null!;
        public string? CreditCardLogo { get; set; }
        public decimal Amount { get; set; }
    }
}


