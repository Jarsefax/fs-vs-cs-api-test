using IdiomaticCsApi.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IdiomaticCsApi.Controllers
{
    [Route("api/hero")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HeroController : ApiController
    {
        public IEnumerable<FighterRepresentation> Get() => null;
    }
}
