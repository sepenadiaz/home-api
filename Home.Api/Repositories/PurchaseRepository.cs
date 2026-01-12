using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Model;
using Home.Api.Repositories.IRepositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Home.Api.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PurchaseRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseDTO>> GetByFilter(
            PurchaseFilter filter,
            CancellationToken cancellationToken
        )
        {
            return await GetQueryableByFilter(filter, cancellationToken)
                .ProjectTo<PurchaseDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        private IQueryable<Purchase> GetQueryableByFilter(
            PurchaseFilter filter,
            CancellationToken cancellationToken
        )
        {
            var query = context.Purchases
                        .Include(p => p.CreditCard)
                        .OrderByDescending(p => p.Date)
                        .AsQueryable();

            if (filter.CreditCardId.HasValue)
            {
                query = query.Where(p => p.CreditCardId == filter.CreditCardId.Value);
            }

            if (filter.DateFrom.HasValue)
            {
                query = query.Where(p => p.Date >= filter.DateFrom.Value);
            }

            if (filter.DateTo.HasValue)
            {
                query = query.Where(p => p.Date <= filter.DateTo.Value);
            }

            return query;
        }

        public async Task<PurchaseDTO> Add(
            PurchasePostDTO purchase,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            var entityToAdd = mapper.Map<Purchase>(purchase);

            var addedEntity = context.Purchases.Add(entityToAdd).Entity;
            await context.SaveChangesAsync(cancellationToken);

            var dto = await context.Purchases
                .Where(p => p.Id == addedEntity.Id)
                .Include(p => p.CreditCard)
                .ProjectTo<PurchaseDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return dto ?? mapper.Map<PurchaseDTO>(addedEntity);
        }
    }
}


