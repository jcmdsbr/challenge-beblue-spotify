using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SC.Application.Repositories;
using SC.Domain.Entities;
using SC.Domain.Queries.Models;

namespace SC.Infrastructure.Repositories
{
    public class SaleReadOnlyRepository : ReadDbContext<Sale>, ISaleReadOnlyRepository
    {
        public SaleReadOnlyRepository(SCContext db) : base(db)
        {
        }

        public  async Task<SaleViewQueryModel> GetViewQueryModelById(Guid id)
        {
            return await Query
                .Include(x => x.Details)
                .Where(x => x.Id == id)
                .Select(ProjectToViewQueryModel())
                .FirstOrDefaultAsync();
        }

        public async Task<SalePagedQueryModel> GetPaged(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;

            var query =  BaseFullQueryNoTracking()
                .Skip(skip).Take(pageSize).Select(ProjectToViewQueryModel());


            var sales = await query.ToListAsync();

            var result = new SalePagedQueryModel(sales)
            {
                CurrentPage = page, PageSize = pageSize, 
            };

            result.RowCount = await Query.CountAsync();
            result.PageCount = (int)Math.Ceiling((double)result.RowCount / pageSize);

            return result;
        }

        private static Expression<Func<Sale, SaleViewQueryModel>> ProjectToViewQueryModel()
        {
            return sale =>
                new SaleViewQueryModel(
                    sale.RealizedAt,
                    sale.Price,
                    sale.Cashback,
                    sale.CustomerCpf,
                    sale.Details.Select(detail => new SaleDetailViewQuerymodel(detail.Cashback, detail.Playlist.Name)), sale.Id);
        }

        private IIncludableQueryable<Sale, Playlist> BaseFullQueryNoTracking()
        {
            return Query
                .AsNoTracking()
                .Include(x=>x.Details).ThenInclude(x=>x.Playlist);
        }
    }
}
