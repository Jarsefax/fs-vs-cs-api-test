using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.IO;
using Newtonsoft.Json;
using StraightCsApi.DTOs;

namespace StraightCsApi.Controllers
{
    [Route("api/hero")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HeroController : ApiController
    {
        public IEnumerable<Fighter> Get() =>
            JsonConvert.DeserializeObject<Fighter[]>(File.ReadAllText(@"C:\Users\rnor\Documents\C#vsF#\Heroes.txt"));
    }
}
