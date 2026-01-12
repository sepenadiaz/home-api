using Home.Api.DTOs;
using Home.Api.Filters;
using Home.Api.Model;
using Home.Api.Repositories.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Home.Api.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PaymentRepository(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDTO>> Add(
            List<PaymentPostDTO> payments,
            CancellationToken cancellationToken
        )
        {
            if (payments == null || !payments.Any())
            {
                throw new ArgumentException("No payments to add.");
            }

            var entities = mapper.Map<List<Payment>>(payments);
            context.Payments.AddRange(entities);
            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<List<PaymentDTO>>(entities);
        }

        private IQueryable<Payment> GetQueryableByFilter(
            PaymentSummaryFilter filter,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            var query = context
                .Payments.Include(p => p.Purchase)
                .ThenInclude(p => p.CreditCard)
                .AsQueryable();

            if (filter.Year.HasValue && filter.Month.HasValue)
            {
                query = query.Where(p =>
                    p.Year == filter.Year.Value && p.Month == filter.Month.Value
                );
            }

            if (filter.StartDate.HasValue)
            {
                var startYear = filter.StartDate.Value.Year;
                var startMonth = filter.StartDate.Value.Month;

                query = query.Where(p =>
                    p.Year > startYear || (p.Year == startYear && p.Month >= startMonth)
                );
            }

            if (filter.EndDate.HasValue)
            {
                var endYear = filter.EndDate.Value.Year;
                var endMonth = filter.EndDate.Value.Month;

                query = query.Where(p =>
                    p.Year < endYear || (p.Year == endYear && p.Month <= endMonth)
                );
            }

            return query;
        }

        public async Task<IEnumerable<PaymentDetailDTO>> GetDetails(
            PaymentDetailFilter filter,
            CancellationToken cancellationToken
        )
        {
            return await GetQueryableByFilter(
                    new PaymentSummaryFilter
                    {
                        Year = filter.Year,
                        Month = filter.Month,
                        StartDate = filter.StartDate,
                        EndDate = filter.EndDate,
                    },
                    cancellationToken
                )
                .GroupBy(p => new { p.Year, p.Month })
                .Select(q => new PaymentDetailDTO
                {
                    Year = q.Key.Year,
                    Month = q.Key.Month,
                    Details = q.GroupBy(r => r.Purchase.CreditCardId)
                        .Select(s => new PaymentDetailCardDTO
                        {
                            CreditCardId = s.Key,
                            CreditCardName = $"{s.First().Purchase.CreditCard.Bank} {s.First().Purchase.CreditCard.CardBrand}",
                            CreditCardLogo = s.First().Purchase.CreditCard.LogoPath,
                            Payments = mapper.Map<IEnumerable<PaymentDTO>>(s.ToList()),
                            Total = s.Sum(t => t.Amount),
                        }),
                    Total = q.Sum(r => r.Amount),
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<PaymentSummaryDTO>> GetSummary(
            PaymentSummaryFilter filter,
            CancellationToken cancellationToken
        )
        {
            return await GetQueryableByFilter(filter, cancellationToken)
                .GroupBy(p => new { p.Year, p.Month })
                .Select(g => new PaymentSummaryDTO
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Total = g.Sum(p => p.Amount),
                    Details = g.GroupBy(p => p.Purchase.CreditCardId)
                        .Select(cg => new PaymentSummaryCardDTO
                        {
                            CreditCardId = cg.Key,
                            CreditCardName = $"{cg.First().Purchase.CreditCard.Bank} {cg.First().Purchase.CreditCard.CardBrand}",
                            CreditCardLogo = cg.First().Purchase.CreditCard.LogoPath,
                            Amount = cg.Sum(p => p.Amount),
                        })
                        .OrderBy(cg => cg.CreditCardId)
                        .ToList(),
                })
                .ToListAsync(cancellationToken);
        }
    }
}


