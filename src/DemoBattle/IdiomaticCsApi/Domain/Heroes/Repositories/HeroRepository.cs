using System.Collections.Generic;
using IdiomaticCsApi.Domain.Common;
using IdiomaticCsApi.Domain.Heroes.Model;

namespace IdiomaticCsApi.Domain.Heroes.Repositories
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
    }
}