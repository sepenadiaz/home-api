namespace Home.Api.DTOs
{
    public class PaymentDetailCardDTO
    {
        public int CreditCardId { get; set; }
        public string CreditCardName { get; set; } = null!;
        public string? CreditCardLogo { get; set; }
        public IEnumerable<PaymentDTO> Payments { get; set; }
        public decimal Total { get; set; }

        public PaymentDetailCardDTO()
        {
            Payments = new List<PaymentDTO>();
        }
    }
}


