using IdiomaticCsApi.Model;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IdiomaticCsApi.Controllers
{
    [Route("api/villain")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VillainController : ApiController
    {
        public IEnumerable<FighterRepresentation> Get() => null;
    }
}
