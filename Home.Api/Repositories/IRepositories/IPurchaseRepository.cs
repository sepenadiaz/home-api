using Home.Api.DTOs;
using Home.Api.Filters;

namespace Home.Api.Repositories.IRepositories
{
    public interface IPurchaseRepository
    {
        Task<PurchaseDTO> Add(PurchasePostDTO purchase, CancellationToken cancellationToken);
        Task<PagedResult<PurchaseDTO>> GetByFilter(PurchaseFilter filter, CancellationToken cancellationToken);
    }
}

