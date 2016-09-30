using System.Collections.Generic;
using System.Linq;
using IdiomaticCsApi.Domain.Heroes.Model;

namespace IdiomaticCsApi.Domain.Common.Repositories
{
    public class HeroRepository : IRepository<Hero>
    {
        private readonly DbContext _context;

        public HeroRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hero> GetAll() =>
            _context.Heroes;

        public IEnumerable<Hero> GetByIds(IEnumerable<int> ids) =>
            _context.Heroes.Where(h => ids.Contains(h.Id));
    }
}