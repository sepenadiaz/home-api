using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Repositories.IRepositories;
using Home.Api.Services.IServices;

namespace Home.Api.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository repository;

        public CreditCardService(ICreditCardRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CreditCardDTO>> Get(CreditCardFilter filter, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await repository.GetByFilter(filter, cancellationToken);
        }

        public async Task<CreditCardDTO?> GetById(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = await repository.GetByFilter(new CreditCardFilter { Id = id }, cancellationToken);
            return results.FirstOrDefault();
        }

        public async Task<CreditCardDTO> Add(CreditCardPostDTO creditCard, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await repository.Add(creditCard, cancellationToken);
        }

        public async Task<CreditCardDTO?> Update(int id, CreditCardPostDTO creditCard, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await repository.Update(id, creditCard, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await repository.Delete(id, cancellationToken);
        }
    }
}


