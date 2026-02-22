using Home.Api.DTOs;
using Home.Api.Filters;

namespace Home.Api.Services.IServices
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDTO>> Add(List<PaymentPostDTO> payments, CancellationToken cancellationToken);
        Task<PagedResult<PaymentDetailDTO>> GetDetails(PaymentDetailFilter filter, CancellationToken cancellationToken);
        Task<PagedResult<PaymentSummaryDTO>> GetSummary(PaymentSummaryFilter filter, CancellationToken cancellationToken);
    }
}

