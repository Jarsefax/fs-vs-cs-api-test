using System.Collections.Generic;
using System.Linq;
using IdiomaticCsApi.Domain.Common.Model;

namespace IdiomaticCsApi.Domain.Battles.Ordering
{
    public class FighterOrderer : IOrderer<Fighter>
    {
        public IEnumerable<Fighter> OrderDescending(IEnumerable<Fighter> fighters) =>
            fighters.OrderByDescending(h => h.Power);
    }
}