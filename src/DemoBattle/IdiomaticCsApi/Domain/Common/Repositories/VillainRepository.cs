using System.Collections.Generic;
using System.Linq;
using IdiomaticCsApi.Domain.Villains.Model;

namespace IdiomaticCsApi.Domain.Common.Repositories
{
    public class VillainRepository : IRepository<Villain>
    {
        private readonly DbContext _context;

        public VillainRepository(DbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Villain> GetAll() =>
            _context.Villains;

        public IEnumerable<Villain> GetByIds(IEnumerable<int> ids) =>
            _context.Villains.Where(h => ids.Contains(h.Id));
    }
}