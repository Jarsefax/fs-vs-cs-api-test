using System.Collections.Generic;
using System.Linq;
using IdiomaticCsApi.Domain.Common.Model;
using IdiomaticCsApi.DTOs;

namespace IdiomaticCsApi.Domain.Battles
{
    public class DefeatedFightersFilterer
    {
        public IEnumerable<FighterRepresentation> Filter(IEnumerable<Fighter> fighters) =>
            fighters
                .Where(h => h.HasBeenDefeated == false)
                .ToList()
                .Select(h => new FighterRepresentation
                {
                    Id = h.Id,
                    Name = h.Name,
                    Class = h.Class
                });
    }
}