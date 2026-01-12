namespace Home.Api.DTOs
{
    public class PaymentSummaryDTO
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public IEnumerable<PaymentSummaryCardDTO> Details { get; set; }
        public decimal Total { get; set; }

        public PaymentSummaryDTO()
        {
            Details = new List<PaymentSummaryCardDTO>();
        }
    }
}


