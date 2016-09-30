using System.Collections.Generic;
using System.Linq;
using IdiomaticCsApi.Domain.Common.Model;

namespace IdiomaticCsApi.Domain.Battles.Fighting
{
    public class FightResolver : IFightResolver<Fighter>
    {
        private readonly Comparing.IComparer<int> _comparer;

        public FightResolver(Comparing.IComparer<int> comparer)
        {
            _comparer = comparer;
        }

        public void Resolve(List<Fighter> aFaction, List<Fighter> bFaction)
        {
            var aFactionPower = aFaction.Sum(h => h.Power);
            var bFactionPower = bFaction.Sum(h => h.Power);

            int lowest;
            if (_comparer.TryGetLowest(out lowest, aFactionPower, bFactionPower) == false)
            {
                foreach (var hero in aFaction)
                {
                    hero.HasBeenDefeated = true;
                }

                foreach (var villain in bFaction)
                {
                    villain.HasBeenDefeated = true;
                }
            }

            if (lowest > 0)
            {
                foreach (var fighter in bFaction)
                {
                    fighter.HasBeenDefeated = true;
                }
            }
            else if (lowest < 0)
            {
                foreach (var fighter in aFaction)
                {
                    fighter.HasBeenDefeated = true;
                }
            }
        }
    }
}