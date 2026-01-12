using Home.Api.DTOs;
using Home.Api.Filters;

namespace Home.Api.Services.IServices
{
    public interface ICreditCardService
    {
        Task<IEnumerable<CreditCardDTO>> Get(CreditCardFilter filter, CancellationToken cancellationToken);
        Task<CreditCardDTO?> GetById(int id, CancellationToken cancellationToken);
        Task<CreditCardDTO> Add(CreditCardPostDTO creditCard, CancellationToken cancellationToken);
        Task<CreditCardDTO?> Update(int id, CreditCardPostDTO creditCard, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}


