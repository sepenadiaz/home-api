using Home.Api.DTOs;
using Home.Api.Filters;

namespace Home.Api.Repositories.IRepositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentDTO>> Add(List<PaymentPostDTO> payments, CancellationToken cancellationToken);
        Task<PagedResult<PaymentDetailDTO>> GetDetails(PaymentDetailFilter filter, CancellationToken cancellationToken);
        Task<PagedResult<PaymentSummaryDTO>> GetSummary(PaymentSummaryFilter filter, CancellationToken cancellationToken);
    }
}

