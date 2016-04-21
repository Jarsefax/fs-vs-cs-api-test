namespace StraightFsApi

open Common
open Types
open Newtonsoft.Json
open System.IO
open System.Linq
open System.Web.Http

type BattleController() =
    inherit ApiController()

    member this.Post battle =
        let anyVillains = battle.Villains.Length > 0
        let anyHeroes = battle.Heroes.Length > 0

        if not anyHeroes && not anyVillains then 
            { ResultMessage = CommonStrings.NoShowResultString; FightersLeftStanding = Array.empty<Fighter> }
        elif anyHeroes && not anyVillains then 
            { ResultMessage = CommonStrings.HeroesByWalkoverResultString; FightersLeftStanding = Array.empty }
        elif not anyHeroes && anyVillains then 
            { ResultMessage = CommonStrings.VillainsByWalkoverResultString; FightersLeftStanding = Array.empty }
        else
            let path = @"C:\Users\rnor\Documents\C#vsF#"

            let heroesPath = Path.Combine(path, "heroes.txt")
            let heroesListString = File.ReadAllText(heroesPath)
            let heroList = JsonConvert.DeserializeObject<FighterModel[]> heroesListString
            let heroesInBattle = heroList.Where(fun h -> battle.Heroes.Contains(h.Id))
            let orderedHeroesInBattle = heroesInBattle.OrderByDescending(fun h -> h.Power)

            let villainPath = Path.Combine(path, "Villains.txt")
            let villainListString = File.ReadAllText(villainPath)
            let villainList = JsonConvert.DeserializeObject<FighterModel[]> villainListString
            let villainsInBattle = villainList.Where(fun v -> battle.Villains.Contains(v.Id))
            let orderedVillainsInBattle = villainsInBattle.OrderByDescending(fun v -> v.Power)

            let heroesInBattleCount = orderedHeroesInBattle.Count()
            let villainsInBattleCount = orderedVillainsInBattle.Count()
            
            let countCompare = heroesInBattleCount.CompareTo(villainsInBattleCount)
            let mutable shortestCount = 0
            if countCompare > 0 then
                shortestCount <- villainsInBattleCount
            else
                shortestCount <- heroesInBattleCount

            let shortestCount =
                match heroesInBattleCount > villainsInBattleCount with
                | true -> villainsInBattleCount
                | _ -> heroesInBattleCount

            for i = shortestCount downto 0 do
                let heroesAvaliableForFight = orderedHeroesInBattle.Skip(i - 1).Where(fun h -> h.HasBeenDefeated = false)
                let heroesPower = heroesAvaliableForFight.Sum(fun h -> h.Power)
                
                let villainsAvaliableForFight = orderedVillainsInBattle.Skip(i - 1).Where(fun v -> v.HasBeenDefeated = false)
                let villainsPower = villainsAvaliableForFight.Sum(fun v -> v.Power)

                let powerCompare = heroesPower.CompareTo(villainsPower)
                if powerCompare > 0 then
                    for villain in villainsAvaliableForFight do
                        villain.HasBeenDefeated <- true
                elif powerCompare < 0 then
                    for hero in heroesAvaliableForFight do
                        hero.HasBeenDefeated <- true
                else
                    for villain in villainsAvaliableForFight do
                        villain.HasBeenDefeated <- true                    
                    for hero in heroesAvaliableForFight do
                        hero.HasBeenDefeated <- true

            let heroesStandingAfterBattle = 
                heroesInBattle
                    .Where(fun h -> not h.HasBeenDefeated)
                    .Select(fun h -> 
                        {
                            Id = h.Id
                            Name = h.Name
                            Class = h.Class
                        })
            if heroesStandingAfterBattle.Any() then
                { ResultMessage = CommonStrings.HeroesWinResultString; FightersLeftStanding = heroesStandingAfterBattle.ToArray() }
            else
                let villainsStandingAfterBattle =
                    villainsInBattle
                        .Where(fun v -> not v.HasBeenDefeated)
                        .Select(fun v -> 
                            { 
                                Id = v.Id
                                Name = v.Name
                                Class = v.Class
                            })
                if villainsStandingAfterBattle.Any() then
                    { ResultMessage = CommonStrings.VillainsWinResultString; FightersLeftStanding = villainsStandingAfterBattle.ToArray() }
                else
                    { ResultMessage =  CommonStrings.TieResultString; FightersLeftStanding = Array.empty<Fighter> }