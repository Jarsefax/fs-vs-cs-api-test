using Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using IdiomaticCsApi.Domain.Heroes.Model;
using IdiomaticCsApi.Domain.Villains.Model;

namespace IdiomaticCsApi
{
    public class DbContext
    {
        private IEnumerable<Villain> _villains;
        private IEnumerable<Hero> _heroes;

        public IEnumerable<Villain> Villains => _villains ?? (_villains = JsonConvert.DeserializeObject<Villain[]>(File.ReadAllText(CommonStrings.VillainStoragePath)));
        public IEnumerable<Hero> Heroes => _heroes ?? (_heroes = JsonConvert.DeserializeObject<Hero[]>(File.ReadAllText(CommonStrings.HeroStoragePath)));
    }
}