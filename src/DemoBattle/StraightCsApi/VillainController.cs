using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.IO;
using Newtonsoft.Json;

namespace StraightCsApi
{
    [Route("api/villain")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VillainController : ApiController
    {
        public IEnumerable<Fighter> Get() =>
            JsonConvert.DeserializeObject<Fighter[]>(File.ReadAllText(@"C:\Users\rnor\Documents\C#vsF#\Villains.txt"));
    }
}
