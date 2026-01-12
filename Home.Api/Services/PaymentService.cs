using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Repositories.IRepositories;
using Home.Api.Services.IServices;

namespace Home.Api.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository repository;

        public PaymentService(IPaymentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PaymentDTO>> Add(List<PaymentPostDTO> payments, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await repository.Add(payments, cancellationToken);
        }

        public async Task<IEnumerable<PaymentDetailDTO>> GetDetails(PaymentDetailFilter filter, CancellationToken cancellationToken)
        {
            return await repository.GetDetails(filter, cancellationToken);
        }

        public async Task<IEnumerable<PaymentSummaryDTO>> GetSummary(PaymentSummaryFilter filter, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await repository.GetSummary(filter, cancellationToken);
        }
    }
}


