using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Repositories.IRepositories;
using Home.Api.Services.IServices;

namespace Home.Api.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository purchaseRepository;
        private readonly IPaymentService paymentService;

        public PurchaseService(
            IPurchaseRepository purchaseRepository,
            IPaymentService paymentService
        )
        {
            this.purchaseRepository = purchaseRepository;
            this.paymentService = paymentService;
        }

        public async Task<PurchaseDTO> Add(
            PurchasePostDTO purchase,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            var savedPurchase = await purchaseRepository.Add(purchase, cancellationToken);

            var payments = new List<PaymentPostDTO>();
            var year = purchase.Date.Year;
            var month = purchase.FirstPaymentMonth;

            if (purchase.FirstPaymentMonth < purchase.Date.Month)
            {
                year++;
            }

            for (int i = 0; i < purchase.NumberOfPayments; i++)
            {
                var payment = new PaymentPostDTO
                {
                    Year = year,
                    Month = month,
                    PurchaseId = savedPurchase.Id,
                    PaymentNumber = i + 1,
                    Amount = savedPurchase.Amount / savedPurchase.NumberOfPayments,
                };

                payments.Add(payment);

                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }

            await paymentService.Add(payments, cancellationToken);

            return savedPurchase;
        }

        public async Task<PagedResult<PurchaseDTO>> Get(
            PurchaseFilter filter,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await purchaseRepository.GetByFilter(filter, cancellationToken);
        }
    }
}


