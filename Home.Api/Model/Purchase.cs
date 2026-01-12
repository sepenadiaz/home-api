using Home.Api.Model.BaseClasses;

namespace Home.Api.Model
{
    public class Purchase : IdentifiableEntity
    {
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; } = null!;
        public int NumberOfPayments { get; set; }
        public int FirstPaymentMonth { get; set; }
        public decimal Amount { get; set; }
        public IEnumerable<Payment> Payments { get; set; }

        public Purchase()
        {
            Payments = new List<Payment>();
        }
    }
}


