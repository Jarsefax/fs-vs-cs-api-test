using Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using IdiomaticCsApi.Domain.Villains.Model;

namespace IdiomaticCsApi
{
    public class DbContext
    {
        public IEnumerable<Villain> Villains { get; } = JsonConvert.DeserializeObject<Villain[]>(File.ReadAllText(CommonStrings.VillainStoragePath));
    }
}