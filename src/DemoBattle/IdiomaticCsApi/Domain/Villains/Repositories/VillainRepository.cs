using System.Collections;
using System.Collections.Generic;
using IdiomaticCsApi.Domain.Common;
using IdiomaticCsApi.Domain.Villains.Model;

namespace IdiomaticCsApi.Domain.Villains.Repositories
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
    }
}