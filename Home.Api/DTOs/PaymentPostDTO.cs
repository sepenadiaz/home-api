namespace Home.Api.DTOs
{
    public class PaymentPostDTO
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int PurchaseId { get; set; }
        public int PaymentNumber { get; set; }
        public decimal Amount { get; set; }
    }
}


