using System.Collections.Generic;
using System.Linq;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StraightCsApi.Controllers;
using StraightCsApi.DTOs;

namespace CommonTests
{
    [TestClass]
    public class StraightCs
    {
        [TestMethod]
        public void GetHeroes()
        {
            var heroes = new HeroController().Get();

            Assert.AreEqual(5, heroes.Count());
        }

        [TestMethod]
        public void GetVillains()
        {
            var villains = new VillainController().Get();

            Assert.AreEqual(5, villains.Count());
        }

        [TestMethod]
        public void NoShowFight()
        {
            var battle = new Battle
            {
                Heroes = new List<int>().ToArray(),
                Villains = new List<int>().ToArray()
            };

            var battleResult = new BattleController().Post(battle);

            Assert.AreEqual(CommonStrings.NoShowResultString, battleResult.ResultMessage);
        }

        [TestMethod]
        public void TiedFight()
        {
            var battle = new Battle
            {
                Heroes = new []{ 1, 2 },
                Villains = new[] { 1, 2 }
            };

            var battleResult = new BattleController().Post(battle);

            Assert.AreEqual(CommonStrings.TieResultString, battleResult.ResultMessage);
        }

        [TestMethod]
        public void HeroesWinByWalkOver()
        {
            var heroes = new HeroController().Get();
            var battle = new Battle
            {
                Heroes = heroes.Select(h => h.Id).ToArray(),
                Villains = new List<int>().ToArray()
            };

            var battleResult = new BattleController().Post(battle);

            Assert.AreEqual(CommonStrings.HeroesByWalkoverResultString, battleResult.ResultMessage);
        }

        [TestMethod]
        public void VillainsWinByWalkOver()
        {
            var villains = new VillainController().Get();
            var battle = new Battle
            {
                Villains = villains.Select(h => h.Id).ToArray(),
                Heroes = new List<int>().ToArray()
            };

            var battleResult = new BattleController().Post(battle);

            Assert.AreEqual(CommonStrings.VillainsByWalkoverResultString, battleResult.ResultMessage);
        }

        [TestMethod]
        public void HeroesWin()
        {
            var heroes = new HeroController().Get();
            var battle = new Battle
            {
                Heroes = heroes.Select(h => h.Id).ToArray(),
                Villains = new[] { 1 }
            };

            var battleResult = new BattleController().Post(battle);

            Assert.AreEqual(CommonStrings.HeroesWinResultString, battleResult.ResultMessage);
        }

        [TestMethod]
        public void VillainsWin()
        {
            var villains = new VillainController().Get();
            var battle = new Battle
            {
                Villains = villains.Select(h => h.Id).ToArray(),
                Heroes = new []{ 1 }
            };

            var battleResult = new BattleController().Post(battle);

            Assert.AreEqual(CommonStrings.VillainsWinResultString, battleResult.ResultMessage);
        }
    }
}