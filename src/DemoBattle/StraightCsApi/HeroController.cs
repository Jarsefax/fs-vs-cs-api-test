using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.IO;
using Common;
using Newtonsoft.Json;

namespace StraightCsApi
{
    [Route("api/hero")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HeroController : ApiController
    {
        public IEnumerable<Fighter> Get() =>
            JsonConvert.DeserializeObject<Fighter[]>(File.ReadAllText(CommonStrings.HeroStoragePath));
    }
}
