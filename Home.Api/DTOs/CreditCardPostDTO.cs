namespace Home.Api.DTOs
{
    public class CreditCardPostDTO
    {
        public string Bank { get; set; } = null!;
        public string CardBrand { get; set; } = null!;
        public string? Color { get; set; }
    }
}


