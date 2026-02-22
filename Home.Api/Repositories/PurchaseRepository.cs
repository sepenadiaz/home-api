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

        public async Task<PagedResult<PurchaseDTO>> GetByFilter(
            PurchaseFilter filter,
            CancellationToken cancellationToken
        )
        {
            var query = GetQueryableByFilter(filter, cancellationToken);

            // Get total count before pagination
            var total = await query.CountAsync(cancellationToken);

            // Apply paging if requested
            if (filter.PageNumber.HasValue && filter.PageSize.HasValue)
            {
                var skip = (filter.PageNumber.Value - 1) * filter.PageSize.Value;
                query = query.Skip(skip).Take(filter.PageSize.Value);
            }

            var items = await query
                .ProjectTo<PurchaseDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PagedResult<PurchaseDTO>
            {
                Items = items,
                TotalRecords = total
            };
        }

        private IQueryable<Purchase> GetQueryableByFilter(
            PurchaseFilter filter,
            CancellationToken cancellationToken
        )
        {
            var query = context.Purchases
                        .Include(p => p.CreditCard)
                        .AsQueryable();

            // Apply dynamic sorting if requested
            if (!string.IsNullOrWhiteSpace(filter.SortField))
            {
                var desc = filter.SortDescending ?? false;
                switch (filter.SortField.Trim())
                {
                    case "Date":
                    case "date":
                        query = desc ? query.OrderByDescending(p => p.Date) : query.OrderBy(p => p.Date);
                        break;
                    case "Amount":
                    case "amount":
                        query = desc ? query.OrderByDescending(p => p.Amount) : query.OrderBy(p => p.Amount);
                        break;
                    case "Description":
                    case "description":
                        query = desc ? query.OrderByDescending(p => p.Description) : query.OrderBy(p => p.Description);
                        break;
                    case "CreditCardName":
                    case "creditCardName":
                        // Order by bank then brand to approximate a card name
                        query = desc ? query.OrderByDescending(p => p.CreditCard.Bank).ThenByDescending(p => p.CreditCard.CardBrand)
                                     : query.OrderBy(p => p.CreditCard.Bank).ThenBy(p => p.CreditCard.CardBrand);
                        break;
                    default:
                        // Fallback to Date descending if unknown field
                        query = query.OrderByDescending(p => p.Date);
                        break;
                }
            }
            else
            {
                // Default ordering
                query = query.OrderByDescending(p => p.Date);
            }

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


