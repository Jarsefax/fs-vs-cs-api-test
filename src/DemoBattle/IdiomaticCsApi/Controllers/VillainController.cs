using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using IdiomaticCsApi.Domain.Common.Model;
using IdiomaticCsApi.Domain.Common.Model.Mapping;
using IdiomaticCsApi.Domain.Villains;
using IdiomaticCsApi.Domain.Villains.Repositories;

namespace IdiomaticCsApi.Controllers
{
    [Route("api/villain")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VillainController : ApiController
    {
        private readonly VillainGetter _getter;

        public VillainController()
        {
            _getter = new VillainGetter(new FighterMapper(), new VillainRepository(new DbContext()));
        }

        public IEnumerable<FighterRepresentation> Get() =>
            _getter.Get();
    }
}
