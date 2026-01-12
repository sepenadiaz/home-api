namespace Home.Api.DTOs
{
    public class PurchasePostDTO
    {
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CreditCardId { get; set; }
        public int NumberOfPayments { get; set; }
        public int FirstPaymentMonth { get; set; }
        public decimal Amount { get; set; }
    }
}


