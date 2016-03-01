using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using SimpleApi.Models;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    public class VillainsController : Controller
    {
        public IEnumerable<FighterModel> Get()
        {
            return new[]
            {
                new FighterModel { Id = 1, Name = "Skeletor", Class = "Skeleton" },
                new FighterModel { Id = 2, Name = "Bingo", Class = "Clown" }
            };
        }
    }
}
