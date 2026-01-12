using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Model;
using Home.Api.Repositories.IRepositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Home.Api.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public CreditCardRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> ExistsByFilter(CreditCardFilter filter, CancellationToken cancellationToken)
        {
            return await GetQueryableByFilter(filter, cancellationToken).AnyAsync();
        }

        public async Task<IEnumerable<CreditCardDTO>> GetByFilter(CreditCardFilter filter, CancellationToken cancellationToken)
        {
            return await GetQueryableByFilter(filter, cancellationToken)
                   .ProjectTo<CreditCardDTO>(mapper.ConfigurationProvider)
                   .ToListAsync();
        }

        public IQueryable<CreditCard> GetQueryableByFilter(CreditCardFilter filter, CancellationToken cancellationToken)
        {
            var query = context.CreditCards.AsQueryable();

            // Filter by Id if provided
            if (filter.Id.HasValue)
            {
                query = query.Where(c => c.Id == filter.Id.Value);
            }

            // Filter by Bank if provided
            if (!string.IsNullOrEmpty(filter.Bank))
            {
                query = query.Where(c => c.Bank.Contains(filter.Bank));
            }

            // Filter by CardBrand if provided
            if (!string.IsNullOrEmpty(filter.CardBrand))
            {
                query = query.Where(c => c.CardBrand.Contains(filter.CardBrand));
            }

            return query;
        }

        public async Task<CreditCardDTO> Add(CreditCardPostDTO creditCard, CancellationToken cancellationToken)
        {
            if (creditCard == null) throw new ArgumentNullException(nameof(creditCard));

            var entity = new CreditCard
            {
                Bank = creditCard.Bank,
                CardBrand = creditCard.CardBrand,
            };

            context.CreditCards.Add(entity);
            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<CreditCardDTO>(entity);
        }

        public async Task<CreditCardDTO?> Update(int id, CreditCardPostDTO creditCard, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var entity = await context.CreditCards.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
            if (entity == null) return null;

            entity.Bank = creditCard.Bank;
            entity.CardBrand = creditCard.CardBrand;

            context.CreditCards.Update(entity);
            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<CreditCardDTO>(entity);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var entity = await context.CreditCards.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
            if (entity == null) return false;

            context.CreditCards.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}


