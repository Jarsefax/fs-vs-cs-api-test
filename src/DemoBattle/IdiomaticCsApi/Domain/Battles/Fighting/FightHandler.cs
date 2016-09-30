using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdiomaticCsApi.Domain.Common.Model;

namespace IdiomaticCsApi.Domain.Battles.Fighting
{
    public class FightHandler : IFightHandler<Fighter>
    {
        private readonly IFightResolver<Fighter> _fightResolver;

        public FightHandler(IFightResolver<Fighter> fightResolver)
        {
            _fightResolver = fightResolver;
        }

        public async Task Resolve(int shortestCount, List<Fighter> aFaction, List<Fighter> bFaction)
        {
            for (var i = shortestCount; i >= 0; i--)
            {
                var aFactionAvaliableForFight = aFaction.Skip(i - 1).Where(h => h.HasBeenDefeated == false).ToList();
                var bFactionAvaliableForFight = bFaction.Skip(i - 1).Where(h => h.HasBeenDefeated == false).ToList();

                await Task.Run(() => _fightResolver.Resolve(aFactionAvaliableForFight, bFactionAvaliableForFight));
            }
        }
    }
}