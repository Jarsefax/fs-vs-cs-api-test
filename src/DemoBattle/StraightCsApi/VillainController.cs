using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.IO;
using Common;
using Newtonsoft.Json;

namespace StraightCsApi
{
    [Route("api/villain")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VillainController : ApiController
    {
        public IEnumerable<Fighter> Get() =>
            JsonConvert.DeserializeObject<Fighter[]>(File.ReadAllText(CommonStrings.VillainStoragePath));
    }
}
