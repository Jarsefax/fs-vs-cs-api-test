using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using IdiomaticCsApi.Domain.Common.Model;
using IdiomaticCsApi.Domain.Common.Model.Mapping;
using IdiomaticCsApi.Domain.Heroes;
using IdiomaticCsApi.Domain.Heroes.Repositories;

namespace IdiomaticCsApi.Controllers
{
    [Route("api/hero")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HeroController : ApiController
    {
        private readonly GetHeroesHandler _handler;

        public HeroController()
        {
            _handler = new GetHeroesHandler(new FighterMapper(), new HeroRepository(new DbContext()));
        }

        public IEnumerable<FighterRepresentation> Get() =>
            _handler.Get();
    }
}
