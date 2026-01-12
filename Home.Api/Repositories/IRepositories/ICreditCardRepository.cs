using Home.Api.DTOs;
using Home.Api.Filters;

namespace Home.Api.Repositories.IRepositories
{
    public interface ICreditCardRepository
    {
        Task<bool> ExistsByFilter(CreditCardFilter filter, CancellationToken cancellationToken = default);
        Task<IEnumerable<CreditCardDTO>> GetByFilter(CreditCardFilter filter, CancellationToken cancellationToken);
        Task<CreditCardDTO> Add(CreditCardPostDTO creditCard, CancellationToken cancellationToken);
        Task<CreditCardDTO?> Update(int id, CreditCardPostDTO creditCard, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}

