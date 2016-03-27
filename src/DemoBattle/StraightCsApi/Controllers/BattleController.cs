﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using StraightCsApi.DTOs;
using StraightCsApi.Model;

namespace StraightCsApi.Controllers
{
    [Route("api/battle")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BattleController : ApiController
    {
        public BattleResult Post([FromBody] Battle battle)
        {
            var anyVillains = battle.Villains != null && battle.Villains.Any();
            var anyHeroes = battle.Heroes != null && battle.Heroes.Any();
            if (anyHeroes == false && anyVillains == false)
            {
                return new BattleResult { ResultMessage = "Most boring fight ever..." };
            }
            if (anyHeroes && anyVillains == false)
            {
                return new BattleResult { ResultMessage = "The cowardly villains never showed up. The Heroes wins ! ! !" };
            }
            if (anyHeroes == false && anyVillains)
            {
                return new BattleResult { ResultMessage = "The villains win (the Heroes had better things to do)." };
            }

            var path = @"C:\Users\rnor\Documents\C#vsF#";

            var heroesPath = Path.Combine(path, "Heroes.txt");
            var heroesListString = System.IO.File.ReadAllText(heroesPath);
            var heroList = JsonConvert.DeserializeObject<List<FighterModel>>(heroesListString);
            var heroesInBattle = heroList.Where(v => battle.Heroes.Contains(v.Id)).ToList();
            var orderedHeroesInBattle = heroesInBattle.OrderByDescending(h => h.Power);

            var villainPath = Path.Combine(path, "Villains.txt");
            var villainListString = System.IO.File.ReadAllText(villainPath);
            var villainList = JsonConvert.DeserializeObject<List<FighterModel>>(villainListString);
            var villainsInBattle = villainList.Where(v => battle.Villains.Contains(v.Id)).ToList();
            var orderedVillainsInBattle = villainsInBattle.OrderByDescending(h => h.Power);

            var heroesInBattleCount = orderedHeroesInBattle.Count();
            var villainsInBattleCount = orderedVillainsInBattle.Count();
            var countCompare = heroesInBattleCount.CompareTo(villainsInBattleCount);
            int shortestCount;
            if (countCompare > 0)
            {
                shortestCount = villainsInBattleCount;
            }
            else
            {
                shortestCount = heroesInBattleCount;
            }

            for (var i = shortestCount; i >= 0; i--)
            {
                var heroesAvaliableForFight = orderedHeroesInBattle.Skip(i - 1).Where(h => h.HasBeenDefeated == false).ToList();
                var heroesPower = heroesAvaliableForFight.Sum(h => h.Power);

                var villainsAvaliableForFight = orderedVillainsInBattle.Skip(i - 1).Where(h => h.HasBeenDefeated == false).ToList();
                var villainsPower = villainsAvaliableForFight.Sum(h => h.Power);

                var powerCompare = heroesPower.CompareTo(villainsPower);
                if (powerCompare > 0)
                {
                    foreach (var villain in villainsAvaliableForFight)
                    {
                        villain.HasBeenDefeated = true;
                    }
                }
                else if (powerCompare < 0)
                {
                    foreach (var hero in heroesAvaliableForFight)
                    {
                        hero.HasBeenDefeated = true;
                    }
                }
                else
                {
                    foreach (var hero in heroesAvaliableForFight)
                    {
                        hero.HasBeenDefeated = true;
                    }

                    foreach (var villain in villainsAvaliableForFight)
                    {
                        villain.HasBeenDefeated = true;
                    }
                }
            }

            var heroesStandingAfterBattle = 
                heroesInBattle
                .Where(h => h.HasBeenDefeated == false)
                .ToList()
                .Select(h => new Fighter
                {
                    Id = h.Id,
                    Name = h.Name,
                    Class = h.Class
                })
                .ToList();
            if (heroesStandingAfterBattle.Any())
            {
                return new BattleResult
                {
                    ResultMessage = "The Heroes stand victorious ! ! !",
                    FightersLeftStanding = heroesStandingAfterBattle
                };
            }

            var villainsStandingAfterBattle =
                villainsInBattle
                .Where(v => v.HasBeenDefeated == false)
                .ToList()
                .Select(v => new Fighter
                {
                    Id = v.Id,
                    Name = v.Name,
                    Class = v.Class
                })
                .ToList();
            if (villainsStandingAfterBattle.Any())
            {
                return new BattleResult
                {
                    ResultMessage = "The villains won the battle (the Heroes didn't want to win anyway).",
                    FightersLeftStanding = villainsStandingAfterBattle
                };
            }

            return new BattleResult { ResultMessage = "All fighters have been vanquished, neither side wins..." };
        }
    }
}