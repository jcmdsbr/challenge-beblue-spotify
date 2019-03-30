using System.Threading.Tasks;
using SC.Application.Repository;

namespace SC.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SCContext _context;

        public UnitOfWork(SCContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}