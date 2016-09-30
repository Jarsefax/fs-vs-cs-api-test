using System.Web.Http;
using System.Web.Http.Cors;
using IdiomaticCsApi.Domain.Battles;
using IdiomaticCsApi.Domain.Common.Repositories;
using IdiomaticCsApi.DTOs;
using IdiomaticCsApi.Domain.Battles.Ordering;
using System.Threading.Tasks;
using IdiomaticCsApi.Domain.Battles.Comparing;
using IdiomaticCsApi.Domain.Battles.Fighting;
using IdiomaticCsApi.Domain.Battles.Resolvers;

namespace IdiomaticCsApi.Controllers
{
    [Route("api/battle")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BattleController : ApiController
    {
        private readonly BattleHandler _handler;

        public BattleController()
        {
            var dbContext = new DbContext();
            var comparer = new IntComparer();

            _handler = new BattleHandler(
                new HeroRepository(dbContext),
                new VillainRepository(dbContext),
                new FighterOrderer(),
                comparer,
                new FightHandler(new FightResolver(comparer)),
                new WalkoverResolver(),
                new BattleResolver());
        }

        public async Task<BattleResult> Post([FromBody] Battle battle) =>
            await _handler.Resolve(battle.Heroes, battle.Villains);
    }
}
