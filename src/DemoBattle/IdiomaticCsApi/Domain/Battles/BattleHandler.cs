using System.Collections.Generic;
using System.Linq;
using IdiomaticCsApi.Domain.Common.Repositories;
using IdiomaticCsApi.Domain.Heroes.Model;
using IdiomaticCsApi.Domain.Villains.Model;
using IdiomaticCsApi.Domain.Battles.Ordering;
using IdiomaticCsApi.Domain.Common.Model;
using IdiomaticCsApi.DTOs;
using System.Threading.Tasks;
using Common;
using IdiomaticCsApi.Domain.Battles.Fighting;
using IdiomaticCsApi.Domain.Battles.Resolvers;

namespace IdiomaticCsApi.Domain.Battles
{
    public class BattleHandler
    {
        private readonly IRepository<Hero> _heroRepository;
        private readonly IRepository<Villain> _villainRepository;
        private readonly IOrderer<Fighter> _orderer;
        private readonly Comparing.IComparer<int> _comparer;
        private readonly IFightHandler<Fighter> _fightHandler;
        private readonly IWalkoverResolver<int, BattleResult> _walkoverResolver;
        private readonly IBattleResolver<FighterRepresentation, BattleResult> _battleResolver;
        private readonly DefeatedFightersFilterer _filterer;

        public BattleHandler(
            IRepository<Hero> heroRepository,
            IRepository<Villain> villainRepository,
            IOrderer<Fighter> orderer, Comparing.IComparer<int> comparer,
            IFightHandler<Fighter> fightHandler, 
            IWalkoverResolver<int, BattleResult> walkoverResolver,
            IBattleResolver<FighterRepresentation, BattleResult> battleResolver, 
            DefeatedFightersFilterer filterer)
        {
            _heroRepository = heroRepository;
            _villainRepository = villainRepository;
            _orderer = orderer;
            _comparer = comparer;
            _fightHandler = fightHandler;
            _walkoverResolver = walkoverResolver;
            _battleResolver = battleResolver;
            _filterer = filterer;
        }

        public async Task<BattleResult> Resolve(IEnumerable<int> heroIds, IEnumerable<int> villainIds)
        {
            var heroList = heroIds.ToList();
            var villainList = villainIds.ToList();

            var walkoverResult = _walkoverResolver.GetWalkoverResultOrDefault(heroList, villainList);
            if (walkoverResult != null)
            {
                return walkoverResult;
            }

            var heroesInBattle = _heroRepository.GetByIds(heroList).ToList();
            var orderedHeroesInBattle = _orderer.OrderDescending(heroesInBattle).ToList();

            var villainsInBattle = _villainRepository.GetByIds(villainList).ToList();
            var orderedVillainsInBattle = _orderer.OrderDescending(villainsInBattle).ToList();

            await _fightHandler.Resolve(
                _comparer.GetLowest(
                    orderedHeroesInBattle.Count, 
                    orderedVillainsInBattle.Count),
                orderedHeroesInBattle,
                orderedVillainsInBattle);

            var heroesStandingAfterBattle = _filterer.Filter(heroesInBattle)
                //heroesInBattle
                //    .Where(h => h.HasBeenDefeated == false)
                //    .ToList()
                //    .Select(h => new FighterRepresentation
                //    {
                //        Id = h.Id,
                //        Name = h.Name,
                //        Class = h.Class
                //    });

            var villainsStandingAfterBattle =
                villainsInBattle
                    .Where(v => v.HasBeenDefeated == false)
                    .ToList()
                    .Select(v => new FighterRepresentation
                    {
                        Id = v.Id,
                        Name = v.Name,
                        Class = v.Class
                    });

            var result = _battleResolver.Resolve(heroesStandingAfterBattle, villainsStandingAfterBattle);

            return result ?? new BattleResult { ResultMessage = CommonStrings.TieResultString };
        }
    }
}