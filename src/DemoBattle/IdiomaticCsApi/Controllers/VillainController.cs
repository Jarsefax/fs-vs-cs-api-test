using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using IdiomaticCsApi.Domain.Common.Model.Mapping;
using IdiomaticCsApi.Domain.Common.Repositories;
using IdiomaticCsApi.Domain.Villains;
using IdiomaticCsApi.DTOs;

namespace IdiomaticCsApi.Controllers
{
    [Route("api/villain")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VillainController : ApiController
    {
        private readonly GetVillainsHandler _handler;

        public VillainController()
        {
            _handler = new GetVillainsHandler(new FighterMapper(), new VillainRepository(new DbContext()));
        }

        public IEnumerable<FighterRepresentation> Get() =>
            _handler.Get();
    }
}
