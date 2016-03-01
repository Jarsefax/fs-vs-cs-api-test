using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using SimpleApi.Models;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        public IEnumerable<FighterModel> Get()
        {
            return new[]
            {
                new FighterModel { Id = 1, Name = "He-Man", Class = "Warrior" },
                new FighterModel { Id = 2, Name = "Stan Marsh", Class = "Hunter, Lvl 2" }
            };
        }
    }
}
