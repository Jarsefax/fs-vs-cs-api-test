using System.Collections.Generic;
using System.Linq;
using Common;
using IdiomaticCsApi.DTOs;

namespace IdiomaticCsApi.Domain.Battles.Resolvers
{
    public class WalkoverResolver : IWalkoverResolver<int, BattleResult>
    {
        public BattleResult GetWalkoverResultOrDefault(IEnumerable<int> heroes, IEnumerable<int> villains)
        {
            var anyHeroes = heroes.Any();
            var anyVillains = villains.Any();
            if (anyHeroes == false && anyVillains == false)
            {
                {
                    return new BattleResult { ResultMessage = CommonStrings.NoShowResultString };
                }
            }
            if (anyHeroes == true && anyVillains == false)
            {
                {
                    return new BattleResult { ResultMessage = CommonStrings.HeroesByWalkoverResultString };
                }
            }
            if (anyHeroes == false)
            {
                {
                    return new BattleResult { ResultMessage = CommonStrings.VillainsByWalkoverResultString };
                }
            }

            return null;
        }
    }
}