namespace Home.Api.DTOs
{
    public class PaymentDetailDTO
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public IEnumerable<PaymentDetailCardDTO> Details { get; set; }
        public decimal Total { get; set; }

        public PaymentDetailDTO()
        {
            Details = new List<PaymentDetailCardDTO>();
        }
    }
}


