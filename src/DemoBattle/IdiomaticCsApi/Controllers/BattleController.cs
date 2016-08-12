using IdiomaticCsApi.Model;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IdiomaticCsApi.Controllers
{
    [Route("api/battle")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BattleController : ApiController
    {
        public BattleResult Post([FromBody] Battle battle) => null;
    }
}
