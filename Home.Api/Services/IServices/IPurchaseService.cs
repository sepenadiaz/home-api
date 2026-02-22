using Home.Api.DTOs;
using Home.Api.Filters;

namespace Home.Api.Services.IServices
{
    public interface IPurchaseService
    {
        Task<PurchaseDTO> Add(PurchasePostDTO purchase, CancellationToken cancellationToken);
        Task<PagedResult<PurchaseDTO>> Get(PurchaseFilter filter, CancellationToken cancellationToken);
    }
}

