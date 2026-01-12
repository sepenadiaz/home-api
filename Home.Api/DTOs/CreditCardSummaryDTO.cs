namespace Home.Api.DTOs
{
    public class CreditCardSummaryDTO
    {
        public int CreditCardId { get; set; }
        public string Bank { get; set; } = null!;
        public string CardBrand { get; set; } = null!;
        public List<PaymentDTO> Payments { get; set; }
        public decimal Total { get; set; }

        public CreditCardSummaryDTO()
        {
            Payments = new List<PaymentDTO>();
        }
    }
}

