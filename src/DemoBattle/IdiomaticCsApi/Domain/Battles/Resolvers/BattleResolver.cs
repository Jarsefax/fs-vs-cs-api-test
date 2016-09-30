using System.Collections.Generic;
using System.Linq;
using Common;
using IdiomaticCsApi.DTOs;

namespace IdiomaticCsApi.Domain.Battles.Resolvers
{
    public class BattleResolver : IBattleResolver<FighterRepresentation, BattleResult>
    {
        public BattleResult Resolve(IEnumerable<FighterRepresentation> factionA, IEnumerable<FighterRepresentation> factionB)
        {
            if (factionA.Any())
            {
                return new BattleResult
                {
                    ResultMessage = CommonStrings.HeroesWinResultString,
                    FightersLeftStanding = factionA
                };
            }
            if (factionB.Any())
            {
                return new BattleResult
                {
                    ResultMessage = CommonStrings.VillainsWinResultString,
                    FightersLeftStanding = factionB
                };
            }

            return null;
        }
    }
}