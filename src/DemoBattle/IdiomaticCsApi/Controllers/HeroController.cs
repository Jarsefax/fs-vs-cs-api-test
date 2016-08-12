using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using IdiomaticCsApi.Domain.Common.Model;

namespace IdiomaticCsApi.Controllers
{
    [Route("api/hero")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HeroController : ApiController
    {
        public IEnumerable<FighterRepresentation> Get() => null;
    }
}
